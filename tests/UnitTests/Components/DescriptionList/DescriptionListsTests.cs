﻿namespace Blatternfly.UnitTests.Components;

public class DescriptionListsTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>();

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list""/>");
    }

    [Theory]
    [InlineData(DescriptionListColumn.Col1)]
    [InlineData(DescriptionListColumn.Col2)]
    [InlineData(DescriptionListColumn.Col3)]
    public void Col1OnAllBreakPointsTest(DescriptionListColumn modifierType)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var modifier = new DescriptionListColumnModifiers
        {
            Default     = modifierType,
            Medium      = modifierType,
            Large       = modifierType,
            ExtraLarge  = modifierType,
            ExtraLarge2 = modifierType
        };
        var cols = modifierType switch
        {
            DescriptionListColumn.Col1 => 1,
            DescriptionListColumn.Col2 => 2,
            DescriptionListColumn.Col3 => 3,
            _                          => 0
        };

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.ColumnModifier, modifier)
        );

        // Assert
        cut.MarkupMatches(
$@"
<dl
  class=""pf-c-description-list pf-m-{cols}-col pf-m-{cols}-col-on-md pf-m-{cols}-col-on-lg pf-m-{cols}-col-on-xl pf-m-{cols}-col-on-2xl""
/>
");
    }

    [Fact]
    public void IsHorizontalTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsHorizontal, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-horizontal""/>");
    }

    [Fact]
    public void IsCompactTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsCompact, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-compact"" />");
    }

    [Fact]
    public void IsCompactAndHorizontalTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsCompact, true)
            .Add(p => p.IsHorizontal, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-horizontal pf-m-compact"" />");
    }

    [Fact]
    public void IsFluidAndHorizontalTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsFluid, true)
            .Add(p => p.IsHorizontal, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-horizontal pf-m-fluid"" />");
    }

    [Fact]
    public void WithAlignmentBreakpointsTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var alignment = new OrientationModifiers
        {
            Small       = Orientation.Horizontal,
            Medium      = Orientation.Vertical,
            Large       = Orientation.Horizontal,
            ExtraLarge  = Orientation.Vertical,
            ExtraLarge2 = Orientation.Horizontal
        };

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsHorizontal, true)
            .Add(p => p.Orientation, alignment)
        );

        // Assert
        cut.MarkupMatches(
@"
<dl
    class=""pf-c-description-list pf-m-horizontal pf-m-horizontal-on-sm pf-m-vertical-on-md pf-m-horizontal-on-lg pf-m-vertical-on-xl pf-m-horizontal-on-2xl""
/>
");
    }

    [Fact]
    public void WithAutoColumnWidthsTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsAutoColumnWidths, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-auto-column-widths""/>");
    }

    [Fact]
    public void IsInlineTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsInlineGrid, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-inline-grid""/>");
    }

    [Fact]
    public void WithAutoFitTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsAutoFit, true)
        );

        // Assert
        cut.MarkupMatches(@"<dl class=""pf-c-description-list pf-m-auto-fit""/>");
    }

    [Fact]
    public void WithAutoFitAndResponsiveGridTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var modifier = new AutoFitModifiers
        {
            Medium      = "100px",
            Large       = "150px",
            ExtraLarge  = "200px",
            ExtraLarge2 = "300px"
        };

        // Act
        var cut = ctx.RenderComponent<DescriptionList>(parameters => parameters
            .Add(p => p.IsAutoFit, true)
            .Add(p => p.AutoFitMinModifier, modifier)
        );

        // Assert
        cut.MarkupMatches(
@"
<dl
  class=""pf-c-description-list pf-m-auto-fit""
  style=""--pf-c-description-list--GridTemplateColumns--min-on-md:100px;--pf-c-description-list--GridTemplateColumns--min-on-lg:150px;--pf-c-description-list--GridTemplateColumns--min-on-xl:200px;--pf-c-description-list--GridTemplateColumns--min-on-2xl:300px;""
/>
");
    }
}
