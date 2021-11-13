﻿namespace Blatternfly.UnitTests.Components;

public class FormFieldGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<FormFieldGroup>(parameters => parameters
            .Add<FormFieldGroupHeader>(p => p.Header, headerparams => headerparams
                .Add(p => p.TitleText, "Field group 4 (non-expandable)")
                .Add(p => p.TitleTextId, "title-text-id1")
                .Add(p => p.TitleDescription, "Field group 4 description text.")
                .Add<Button>(p => p.Actions)
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-form__field-group""
>
  <div
    class=""pf-c-form__field-group-header""
  >
    <div
      class=""pf-c-form__field-group-header-main""
    >
      <div
        class=""pf-c-form__field-group-header-title""
      >
        <div
          class=""pf-c-form__field-group-header-title-text""
          id=""title-text-id1""
        >
          Field group 4 (non-expandable)
        </div>
      </div>
      <div
        class=""pf-c-form__field-group-header-description""
      >
        Field group 4 description text.
      </div>
    </div>
    <div
      class=""pf-c-form__field-group-header-actions""
    >
      <button
        aria-disabled=""false"" 
        class=""pf-c-button pf-m-primary""
        type=""button""
      />
    </div>
  </div>
  <div
    class=""pf-c-form__field-group-body""
  />
</div>
");
    }
}
