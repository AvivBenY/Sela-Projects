#pragma checksum "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a532ae0e5d8659b639c1950ddd1ee7200805414a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AnimalProfile), @"mvc.1.0.view", @"/Views/Home/AnimalProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a532ae0e5d8659b639c1950ddd1ee7200805414a", @"/Views/Home/AnimalProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392956b3227535ec5e3c428e4244c94057f3bd17", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AnimalProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Animal>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top: 25px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
  
    ViewBag.Title = $"{Model.AnimalName}";
    Layout = "~/Views/Shared/Layout/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"bg-secondary\">\r\n    <div class=\"container d-flex align-content-center card bg-dark text-white\" style=\"width: 25rem;\">\r\n        <div class=\"card-img-overlay h-50\">\r\n            <h5 class=\"display-5 card-title\">");
#nullable restore
#line 11 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
                                        Write(Model.AnimalName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h6 class=\"card-text\">");
#nullable restore
#line 12 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
                             Write(Html.DisplayNameFor(a => a.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 12 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
                                                               Write(Html.DisplayFor(a => a.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        </div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a532ae0e5d8659b639c1950ddd1ee7200805414a5879", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 541, "~/Pictures/", 541, 11, true);
#nullable restore
#line 14 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
AddHtmlAttributeValue("", 552, Model.PictureName, 552, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <div class=\"card-body\">\r\n            <h6>");
#nullable restore
#line 16 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
           Write(Html.DisplayNameFor(a => a.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <p>");
#nullable restore
#line 17 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
          Write(Html.DisplayFor(a => a.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div>\r\n            Comments:\r\n            ");
#nullable restore
#line 21 "C:\Users\benye\OneDrive\שולחן העבודה\לימודים פיתוח תוכנה\Projects\ASP animal site Project\AnimalSiteProject\AnimalSiteProject\Views\Home\AnimalProfile.cshtml"
       Write(await Html.PartialAsync("_CommentsPartial", new CommentsViewModel(Model)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Animal> Html { get; private set; }
    }
}
#pragma warning restore 1591