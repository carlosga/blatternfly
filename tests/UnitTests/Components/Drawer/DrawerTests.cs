namespace Blatternfly.UnitTests.Components;

public class DrawerTests
{
    [Theory]
    [InlineData(true  , false , false)]
    [InlineData(false , false , false)]
    [InlineData(true  , true  , false)]
    [InlineData(false , true  , false)]
    [InlineData(true  , false , true)]
    public void DrawerPropertiesTest(bool isExpanded, bool isInline, bool isStatic)
    {
        // Arrange
        using var ctx = new TestContext();
        var drawerContent =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pretium est a porttitor vehicula. Quisque vel commodo urna. Morbi mattis rutrum ante, id vehicula ex accumsan ut. Morbi viverra, eros vel porttitor facilisis, eros purus aliquet erat,nec lobortis felis elit pulvinar sem. Vivamus vulputate, risus eget commodo eleifend, eros nibh porta quam, vitae lacinia leo libero at magna. Maecenas aliquam sagittis orci, et posuere nisi ultrices sit amet. Aliquam ex odio, malesuada sed posuere quis, pellentesque at mauris. Phasellus venenatis massa ex, eget pulvinar libero auctor pretium. Aliquam erat volutpat. Duis euismod justo in quam ullamcorper, in commodo massa vulputate.";
        var builder = new StringBuilder();
        var hidden  = isExpanded ? null : @"hidden=""""";
        
        if (isExpanded)
        {
            builder.Append("pf-m-expanded ");
        }
        if (isInline)
        {
            builder.Append("pf-m-inline ");
        }
        if (isStatic)
        {
            builder.Append("pf-m-static ");
        }
        var cssClasses = builder.ToString();

        // Act
        var cut = ctx.RenderComponent<Drawer>(parameters => parameters
            .Add(p => p.IsExpanded, isExpanded)
            .Add(p => p.IsInline, isInline)
            .Add(p => p.IsStatic, isStatic)
            .Add<DrawerContent>(p => p.ChildContent, p1 => p1
                .Add<DrawerPanelContent>(p => p.PanelContent, p2 => p2
                    .Add<DrawerHead>(p => p.ChildContent, p3 => p3
                        .AddChildContent("<span>drawer-panel</span>")
                        .Add<DrawerActions>(p => p.ChildContent, p4 => p4
                            .Add<DrawerCloseButton>(p => p.ChildContent)
                        )
                    )
                    .Add<DrawerPanelBody>(p => p.ChildContent, p5 => p5
                        .AddChildContent("drawer-panel")
                    )
                )
                .Add<DrawerContentBody>(p => p.ChildContent, p6 => p6
                    .AddChildContent(drawerContent)
                )
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
	class=""pf-c-drawer {cssClasses}""
>
  <div
    class=""pf-c-drawer__main""
  >
    <div
      class=""pf-c-drawer__content""
    >
      <div
        class=""pf-c-drawer__body""
      >
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pretium est a porttitor vehicula. Quisque vel commodo urna. Morbi mattis rutrum ante, id vehicula ex accumsan ut. Morbi viverra, eros vel porttitor facilisis, eros purus aliquet erat,nec lobortis felis elit pulvinar sem. Vivamus vulputate, risus eget commodo eleifend, eros nibh porta quam, vitae lacinia leo libero at magna. Maecenas aliquam sagittis orci, et posuere nisi ultrices sit amet. Aliquam ex odio, malesuada sed posuere quis, pellentesque at mauris. Phasellus venenatis massa ex, eget pulvinar libero auctor pretium. Aliquam erat volutpat. Duis euismod justo in quam ullamcorper, in commodo massa vulputate.
      </div>
    </div>
    <div
      class=""pf-c-drawer__panel""
      {hidden}
    >
      <div
        class=""pf-c-drawer__body""
      >
        <div
          class=""pf-c-drawer__head""
        >
          <span>
            drawer-panel
          </span>
          <div
            class=""pf-c-drawer__actions""
          >
            <div
              class=""pf-c-drawer__close""
            >
              <button
                aria-disabled=""false""
                aria-label=""Close drawer panel""
                class=""pf-c-button pf-m-plain""
                type=""button""
              >
                <svg
                  aria-hidden=""true""
                  fill=""currentColor""
                  height=""1em""
                  role=""img""
                  style=""vertical-align: -0.125em""
                  viewBox=""{TimesIcon.IconDefinition.ViewBox}""
                  width=""1em""
                >
                  <path
                    d=""{TimesIcon.IconDefinition.SvgPath}""
                  />
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>
      <div
        class=""pf-c-drawer__body""
      >
        drawer-panel
      </div>
    </div>
  </div>
</div>
");            
    }
    
    [Fact]
    public void DrawerExpandsFromBottomTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var drawerContent =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pretium est a porttitor vehicula. Quisque vel commodo urna. Morbi mattis rutrum ante, id vehicula ex accumsan ut. Morbi viverra, eros vel porttitor facilisis, eros purus aliquet erat,nec lobortis felis elit pulvinar sem. Vivamus vulputate, risus eget commodo eleifend, eros nibh porta quam, vitae lacinia leo libero at magna. Maecenas aliquam sagittis orci, et posuere nisi ultrices sit amet. Aliquam ex odio, malesuada sed posuere quis, pellentesque at mauris. Phasellus venenatis massa ex, eget pulvinar libero auctor pretium. Aliquam erat volutpat. Duis euismod justo in quam ullamcorper, in commodo massa vulputate.";
        var cssClasses = "pf-m-expanded pf-m-panel-bottom";

        // Act
        var cut = ctx.RenderComponent<Drawer>(parameters => parameters
            .Add(p => p.IsExpanded, true)
            .Add(p => p.Position, DrawerPosition.Bottom)
            .Add<DrawerContent>(p => p.ChildContent, p1 => p1
                .Add<DrawerPanelContent>(p => p.PanelContent, p2 => p2
                    .Add<DrawerHead>(p => p.ChildContent, p3 => p3
                        .AddChildContent("<span>drawer-panel</span>")
                        .Add<DrawerActions>(p => p.ChildContent, p4 => p4
                            .Add<DrawerCloseButton>(p => p.ChildContent)
                        )
                    )
                    .Add<DrawerPanelBody>(p => p.ChildContent, p5 => p5
                        .AddChildContent("drawer-panel")
                    )
                )
                .Add<DrawerContentBody>(p => p.ChildContent, p6 => p6
                    .AddChildContent(drawerContent)
                )
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
	class=""pf-c-drawer {cssClasses}""
>
  <div
    class=""pf-c-drawer__main""
  >
    <div
      class=""pf-c-drawer__content""
    >
      <div
        class=""pf-c-drawer__body""
      >
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pretium est a porttitor vehicula. Quisque vel commodo urna. Morbi mattis rutrum ante, id vehicula ex accumsan ut. Morbi viverra, eros vel porttitor facilisis, eros purus aliquet erat,nec lobortis felis elit pulvinar sem. Vivamus vulputate, risus eget commodo eleifend, eros nibh porta quam, vitae lacinia leo libero at magna. Maecenas aliquam sagittis orci, et posuere nisi ultrices sit amet. Aliquam ex odio, malesuada sed posuere quis, pellentesque at mauris. Phasellus venenatis massa ex, eget pulvinar libero auctor pretium. Aliquam erat volutpat. Duis euismod justo in quam ullamcorper, in commodo massa vulputate.
      </div>
    </div>
    <div
      class=""pf-c-drawer__panel""
    >
      <div
        class=""pf-c-drawer__body""
      >
        <div
          class=""pf-c-drawer__head""
        >
          <span>
            drawer-panel
          </span>
          <div
            class=""pf-c-drawer__actions""
          >
            <div
              class=""pf-c-drawer__close""
            >
              <button
                aria-disabled=""false""
                aria-label=""Close drawer panel""
                class=""pf-c-button pf-m-plain""
                type=""button""
              >
                <svg
                  aria-hidden=""true""
                  fill=""currentColor""
                  height=""1em""
                  role=""img""
                  style=""vertical-align: -0.125em""
                  viewBox=""{TimesIcon.IconDefinition.ViewBox}""
                  width=""1em""
                >
                  <path
                    d=""{TimesIcon.IconDefinition.SvgPath}""
                  />
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>
      <div
        class=""pf-c-drawer__body""
      >
        drawer-panel
      </div>
    </div>
  </div>
</div>
");
    }        
}
