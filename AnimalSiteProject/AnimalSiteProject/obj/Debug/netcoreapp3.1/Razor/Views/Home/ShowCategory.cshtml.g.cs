#pragma checksum "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\ShowCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbaa2a86a778ad1686148183dc9003d42c70f5f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowCategory), @"mvc.1.0.view", @"/Views/Home/ShowCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbaa2a86a778ad1686148183dc9003d42c70f5f0", @"/Views/Home/ShowCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392956b3227535ec5e3c428e4244c94057f3bd17", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\ShowCategory.cshtml"
  
    ViewBag.Title = "ShowCategory";
    Layout = "~/Views/Shared/Layout/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div>\r\n    ");
#nullable restore
#line 9 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\ShowCategory.cshtml"
Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 11 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\ShowCategory.cshtml"
Write(await Html.PartialAsync("_AnimalDisplayPartial", Model.Animals));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
