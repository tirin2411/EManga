#pragma checksum "D:\HocTap\Projects\AAA\WebApp\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f584ebde558f58e219c34ffb85252735a976046c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\HocTap\Projects\AAA\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HocTap\Projects\AAA\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f584ebde558f58e219c34ffb85252735a976046c", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\HocTap\Projects\AAA\WebApp\Views\Home\Contact.cshtml"
  
    ViewData["Title"] = "Liên hệ";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""colorlib-contact"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-10 col-md-offset-1 mt-4"">
                <h3>Thông tin liên hệ</h3>
                <div class=""row contact-info-wrap"">
                    <div class=""col-md-3"">
                        <p><span><i class=""fas fa-map-marker-alt""></i></span> Gò Vấp, Hồ Chí Minh</p>
                    </div>
                    <div class=""col-md-3"">
                        <p><span><i class=""fas fa-phone-alt""></i></span> <a href=""tel://1234567920"">+ 1235 2355 98</a></p>
                    </div>
                    <div class=""col-md-3"">
                        <p><span><i class=""fas fa-paper-plane""></i></i></span> <a href=""mailto:info@fmn.com"">info@fmn.com</a></p>
                    </div>
                    <div class=""col-md-3"">
                        <p><span><i class=""fas fa-globe""></i></span> <a href=""#"">fmn.com</a></p>
                    </div>
                </div>
            </di");
            WriteLiteral("v>\r\n            <div class=\"col-md-10 col-md-offset-1\">\r\n                <div class=\"contact-wrap\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f584ebde558f58e219c34ffb85252735a976046c4921", async() => {
                WriteLiteral(@"

                        <div class=""row form-group"">
                            <div class=""col-md-12"">
                                <label for=""name"">Họ tên</label>
                                <input type=""text"" id=""name"" class=""form-control"" placeholder=""Nhập họ tên"">
                            </div>
                        </div>

                        <div class=""row form-group"">
                            <div class=""col-md-12"">
                                <label for=""email"">Email</label>
                                <input type=""text"" id=""email"" class=""form-control"" placeholder=""Nhập địa chỉ email"">
                            </div>
                        </div>

                        <div class=""row form-group"">
                            <div class=""col-md-12"">
                                <label for=""subject"">Tiêu đề</label>
                                <input type=""text"" id=""subject"" class=""form-control"" placeholder=""Nhập tiêu đề"">
               ");
                WriteLiteral(@"             </div>
                        </div>

                        <div class=""row form-group"">
                            <div class=""col-md-12"">
                                <label for=""message"">Nội dung</label>
                                <textarea name=""message"" id=""message"" cols=""30"" rows=""10"" class=""form-control"" placeholder=""Bạn có điều gì muốn liên hệ với tôi""></textarea>
                            </div>
                        </div>
                        <div class=""form-group text-center"">
                            <input type=""submit"" value=""Gửi"" class=""btn btn-primary"">
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div id=""map"" style=""width:768px;height:500px;"">
            <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.969310445002!2d106.68045901428724!3d10.813660461463511!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317528e6d620fc39%3A0xaf6c8749283aa70f!2zODMgxJAuIFRyxrDGoW5nIMSQxINuZyBRdeG6vywgUGjGsOG7nW5nIDMsIEfDsiBW4bqlcCwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1615384973979!5m2!1svi!2s"" width=""600"" height=""450"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 3522, "\"", 3540, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"></iframe>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
