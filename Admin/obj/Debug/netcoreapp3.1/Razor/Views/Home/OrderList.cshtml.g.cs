#pragma checksum "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1445283dceef9221ebb539dafcef68ac4235f06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OrderList), @"mvc.1.0.view", @"/Views/Home/OrderList.cshtml")]
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
#line 1 "D:\Lab\AzureLab-1\Admin\Views\_ViewImports.cshtml"
using Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Lab\AzureLab-1\Admin\Views\_ViewImports.cshtml"
using Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1445283dceef9221ebb539dafcef68ac4235f06", @"/Views/Home/OrderList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0acccc60c742d8a86eef1c0cdad0f786bf023898", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OrderList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EventMessagingDemo.Models.OrderModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
  
    ViewData["Title"] = "OrderList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<script src=\"https://code.jquery.com/jquery-3.4.1.min.js\"\n        integrity=\"sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=\"\n        crossorigin=\"anonymous\"></script>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1445283dceef9221ebb539dafcef68ac4235f063795", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n<h1>OrderList</h1>\n\n<p>\n  \n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 21 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 24 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 27 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 33 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 36 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 39 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 42 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                <input type=\"button\" class=\"btnAccept\" value=\"Accept\"");
            BeginWriteAttribute("orderid", " orderid=\"", 1174, "\"", 1197, 1);
#nullable restore
#line 45 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
WriteAttributeValue("", 1184, item.OrderId, 1184, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n                <input type=\"button\" class=\"btnReject\" value=\"Reject\"");
            BeginWriteAttribute("orderid", " orderid=\"", 1271, "\"", 1294, 1);
#nullable restore
#line 46 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
WriteAttributeValue("", 1281, item.OrderId, 1281, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            </td>\n        </tr>\n");
#nullable restore
#line 49 "D:\Lab\AzureLab-1\Admin\Views\Home\OrderList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<script>
    $(document).ready(function () {
        var  connection = new signalR.HubConnectionBuilder()
            .withUrl(""https://sidsignalrnegotiate.azurewebsites.net/api/"")
            .configureLogging(signalR.LogLevel.Information)
            .build();

        connection.start().then(function () {
            console.log(""connected"");
        });

        connection.on('productOrdered', function (order) {
            alert(""order recieved for the product "" + order.ProductName + "".Please refresh!"");
            getAllDashboardUpdates();

        });

        function getAllDashboardUpdates() {
            $.ajax({
                url: '/Home/Index',
                cache: false
            }).success(function (result) {
                //$(""#refTable"").html(result);
            }).error(function () {
            });
        }

        function UpdateOrderStatus(id,status) {
            $.ajax({
                url: ""home/ChangeOrderStatus?orderId="" + id +""&status=""+st");
            WriteLiteral(@"atus,
                cache: false,
                success: function(html) {
                    alert(""Order Updates"");
                }
            });
        }

        $("".btnAccept"").click(function() {
            var id = $(this).attr(""orderid"");
            UpdateOrderStatus(id, 1);
        });

        $("".btnReject"").click(function () {
            var id = $(this).attr(""orderid"");
            UpdateOrderStatus(id, 2);
        });
        
    })
</script>



");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EventMessagingDemo.Models.OrderModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
