#pragma checksum "C:\Users\User001\source\repos\700111-2122-group-project-kangaroos\TheKangaroos_ClubEnrolmentPortal\Shared\LoginDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce72bfd9402742339b31bf07835b19617bcc5c0c"
// <auto-generated/>
#pragma warning disable 1591
namespace TheKangaroos_ClubEnrolmentPortal.Shared
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
    public partial class LoginDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "<form method=\"post\" action=\"Identity/Account/LogOut\"><button type=\"submit\" class=\"nav-link btn btn-link\">Log out</button></form>");
            }
            ));
            __builder.AddAttribute(3, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(4, "<a href=\"Identity/Account/Register\">Register</a>\r\n        ");
                __builder2.AddMarkupContent(5, "<a href=\"Identity/Account/Login\">Log in</a>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591