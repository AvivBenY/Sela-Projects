#pragma checksum "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Admin\AdminActions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1ba48b75fad64ef9941114f9fcfc53d6422ea7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminActions), @"mvc.1.0.view", @"/Views/Admin/AdminActions.cshtml")]
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
#line 3 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\_ViewImports.cshtml"
using AnimalSiteProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1ba48b75fad64ef9941114f9fcfc53d6422ea7f", @"/Views/Admin/AdminActions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392956b3227535ec5e3c428e4244c94057f3bd17", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminActions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Animal>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Admin\AdminActions.cshtml"
  
    ViewData["Title"] = "AddPet";
    Layout = "~/Views/Shared/Layout/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Admin\AdminActions.cshtml"
Write(await Html.PartialAsync("_AdminBarPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Admin\AdminActions.cshtml"
Write(await Html.PartialAsync("_AdminPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Animal>> Html { get; private set; }
    }
}
#pragma warning restore 1591
