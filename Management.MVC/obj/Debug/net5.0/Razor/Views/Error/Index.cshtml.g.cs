#pragma checksum "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\Error\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16606c0e647f571437f71b1d625633a05f88500e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_Index), @"mvc.1.0.view", @"/Views/Error/Index.cshtml")]
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
#line 1 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using Management.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using Management.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using Management.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using Management.Models.ViewModels.VM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using Management.Models.ViewModels.Mappings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16606c0e647f571437f71b1d625633a05f88500e", @"/Views/Error/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e91d9b0d09156448fe771274c9fa8f4b7544a2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\Error\Index.cshtml"
   
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div>\r\n        <h1>");
#nullable restore
#line 6 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\Error\Index.cshtml"
       Write(ViewBag.StatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <p>");
#nullable restore
#line 7 "C:\Users\WANJA\Desktop\PROJECTS\StoreManagementMVC\Management.MVC\Views\Error\Index.cshtml"
      Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><a href=\"/\" >Home</a></p>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<AppUser> _signInManager { get; private set; }
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
