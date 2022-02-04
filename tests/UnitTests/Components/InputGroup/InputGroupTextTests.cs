namespace Blatternfly.UnitTests.Components;

public class InputGroupTextTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<InputGroupText>(parameters => parameters
            .AddUnmatched("class", "inpt-grp-text")
            .AddUnmatched("id", "email-npt-grp")
            .Add(p => p.Variant, InputGroupTextVariant.Plain)
            .AddChildContent("@")
        );

        // Assert
        cut.MarkupMatches(
@"
<span class=""pf-c-input-group__text pf-m-plain inpt-grp-text"" id=""email-npt-grp"">@</span>
");
    }
}
