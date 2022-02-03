namespace Blatternfly.UnitTests.Layouts;

public class GridItemTests
{
    [Fact]
    public void AddsSpanClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<GridItem>(parameters => parameters
            .Add(p => p.Span, 4)
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-l-grid__item pf-m-4-col""/>");
    }

    [Fact]
    public void AddsOffsetClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<GridItem>(parameters => parameters
            .Add(p => p.Offset, 4)
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-l-grid__item pf-m-offset-4-col""/>");
    }

    [Fact]
    public void AddsRowClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<GridItem>(parameters => parameters
            .Add(p => p.RowSpan, 4)
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-l-grid__item pf-m-4-row""/>");
    }

    [Theory]
    [InlineData(DeviceSizes.Small)]
    [InlineData(DeviceSizes.Medium)]
    [InlineData(DeviceSizes.Large)]
    [InlineData(DeviceSizes.ExtraLarge)]
    [InlineData(DeviceSizes.ExtraLarge2)]
    public void AddsDeviceSizedSpanClassTest(DeviceSizes size)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var spanClass = size switch
        {
            DeviceSizes.Small       => "pf-m-4-col-on-sm",
            DeviceSizes.Medium      => "pf-m-4-col-on-md",
            DeviceSizes.Large       => "pf-m-4-col-on-lg",
            DeviceSizes.ExtraLarge  => "pf-m-4-col-on-xl",
            DeviceSizes.ExtraLarge2 => "pf-m-4-col-on-2xl",
            _                       => null
        };

        // Act
        IRenderedComponent<GridItem> cut = null;

        if (size == DeviceSizes.Small)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.Small, 4));
        }
        else if (size == DeviceSizes.Medium)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.Medium, 4));
        }
        else if (size == DeviceSizes.Large)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.Large, 4));
        }
        else if (size == DeviceSizes.ExtraLarge)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.ExtraLarge, 4));
        }
        else if (size == DeviceSizes.ExtraLarge2)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.ExtraLarge2, 4));
        }

        // Assert
        cut.MarkupMatches(@$"<div class=""pf-l-grid__item {spanClass}""/>");
    }

    [Theory]
    [InlineData(DeviceSizes.Small)]
    [InlineData(DeviceSizes.Medium)]
    [InlineData(DeviceSizes.Large)]
    [InlineData(DeviceSizes.ExtraLarge)]
    [InlineData(DeviceSizes.ExtraLarge2)]
    public void AddsDeviceSizedRowClassTest(DeviceSizes size)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var rowClass = size switch
        {
            DeviceSizes.Small       => "pf-m-1-row-on-sm",
            DeviceSizes.Medium      => "pf-m-1-row-on-md",
            DeviceSizes.Large       => "pf-m-1-row-on-lg",
            DeviceSizes.ExtraLarge  => "pf-m-1-row-on-xl",
            DeviceSizes.ExtraLarge2 => "pf-m-1-row-on-2xl",
            _                       => null
        };

        // Act
        IRenderedComponent<GridItem> cut = null;

        if (size == DeviceSizes.Small)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.SmallRowSpan, 1));
        }
        else if (size == DeviceSizes.Medium)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.MediumRowSpan, 1));
        }
        else if (size == DeviceSizes.Large)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.LargeRowSpan, 1));
        }
        else if (size == DeviceSizes.ExtraLarge)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.ExtraLargeRowSpan, 1));
        }
        else if (size == DeviceSizes.ExtraLarge2)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.ExtraLarge2RowSpan, 1));
        }

        // Assert
        cut.MarkupMatches(@$"<div class=""pf-l-grid__item {rowClass}""/>");
    }

    [Theory]
    [InlineData(DeviceSizes.Small)]
    [InlineData(DeviceSizes.Medium)]
    [InlineData(DeviceSizes.Large)]
    [InlineData(DeviceSizes.ExtraLarge)]
    [InlineData(DeviceSizes.ExtraLarge2)]
    public void AddsDeviceSizedOffsetClassTest(DeviceSizes size)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var offsetClass = size switch
        {
            DeviceSizes.Small       => "pf-m-offset-1-col-on-sm",
            DeviceSizes.Medium      => "pf-m-offset-1-col-on-md",
            DeviceSizes.Large       => "pf-m-offset-1-col-on-lg",
            DeviceSizes.ExtraLarge  => "pf-m-offset-1-col-on-xl",
            DeviceSizes.ExtraLarge2 => "pf-m-offset-1-col-on-2xl",
            _                       => null
        };

        // Act
        IRenderedComponent<GridItem> cut = null;

        if (size == DeviceSizes.Small)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.SmallOffset, 1));
        }
        else if (size == DeviceSizes.Medium)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.MediumOffset, 1));
        }
        else if (size == DeviceSizes.Large)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.LargeOffset, 1));
        }
        else if (size == DeviceSizes.ExtraLarge)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.ExtraLargeOffset, 1));
        }
        else if (size == DeviceSizes.ExtraLarge2)
        {
            cut = ctx.RenderComponent<GridItem>(parameters => parameters.Add(p => p.ExtraLarge2Offset, 1));
        }

        // Assert
        cut.MarkupMatches(@$"<div class=""pf-l-grid__item {offsetClass}""/>");
    }
}
