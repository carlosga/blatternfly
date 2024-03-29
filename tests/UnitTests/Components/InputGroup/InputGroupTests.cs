﻿namespace Blatternfly.UnitTests.Components;

public class InputGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<InputGroup>(parameters => parameters
            .AddUnmatched("class", "text-verify-cls")
            .AddUnmatched("id", "text-1")
            .Add<TextInput>(p => p.ChildContent, inputparams => inputparams
                .Add(p => p.Value, "this is text")
                .Add(p => p.AriaLabel, "data text")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-input-group text-verify-cls""
  id=""text-1""
>
  <input
    aria-label=""data text""
    class=""pf-c-form-control""
    type=""text""
    aria-invalid=""false""
    value=""this is text"">
</div>
");
    }
}
