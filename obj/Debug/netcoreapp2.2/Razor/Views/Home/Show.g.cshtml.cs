#pragma checksum "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3e9d20ce58bfacf95120ccd97c7c91bf2efa18b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Show), @"mvc.1.0.view", @"/Views/Home/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Show.cshtml", typeof(AspNetCore.Views_Home_Show))]
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
#line 1 "D:\coding dojo\C#\Belt_Exam\Views\_ViewImports.cshtml"
using Belt_Exam;

#line default
#line hidden
#line 2 "D:\coding dojo\C#\Belt_Exam\Views\_ViewImports.cshtml"
using Belt_Exam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3e9d20ce58bfacf95120ccd97c7c91bf2efa18b", @"/Views/Home/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ac07a94d14516ee027a5d62bad0263da1174382", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Activitys>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(23, 28, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n            <h1>");
            EndContext();
            BeginContext(52, 22, false);
#line 10 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
           Write(ViewBag.Activity.Title);

#line default
#line hidden
            EndContext();
            BeginContext(74, 42, true);
            WriteLiteral("</h1>\r\n            <h2>Event Coordinator: ");
            EndContext();
            BeginContext(117, 31, false);
#line 11 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
                              Write(ViewBag.Activity.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(148, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(150, 30, false);
#line 11 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
                                                               Write(ViewBag.Activity.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(180, 57, true);
            WriteLiteral("</h2>\r\n            <h2>Description:</h2>\r\n            <p>");
            EndContext();
            BeginContext(238, 21, false);
#line 13 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
          Write(ViewBag.Activity.Desc);

#line default
#line hidden
            EndContext();
            BeginContext(259, 33, true);
            WriteLiteral("</p>\r\n<h1>List Of Gusts:</h1>\r\n\r\n");
            EndContext();
#line 16 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
 foreach(Association a in @Model.Assoc_Activity)
{

#line default
#line hidden
            BeginContext(345, 8, true);
            WriteLiteral("    <li>");
            EndContext();
            BeginContext(354, 16, false);
#line 18 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
   Write(a.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(370, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(372, 15, false);
#line 18 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
                     Write(a.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(387, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 19 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
                
}

#line default
#line hidden
            BeginContext(415, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 23 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
    if(Model.Assoc_Activity.Where(p=>p.UserId ==@ViewBag.loginUser).Count()==0)
    {

#line default
#line hidden
            BeginContext(507, 4, true);
            WriteLiteral("  <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 511, "\"", 554, 2);
            WriteAttributeValue("", 518, "/AddUserToActivity/", 518, 19, true);
#line 25 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
WriteAttributeValue("", 537, Model.ActivityId, 537, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(555, 62, true);
            WriteLiteral("><button class=\"btn btn-primary theButton\">JOIN</button></a>\r\n");
            EndContext();
#line 26 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
     
    }else 
    {


#line default
#line hidden
            BeginContext(645, 12, true);
            WriteLiteral("          <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 657, "\"", 705, 2);
            WriteAttributeValue("", 664, "/RemoveUserFromActivity/", 664, 24, true);
#line 30 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
WriteAttributeValue("", 688, Model.ActivityId, 688, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(706, 63, true);
            WriteLiteral("><button class=\"btn btn-primary theButton\">Leave</button></a>\r\n");
            EndContext();
#line 31 "D:\coding dojo\C#\Belt_Exam\Views\Home\Show.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Activitys> Html { get; private set; }
    }
}
#pragma warning restore 1591