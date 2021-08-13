using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class LoginPageTests
    {
        private static readonly BackgroundImageSrcMap s_images = new()
        {
            lg   = "/assets/images/pfbg_1200.jpg",
            sm   = "/assets/images/pfbg_768.jpg",
            sm2x = "/assets/images/pfbg_768@2x.jpg",
            xs   = "/assets/images/pfbg_576.jpg",
            xs2x = "/assets/images/pfbg_576@2x.jpg"
        };   
        
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<LoginPage>(parameters => parameters
                .Add(p => p.FooterListVariants, ListVariant.Inline)
                .Add(p => p.BrandImgSrc, "Brand src")
                .Add(p => p.BrandImgAlt, "Pf-logo")
                .Add(p => p.BackgroundImgSrc, s_images)
                .Add(p => p.BackgroundImgAlt, "Pf-background")
                .Add(p => p.FooterListItems, "English")
                .Add(p => p.TextContent, "This is placeholder text only.")
                .Add(p => p.LoginTitle, "Log into your account")
                .Add(p => p.SignUpForAccountMessage, @"Login to your account <a href=""https://www.patternfly.org"">Need an account?</a>")
                .Add(p => p.SocialMediaLoginContent, "Footer")
            );

            // Assert
            cut.MarkupMatches(
@"
<div 
  class=""pf-c-background-image""
  style=""--pf-c-background-image--BackgroundImage: url(/assets/images/pfbg_576.jpg); 
          --pf-c-background-image--BackgroundImage-2x: url(/assets/images/pfbg_576@2x.jpg); 
          --pf-c-background-image--BackgroundImage--sm: url(/assets/images/pfbg_768.jpg); 
          --pf-c-background-image--BackgroundImage--sm-2x: url(/assets/images/pfbg_768@2x.jpg); 
          --pf-c-background-image--BackgroundImage--lg: url(/assets/images/pfbg_1200.jpg); 
          --pf-c-background-image--Filter: url(#patternfly-background-image-filter-overlay0);""
  alt=""Pf-background""
>
  <svg xmlns=""http://www.w3.org/2000/svg"" class=""pf-c-background-image__filter"" width=""0"" height=""0"">
    <filter id=""patternfly-background-image-filter-overlay0"">
      <feColorMatrix type=""matrix"" values=""1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 0 0 0 1 0""></feColorMatrix>
      <feComponentTransfer color-interpolation-filters=""sRGB"" result=""duotone"">
        <feFuncR type=""table"" tableValues=""0.086274509803922 0.43921568627451""></feFuncR>
        <feFuncG type=""table"" tableValues=""0.086274509803922 0.43921568627451""></feFuncG>
        <feFuncB type=""table"" tableValues=""0.086274509803922 0.43921568627451""></feFuncB>
        <feFuncA type=""table"" tableValues=""0 1""></feFuncA>
      </feComponentTransfer>
    </filter>
  </svg>
</div>
<div class=""pf-c-login"">
  <div class=""pf-c-login__container"">
    <header class=""pf-c-login__header"">
      <img class=""pf-c-brand"" src=""Brand src"" alt=""Pf-logo"">
    </header>
    <main class=""pf-c-login__main"">
      <header class=""pf-c-login__main-header"">
        <h2 class=""pf-c-title pf-m-3xl"">
          Log into your account
        </h2>
      </header>
      <div class=""pf-c-login__main-body""></div>
      <div class=""pf-c-login__main-footer"">
        <ul class=""pf-c-login__main-footer-links"">
          Footer
        </ul>
        <div class=""pf-c-login__main-footer-band"">
          Login to your account <a href=""https://www.patternfly.org"">Need an account?</a>
        </div>
      </div>
    </main>
    <footer class=""pf-c-login__footer"">
      <p>This is placeholder text only.</p>
      <ul class=""pf-c-list pf-m-inline"">
        English
      </ul>
    </footer>
  </div>
</div>
");
        }        
    }
}
