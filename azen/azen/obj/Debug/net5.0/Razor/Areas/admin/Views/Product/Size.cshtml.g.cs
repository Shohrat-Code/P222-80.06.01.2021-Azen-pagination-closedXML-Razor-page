#pragma checksum "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "654eb6bae7c4990e70782472e9855d6df7cfbb7d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Product_Size), @"mvc.1.0.view", @"/Areas/admin/Views/Product/Size.cshtml")]
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
#line 1 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\_ViewImports.cshtml"
using azen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\_ViewImports.cshtml"
using azen.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\_ViewImports.cshtml"
using azen.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\_ViewImports.cshtml"
using azen.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"654eb6bae7c4990e70782472e9855d6df7cfbb7d", @"/Areas/admin/Views/Product/Size.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce09aa79235bba9d3756fe18caadde6fc53ebdab", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Product_Size : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SizeToProduct>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
  
    ViewData["Title"] = "Size";
    Layout = "~/Areas/admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <ul class=\"list-group\">\r\n                <li class=\"list-group-item\">\r\n                    <h1>Product - ");
#nullable restore
#line 12 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                             Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </li>\r\n                <li class=\"list-group-item\">\r\n                    <h3>Size - ");
#nullable restore
#line 15 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                          Write(Model.Size.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                </li>\r\n\r\n                <li class=\"list-group-item\">\r\n                    <p>Price - ");
#nullable restore
#line 19 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                          Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </li>\r\n\r\n                <li class=\"list-group-item\">\r\n                    <p>Quantity by color:</p>\r\n                    <div>\r\n");
#nullable restore
#line 25 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                         foreach (var item in Model.ColorToSizeToProducts)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 27 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                          Write(item.Color.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 27 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                                             Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 28 "D:\Code Academy\Teaching\Groupes\P222\Lessons\80.06.01.2021-Azen pagination, closedXML, Razor page\Codes\azen\azen\Areas\admin\Views\Product\Size.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SizeToProduct> Html { get; private set; }
    }
}
#pragma warning restore 1591
