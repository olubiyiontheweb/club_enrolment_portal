#pragma checksum "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\Pages\Clubs\Form.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d8a810eb1a493e552249a7fa9a51e2c65c82140"
// <auto-generated/>
#pragma warning disable 1591
namespace TheKangaroos_ClubEnrolmentPortal.Pages.Clubs
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using TheKangaroos_ClubEnrolmentPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using TheKangaroos_ClubEnrolmentPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/club/register")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/club/edit/{id}")]
    public partial class Form : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\Pages\Clubs\Form.razor"
 if (MyNavigationManager.Uri.Contains("register"))
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<h3 class=\"text-center font-weight-bold text-secondary\">Register a New Club</h3>");
#nullable restore
#line 8 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\Pages\Clubs\Form.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<h3 class=\"text-center font-weight-bold text-secondary\">Edit Club</h3>");
#nullable restore
#line 12 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\Pages\Clubs\Form.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, @"<div class=""row justify-content-center mt-5""><div class=""col-12 col-lg-6""><div class=""card p-4""><form method=""post""><div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
                <div class=""form-group""><label asp-for=""Club.Name"" class=""control-label text-secondary font-weight-bold"">Club Name</label>
                    <input asp-for=""Club.Name"" class=""form-control"">
                    <span asp-validation-for=""Club.Name"" class=""text-danger""></span></div>
                <div class=""form-group""><label asp-for=""Club.Description"" class=""control-label text-secondary font-weight-bold"">Club
                        Description</label>
                    <input asp-for=""Club.Description"" class=""form-control"">
                    <span asp-validation-for=""Club.Description"" class=""text-danger""></span></div>
                <div class=""form-group""><label asp-for=""Club.Image"" class=""control-label text-secondary font-weight-bold"">Club Logo</label>
                    <input type=""file"" asp-for=""Club.Image"" class=""form-control-file"">
                    <span asp-validation-for=""Club.Image"" class=""text-danger""></span></div>
                <div class=""form-group text-center""><input type=""submit"" value=""Register"" class=""btn btn-primary""></div></form></div></div></div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\Pages\Clubs\Form.razor"
       
    [Parameter]
    public string id { get; set; }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager MyNavigationManager { get; set; }
    }
}
#pragma warning restore 1591
