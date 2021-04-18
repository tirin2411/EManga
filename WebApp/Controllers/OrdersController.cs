using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Application.Shipment;
using Data.EF;
using Data.Entities;
using Extensions.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.Catalog.Cart;
using ViewModels.Catalog.Order;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MnDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILocalApiClient _localApiClient;
        private readonly IPriceAndDestinationApiClient _priceAndDestinationApiClient;
        
        public OrdersController(MnDbContext context, UserManager<AppUser> userManager, ILocalApiClient localApiClient,
            IPriceAndDestinationApiClient priceAndDestinationApiClient)
        {
            _context = context;
            _userManager = userManager;
            _localApiClient = localApiClient;
            _priceAndDestinationApiClient = priceAndDestinationApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DatHang(int mangaId, int soluong)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("giohang");
            if (cart == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                cart = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
            //if (cart.FirstOrDefault(m => m.MangaId == magaId) == null) // ko co sp nay trong gio hang
            //{
                Manga sp = _context.Mangas.Find(mangaId);  // tim sp theo sanPhamID
                if (sp == null)
                {
                    return Redirect("Home/NotFound");
                }
            CartItem newItem = new CartItem()
                {
                    MangaId = mangaId,
                    TenManga = sp.Ten,
                    SoLuong = 1,
                    Hinh = sp.HinhAnh,
                    Gia = sp.Gia
                };  // Tạo ra 1 CartItem mới
                cart.Add(newItem);  // Thêm CartItem vào giỏ
                HttpContext.Session.Set("giohang", cart);
            //}
            List<CartItem> cart1 = HttpContext.Session.Get<List<CartItem>>("giohang");
            var list = new List<CartItem>();
            if (cart1 != null)
            {
                list = (List<CartItem>)cart1;
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Payment(int? provinceId, int? districtId)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("giohang");
            var user = await _userManager.GetUserAsync(User);
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            if (user == null)
            {
                //throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                //string message = "<script language=javascript>alert('Vui lòng đăng nhập để mua hàng!!!');</script>";
                //return View();
                return Redirect("Orders/RequestLogin");
            }
            var province = await _localApiClient.GetProvince();
            ViewBag.Provinces = province.Select(x => new SelectListItem()
            {
                Text = x.type +" "+ x.Name,
                Value = x.Id.ToString(),
                Selected = provinceId.HasValue && provinceId.Value == x.Id
            });
         
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(OrderVM request, int? provinceId,int? districtId)
        {
            List<CartItem> lstCartItem = HttpContext.Session.Get<List<CartItem>>("giohang");
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                //throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                //string message = "<script language=javascript>alert('Vui lòng đăng nhập để mua hàng!!!');</script>";
                //return View();
                return Redirect("Orders/RequestLogin");
            }
            var order = new DonHang();
            order.UserId = user.Id;
            order.NgayDat = DateTime.Now;
            order.DiaChiNhan = request.Province +" "+ request.District + " "+ request.Wards +" "+ request.DiaChiNhan;
            order.SDT = request.SDT;
            order.NguoiNhan = request.NguoiNhan;
            order.Email = request.Email;

            _context.DonHangs.Add(order);
            _context.SaveChanges();
            try
            {
                var id = order.Id;
                foreach (var item in lstCartItem)
                {
                    DonHangDetail orderDetail = new DonHangDetail();
                    orderDetail.MangaId = item.MangaId;
                    orderDetail.Soluongdat = item.SoLuong;
                    orderDetail.Gia = item.Gia;
                    orderDetail.DonHangId = id;

                    orderDetail.Tongtien += (item.Gia * item.SoLuong);
                    order.TongTien += (item.Gia * item.SoLuong);
                    _context.DonHangDetails.Add(orderDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //ghi log
                return Redirect("/Fail");
            }
            lstCartItem = new List<CartItem>();
            HttpContext.Session.Set("giohang", lstCartItem);
            return Redirect("Success");
        }

        public async Task<IActionResult> District_Bind(int? provinceId)
        {
            var data = await _localApiClient.GetDistrict(provinceId);
            return Ok(data);
        }

        public async Task<IActionResult> Ward_Bind(int? districtId)
        {
            var data = await _localApiClient.GetWard(districtId);
            return Ok(data);
        }
        public async Task<IActionResult> GetByProvinceId(int? provinceId)
        {
            var data = await _priceAndDestinationApiClient.GetByProvinceId(provinceId);
            return Ok(data);
        }

        public ActionResult RequestLogin()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Fail()
        {
            return View();
        }
    }
}