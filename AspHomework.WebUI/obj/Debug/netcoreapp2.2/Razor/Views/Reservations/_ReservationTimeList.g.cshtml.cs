#pragma checksum "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "311783f896b760f7cf7c3cba1e280395203d6be6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservations__ReservationTimeList), @"mvc.1.0.view", @"/Views/Reservations/_ReservationTimeList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reservations/_ReservationTimeList.cshtml", typeof(AspNetCore.Views_Reservations__ReservationTimeList))]
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
#line 1 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/_ViewImports.cshtml"
using AspHomework.WebUI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"311783f896b760f7cf7c3cba1e280395203d6be6", @"/Views/Reservations/_ReservationTimeList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4758eb403c731af0ed2a7799e4c9eafeb58bb174", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservations__ReservationTimeList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AspHomework.Core.Modules.Reservation.Models.ReservationDateTime>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(78, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
 if (Model.Any(x => x.IsAvailable))
{

#line default
#line hidden
            BeginContext(120, 25, true);
            WriteLiteral("    <div class=\"row\">\r\n\r\n");
            EndContext();
#line 7 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
         foreach (var date in Model)
        {

#line default
#line hidden
            BeginContext(194, 65, true);
            WriteLiteral("            <div class=\"col-xs-6 col-md-3\">\r\n                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 259, "\"", 335, 2);
            WriteAttributeValue("", 267, "reservation-date", 267, 16, true);
#line 10 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
WriteAttributeValue(" ", 283, date.IsAvailable ? "available" : "not-available", 284, 51, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(336, 42, true);
            WriteLiteral(">\r\n                    <span class=\"text\">");
            EndContext();
            BeginContext(379, 27, false);
#line 11 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
                                  Write(date.From.ToString("HH:mm"));

#line default
#line hidden
            EndContext();
            BeginContext(406, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(410, 28, false);
#line 11 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
                                                                 Write(date.Until.ToString("HH:mm"));

#line default
#line hidden
            EndContext();
            BeginContext(438, 49, true);
            WriteLiteral("</span>\r\n                    <span class=\"value\">");
            EndContext();
            BeginContext(488, 23, false);
#line 12 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
                                   Write(date.From.ToString("O"));

#line default
#line hidden
            EndContext();
            BeginContext(511, 53, true);
            WriteLiteral("</span>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 15 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
        }

#line default
#line hidden
            BeginContext(575, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 17 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(599, 57, true);
            WriteLiteral("    <h2>There are no available dates for this day.</h2>\r\n");
            EndContext();
#line 21 "/Users/vladimirmrkacek/Documents/Projects/AspHomework/AspHomework.WebUI/Views/Reservations/_ReservationTimeList.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AspHomework.Core.Modules.Reservation.Models.ReservationDateTime>> Html { get; private set; }
    }
}
#pragma warning restore 1591