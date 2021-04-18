using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Cart;
using Application.Catalog.Mangas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Extensions.Extensions;
using ViewModels.Catalog.Cart;
using System.Collections.Generic;
using Data.EF;
using Data.Entities;
using ApiSer;
using Utilities.Constants;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using PayPal.Core;
using PayPal.v1.Payments;
using BraintreeHttp;

namespace WebApp.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        private readonly MnDbContext _context;
        private readonly string _clientId;
        private readonly string _secretKey;

        public double TyGiaUSD = 23300;//store in Database

        [BindProperty]
        public CartViewModel ShoppingCartVM { get; set; }

        public CartController(MnDbContext context, IConfiguration config)
        {
            _context = context;
            _clientId = config["PaypalSettings:ClientId"];
            _secretKey = config["PaypalSettings:SecretKey"];
            ShoppingCartVM = new CartViewModel()
            {
                mangas = new List<Manga>()
            };
        }

        public List<CartItem> Carts
        {
            get
            {
                var carts = HttpContext.Session.Get<List<CartItem>>("giohang");
                if (carts == null)
                {
                    carts = new List<CartItem>();
                }
                return carts;
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CartItem> giohang = HttpContext.Session.Get<List<CartItem>>("giohang");
            ViewBag.Thongbao = "Không có sản phẩm nào trong giỏ hàng...";
            return View(giohang);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString("giohang");
            List<CartItem> currentCart = new List<CartItem>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItem>>(session);
            return Ok(currentCart);
        }
        public IActionResult Cart()
        {
            return View();
        }

        public async Task<IActionResult> AddItem(int magaId, int soluong)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("giohang");
            if (cart == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                cart = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
            if (cart.FirstOrDefault(m => m.MangaId == magaId) == null) // ko co sp nay trong gio hang
            {
                Manga sp = _context.Mangas.Find(magaId);  // tim sp theo sanPhamID
                //chua dieu chinh (thong bao khong tim thay sp)
                if (sp == null)
                {
                    //thong bao ra khong tim thay
                    return Redirect("Home/NotFound");
                }
                CartItem newItem = new CartItem()
                {
                    MangaId = magaId,
                    TenManga = sp.Ten,
                    SoLuong = 1,
                    Hinh = sp.HinhAnh,
                    Gia = sp.Gia
                };  // Tạo ra 1 CartItem mới
                cart.Add(newItem);  // Thêm CartItem vào giỏ
                HttpContext.Session.Set("giohang", cart);
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = cart.FirstOrDefault(m => m.MangaId == magaId);
                cardItem.SoLuong++;
                HttpContext.Session.Set("giohang", cart);
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            //return RedirectToAction("ChiTiet", "SanPham", new { id = magaId });
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCart(int magaId, int soluong)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("giohang");
            //if (session != null)
            //    currentCart = JsonConvert.DeserializeObject<List<CartItem>>(session);
            if (cart == null)
            {
                return Redirect("Home/NotFound");
            }
            foreach (var item in cart)
            {
                if (item.MangaId == magaId)
                {
                    if (soluong == 0)
                    {
                        cart.Remove(item);
                        break;
                    }
                    item.SoLuong = soluong;
                }
            }

            HttpContext.Session.Set("giohang", cart);
            return Ok(cart);
        }

        //public IActionResult Remove(int magaId)
        //{
        //    List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

        //    if (lstCartItems.Count > 0)
        //    {
        //        if (lstCartItems.Contains(magaId))
        //        {
        //            lstCartItems.Remove(magaId);
        //        }
        //    }
        //    HttpContext.Session.Set("ssShoppingCart", lstCartItems);
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult XoaKhoiGio(int magaId)
        {
            List<CartItem> lstCartItems = HttpContext.Session.Get<List<CartItem>>("giohang");
            CartItem itemXoa = lstCartItems.FirstOrDefault(m => m.MangaId == magaId);
            if (itemXoa != null)
            {
                lstCartItems.Remove(itemXoa);
            }
            HttpContext.Session.Set("giohang", lstCartItems);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PaypalCheckout()
        {
            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);

            #region Create Paypal Order
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            var total = Math.Round(Carts.Sum(p => p.ThanhTien) / TyGiaUSD, 2);
            foreach (var item in Carts)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.TenManga,
                    Currency = "USD",
                    Price = Math.Round(item.Gia / TyGiaUSD, 2).ToString(),
                    Quantity = item.SoLuong.ToString(),
                    Sku = "sku",
                    Tax = "0"
                });
            }
            #endregion

            var paypalOrderId = DateTime.Now.Ticks;
            var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var payment = new PayPal.v1.Payments.Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"{hostname}/Cart/CheckoutFail",
                    ReturnUrl = $"{hostname}/Cart/CheckoutSuccess"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }

            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                //string payerId = request.Params["PayerID"];
                //if (string.IsNullOrEmpty(payerId))
                //{
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                PayPal.v1.Payments.Payment result = response.Result<PayPal.v1.Payments.Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }

                return Redirect(paypalRedirectUrl);
                //}
                //else
                //{
                //}
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                //Process when Checkout with Paypal fails
                return Redirect("/Cart/CheckoutFail");
            }

        }
        public IActionResult CheckoutFail()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Chưa thanh toán"
            //Xóa session
            return View();
        }

        public IActionResult CheckoutSuccess()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Paypal" và thành công
            //Xóa session
            List<CartItem> lstCartItem = HttpContext.Session.Get<List<CartItem>>("giohang");
            lstCartItem = new List<CartItem>();
            HttpContext.Session.Set("giohang", lstCartItem);
            return View();
        }

    }
}