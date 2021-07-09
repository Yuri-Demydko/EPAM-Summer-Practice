#pragma checksum "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8531d7aa59cd2d1062afaac645c74ec774ab1c92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Start), @"mvc.1.0.view", @"/Views/Home/Start.cshtml")]
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
#line 1 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\_ViewImports.cshtml"
using PL.ASP.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\_ViewImports.cshtml"
using PL.ASP.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8531d7aa59cd2d1062afaac645c74ec774ab1c92", @"/Views/Home/Start.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7dab2746a555f46882d6a7632a320d89f2ba894", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Start : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
.jumbotron-fluid
{
padding-top: 48px;
padding-bottom: 48px;
}
.list-group .list-group-flush
{
background: transparent;
}
.list-group-item
{
background: transparent;
font-weight: 300;
}
h2
{
font-size: xxx-large!important;
}
.display-2
{
word-break: break-all;
}
");
#nullable restore
#line 24 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
  
  ViewData["Title"] = "Welcome";

#line default
#line hidden
#nullable disable
            WriteLiteral("</style>\r\n");
#nullable restore
#line 28 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
  
    Layout = "_Layout-Start";
    string partOfTextEN = "";
    string partOfTextRU = "";
    string action = "";
    string controller = "";
    string linkTextEN = "";
    string linkTextRU = "";
    if(!User.Identity.IsAuthenticated)
    {
        controller = "Account";
        action = "Login";
        linkTextEN = "sign in";
        linkTextRU = "авторизоваться";
        partOfTextRU = "Если хотите протестировать возможности проекта, вам придется ";
        partOfTextEN = "If you want to test features of that project, you have to ";
    }
    else
    {
        controller = "Home";
        action = "Index";
        linkTextEN = "Home page";
        linkTextRU = "Домашней страницы";
        partOfTextRU = "Вижу, вы уже авторизованы. Что-же, тогда вы можете протестировать возможности данной библиотеки. Предлагаю начать c";
        partOfTextEN = "I see, you are signed in. So, now you can test that library's features.  Let's start from ";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div  class=""jumbotron jumbotron-fluid"" style=""height: fit-content""  name=""top"">
    <div class=""container"">
        <h1 class=""display-2"">Welcome to Y-Library <span class=""badge badge-primary"">EN</span></h1>
        <p class=""lead"">This is a simple E-Library project developed by Yuri Demydko as EPAM summer practice project. ");
#nullable restore
#line 58 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                 Write(partOfTextEN);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8531d7aa59cd2d1062afaac645c74ec774ab1c925491", async() => {
#nullable restore
#line 58 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                                                                                    Write(linkTextEN);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                                           WriteLiteral(controller);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                                                                    WriteLiteral(action);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@".
            By the way, your account data securely stores in database in MS Azure. All password in DB are encrypted.</p>
        <p class=""text-sm-center text-muted"" style=""font-weight: 300"">To get more info about that project, scroll down</p>
    </div>
</div>
<div class=""jumbotron jumbotron-fluid"" style=""height: fit-content"">
    <div class=""container"">
        <h1 class=""display-2"">Приветствую в Y-Library <span class=""badge badge-danger"">RU</span></h1>
        <p class=""lead"">Это небольшая электронная библиотека, разработанная Юрием Демыдко в рамках летней практики в EPAM. ");
#nullable restore
#line 66 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                      Write(partOfTextRU);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8531d7aa59cd2d1062afaac645c74ec774ab1c929312", async() => {
#nullable restore
#line 66 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                                                                                         Write(linkTextRU);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                                                WriteLiteral(controller);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\yurid\RiderProjects\EPAM_Practice.Library\PL.ASP.MVC\Views\Home\Start.cshtml"
                                                                                                                                                                         WriteLiteral(action);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@".
            Кстати, ваши данные хранятся под защитой в базе данных облака MS Azure. Все пароли шифруются.</p>
        <p class=""text-sm-center text-muted"" style=""font-weight: 300"">Чтобы узнать о проекте больше, пролистайте ниже</p>
    </div>
</div >
<div class=""container-fluid"" id=""funcs"" style=""display: none; padding-left: 0; padding-right: 0"">
    <div class=""row"">
        <div class=""col"">
            <div class=""jumbotron jumbotron-fluid"">
                <div class=""container"" >
                    <h2 class=""display-4"">About functional <span class=""badge badge-primary"">EN</span></h2>
                    <p class=""lead"">All features (and some more) were developed according to practice task. Here's their list:</p>
                    <ul class=""list-group list-group-flush"">
                        <li class=""list-group-item"">CRUD operations with books</li>
                        <li class=""list-group-item"">Authenentification via login/password pair</li>
                        <li class");
            WriteLiteral(@"=""list-group-item"">Only authentificated user granted to commit CRUD operations with library's content</li>
                        <li class=""list-group-item"">Users' profiles with availability to edit user's data</li>
                        <li class=""list-group-item"">Search for specific book(s) by it's title, author, genre or description</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""jumbotron jumbotron-fluid"">
                <div class=""container"">
                    <h2 class=""display-4"">О функционале <span class=""badge badge-danger"">RU</span></h2>
                    <p class=""lead"">Все функции (даже чуть больше) были сделаны в соответствии с заданием практики. Вот их список:</p>
                    <ul class=""list-group list-group-flush"">
                        <li class=""list-group-item"">CRUD операции с книгами</li>
                        <li class=""list-group-item"">Аутентификация с помощью пары");
            WriteLiteral(@" логин/пароль</li>
                        <li class=""list-group-item"">Только аутентифицированный пользователь может работать (CRUD) c книгами</li>
                        <li class=""list-group-item"">Профили пользователей с возможностью их редактирования</li>
                        <li class=""list-group-item"">Поиск книги (книг) по названию, автору, жанру или описанию</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""container-fluid"" id=""techs""  style=""display: none; padding-left: 0; padding-right: 0"">
    <div class=""row"">
        <div class=""col"">
            <div class=""jumbotron jumbotron-fluid"">
                <div class=""container"">
                    <h2 class=""display-4"">Technologies <span class=""badge badge-primary"">EN</span></h2>
                    <ul class=""list-group list-group-flush"">
                        <li class=""list-group-item"">Three-layer architecture</li>
                        <li class=""list-gro");
            WriteLiteral(@"up-item"">Presentation layer made on ASP.NET Core MVC</li>
                        <li class=""list-group-item"">Database made with SQL Server and Entity Framework ORM</li>
                        <li class=""list-group-item"">Authentification based on Microsoft.Identity</li>
                        <li class=""list-group-item"">Frontend based on Bootstrap 4</li>
                        <li class=""list-group-item"">Logging to DB by Serilog</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""jumbotron jumbotron-fluid"">
                <div class=""container"">
                    <h2 class=""display-4"">Технологии <span class=""badge badge-danger"">RU</span></h2>
                    <ul class=""list-group list-group-flush"">
                        <li class=""list-group-item"">Трехслойная архитектура</li>
                        <li class=""list-group-item"">Слой представления - ASP.NET Core</li>
                        <li clas");
            WriteLiteral(@"s=""list-group-item"">База данных - SQL Server и ОРМ Entity Framework</li>
                        <li class=""list-group-item"">Аутентификация - Microsoft.Identity</li>
                        <li class=""list-group-item"">Фронтенд основан на Bootstrap 4</li>
                        <li class=""list-group-item"">Логгирование в БД на Serilog</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""container-fluid"" id=""facts""  style=""display: none; padding-left: 0; padding-right: 0"">
    <div class=""row"">
        <div class=""col"">
            <div class=""jumbotron jumbotron-fluid"">
                <div class=""container"">
                    <h2 class=""display-4"">Some facts <span class=""badge badge-primary"">EN</span></h2>
                    <p class=""lead"">It's absolutely unnecessary, but why not?</p>
                    <ul class=""list-group list-group-flush"">
                        <li class=""list-group-item"">It is the only page with rus");
            WriteLiteral(@"sian language. All other pages only in english</li>
                        <li class=""list-group-item"">Why? Just because I want</li>
                        <li class=""list-group-item"">I think, the most aesthetic item on that site is bookcovers' design</li>
                        <li class=""list-group-item"">There are my GitHub: https://github.com/Yuri-Demydko</li>
                        <li class=""list-group-item"">This project was made with soul :)</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""jumbotron jumbotron-fluid"">
                <div class=""container"">
                    <h2 class=""display-4"">Немного фактов <span class=""badge badge-danger"">RU</span></h2>
                    <p class=""lead"">Это совершенно необязательно, но почему бы и нет?</p>
                    <ul class=""list-group list-group-flush"">
                        <li class=""list-group-item"">Это единственная страница с русским язы");
            WriteLiteral(@"ком на этом сайте</li>
                        <li class=""list-group-item"">Зачем? Да просто я так захотел</li>
                        <li class=""list-group-item"">Думаю, самая эстетичная штука на сайте - обложки книжек</li>
                        <li class=""list-group-item"">Вот мой Гитхаб: https://github.com/Yuri-Demydko</li>
                        <li class=""list-group-item"">Этот проект сделан с душой :)</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div  id=""totop"" class=""container"" style=""margin-top:30vh "">
    <div class=""row"">
        <div class=""col""><hr>
        </div>
        <div class=""col""");
            BeginWriteAttribute("style", " style=\"", 9253, "\"", 9261, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""btn-group"" role=""group"" style=""width:100%"" aria-label=""Basic example"">
                <button class=""btn btn-outline-secondary btn-sm"" onclick=""scrollToTop()"">To the top</button>
                <button class=""btn btn-outline-secondary btn-sm"" onclick=""scrollToTop()"">Наверх</button>
            </div>
        </div>
        <div class=""col""><hr></div>
    </div>
</div>
<script>
//fOut();
$ ( document ).scroll (fIn);
function fIn () {
    $ ( ""#totop"" ).css ( ""margin-top"", ""auto"" );
    $ ( ""#funcs"" ).fadeIn ( 500, function () {

        $ ( ""#techs"" ).fadeIn ( 500, function () {
            $ ( ""#facts"" ).fadeIn ( 500, function () {
               // document.removeEventListener('scroll', fIn);
            } );
        } );
    } );
}

//fOut();

function scrollToTop()
{
     $(""html, body"").animate({ scrollTop: 0 }, 250);}
                       
                             
                            
   
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591