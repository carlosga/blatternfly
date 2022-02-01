namespace Blatternfly.UnitTests.Components;

public class SliderTests
{
    [Fact]
    public void DiscreteWithCustomStepsTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var steps = new SliderStepObject[]
        {
            new() { Value =   0, Label = "0%" },
            new() { Value =  25, Label = "25%", IsLabelHidden = true },
            new() { Value =  50, Label = "50%" },
            new() { Value =  75, Label = "75%", IsLabelHidden = true },
            new() { Value = 100, Label = "100%" }
        };

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Slider>(parameters => parameters
            .Add(p => p.Value, 50)
            .Add(p => p.CustomSteps, steps)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-slider""
  style=""--pf-c-slider--value: 50%; --pf-c-slider__value--c-form-control--width-chars: 1;""
>
  <div
    class=""pf-c-slider__main""
  >
    <div
      class=""pf-c-slider__rail""
    >
      <div
        class=""pf-c-slider__rail-track""
      >
      </div>
    </div>
    <div
      aria-hidden=""true""
      class=""pf-c-slider__steps""
    >
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 0%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          0%
        </div>
      </div>
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 25%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
      </div>
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 50%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          50%
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 75%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 100%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          100%
        </div>
      </div>
    </div>
    <div
      aria-disabled=""false""
      aria-label=""Value""
      aria-valuemax=""100.0""
      aria-valuemin=""0""
      aria-valuenow=""50""
      aria-valuetext=""50%""
      class=""pf-c-slider__thumb""
      role=""slider""
      tabIndex=""0""
    />
  </div>
</div>
");
    }

    [Fact]
    public void ContinuousWithCustomStepsTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var steps = new SliderStepObject[]
        {
            new() { Value =   0, Label = "0%" },
            new() { Value = 100, Label = "100%" }
        };

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Slider>(parameters => parameters
            .Add(p => p.Value, 50)
            .Add(p => p.AreCustomStepsContinuous, true)
            .Add(p => p.CustomSteps, steps)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-slider""
  style=""--pf-c-slider--value: 50%; --pf-c-slider__value--c-form-control--width-chars: 1;""
>
  <div
    class=""pf-c-slider__main""
  >
    <div
      class=""pf-c-slider__rail""
    >
      <div
        class=""pf-c-slider__rail-track""
      >
      </div>
    </div>
    <div
      aria-hidden=""true""
      class=""pf-c-slider__steps""
    >
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 0%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          0%
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 100%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          100%
        </div>
      </div>
    </div>
    <div
      aria-disabled=""false""
      aria-label=""Value""
      aria-valuemax=""100.0""
      aria-valuemin=""0""
      aria-valuenow=""50""
      aria-valuetext=""50""
      class=""pf-c-slider__thumb""
      role=""slider""
      tabIndex=""0""
    />
  </div>
</div>
");
    }

    [Fact]
    public void WithRightAlignedInputTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var steps = new SliderStepObject[]
        {
            new() { Value =   0, Label = "0%" },
            new() { Value = 100, Label = "100%" }
        };

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Slider>(parameters => parameters
            .Add(p => p.Value, 50)
            .Add(p => p.IsInputVisible, true)
            .Add(p => p.InputValue, 50)
            .Add(p => p.InputLabel, "%")
            .Add(p => p.InputPosition, SliderInputPosition.Right)
            .Add(p => p.CustomSteps, steps)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-slider""
  style=""--pf-c-slider--value: 50%; --pf-c-slider__value--c-form-control--width-chars: 2;""
>
  <div
    class=""pf-c-slider__main""
  >
    <div
      class=""pf-c-slider__rail""
    >
      <div
        class=""pf-c-slider__rail-track""
      >
      </div>
    </div>
    <div
      aria-hidden=""true""
      class=""pf-c-slider__steps""
    >
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 0%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          0%
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 100%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          100%
        </div>
      </div>
    </div>
    <div
      aria-disabled=""false""
      aria-label=""Value""
      aria-valuemax=""100.0""
      aria-valuemin=""0""
      aria-valuenow=""50""
      aria-valuetext=""50""
      class=""pf-c-slider__thumb""
      role=""slider""
      tabindex=""0""
    ></div>
  </div>
  <div
    class=""pf-c-slider__value""
  >
    <div
      class=""pf-c-input-group""
    >
      <div
        type=""number""
        class=""pf-c-number-input pf-c-form-control""
      >
        <div
            class=""pf-c-input-group""
        >
          <input
            step=""any""
            type=""number""
            class=""pf-c-form-control""
            aria-label=""Slider value input""
            value=""50""
          />
        </div>
      </div>
      <span class=""pf-c-input-group__text pf-m-plain"">
        %
      </span>
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithInputAboveThumbTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var steps = new SliderStepObject[]
        {
            new() { Value =   0, Label = "0%" },
            new() { Value = 100, Label = "100%" }
        };

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Slider>(parameters => parameters
            .Add(p => p.Value, 50)
            .Add(p => p.IsInputVisible, true)
            .Add(p => p.InputValue, 50)
            .Add(p => p.InputLabel, "%")
            .Add(p => p.InputPosition, SliderInputPosition.AboveThumb)
            .Add(p => p.CustomSteps, steps)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-slider""
  style=""--pf-c-slider--value: 50%; --pf-c-slider__value--c-form-control--width-chars: 2;""
>
  <div
    class=""pf-c-slider__main""
  >
    <div
      class=""pf-c-slider__rail""
    >
      <div
        class=""pf-c-slider__rail-track""
      >
      </div>
    </div>
    <div
      aria-hidden=""true""
      class=""pf-c-slider__steps""
    >
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 0%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          0%
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 100%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          100%
        </div>
      </div>
    </div>
   <div
     aria-disabled=""false""
     aria-label=""Value""
     aria-valuemax=""100.0""
     aria-valuemin=""0""
     aria-valuenow=""50""
     aria-valuetext=""50""
     class=""pf-c-slider__thumb""
     role=""slider""
     tabindex=""0""
   ></div>
   <div
     class=""pf-c-slider__value pf-m-floating""
   >
     <div
       class=""pf-c-input-group""
     >
       <div
         type=""number""
         class=""pf-c-number-input pf-c-form-control""
       >
         <div
           class=""pf-c-input-group""
         >
           <input
             step=""any""
             type=""number""
             class=""pf-c-form-control""
             aria-label=""Slider value input""
             value=""50""
           />
         </div>
       </div>
       <span class=""pf-c-input-group__text pf-m-plain"">
         %
       </span>
     </div>
   </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithInputActionsTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var steps = new SliderStepObject[]
        {
            new() { Value =   0, Label = "0%" },
            new() { Value =  25, Label = "25%", IsLabelHidden = true },
            new() { Value =  50, Label = "50%" },
            new() { Value =  75, Label = "75%", IsLabelHidden = true },
            new() { Value = 100, Label = "100%" }
        };

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Slider>(parameters => parameters
            .Add(p => p.Value, 50)
            .Add(p => p.CustomSteps, steps)
            .Add<Button>(p => p.LeftActions, button1params => button1params
                .Add(p => p.Variant, ButtonVariant.Plain)
                .Add(p => p.AriaLabel, "Minus")
            )
            .Add<Button>(p => p.RightActions, button2params => button2params
                .Add(p => p.Variant, ButtonVariant.Plain)
                .Add(p => p.AriaLabel, "Plus")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-slider""
  style=""--pf-c-slider--value: 50%; --pf-c-slider__value--c-form-control--width-chars: 1;""
>
  <div
    class=""pf-c-slider__actions""
  >
    <button
      aria-disabled=""false""
      aria-label=""Minus""
      class=""pf-c-button pf-m-plain""
      type=""button""
    />
  </div>
  <div
    class=""pf-c-slider__main""
  >
    <div
      class=""pf-c-slider__rail""
    >
      <div
        class=""pf-c-slider__rail-track""
      >
      </div>
    </div>
    <div
      aria-hidden=""true""
      class=""pf-c-slider__steps""
    >
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 0%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          0%
        </div>
      </div>
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 25%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
      </div>
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 50%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          50%
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 75%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 100%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          100%
        </div>
      </div>
    </div>
    <div
      aria-disabled=""false""
      aria-label=""Value""
      aria-valuemax=""100.0""
      aria-valuemin=""0""
      aria-valuenow=""50""
      aria-valuetext=""50%""
      class=""pf-c-slider__thumb""
      role=""slider""
      tabIndex=""0""
    ></div>
  </div>
  <div
    class=""pf-c-slider__actions""
  >
    <button
      aria-disabled=""false""
      aria-label=""Plus""
      class=""pf-c-button pf-m-plain""
      type=""button""
    />
  </div>
</div>
");
    }

    [Fact]
    public void IsDisabledTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var steps = new SliderStepObject[]
        {
            new() { Value =   0, Label = "0%" },
            new() { Value =  25, Label = "25%", IsLabelHidden = true },
            new() { Value =  50, Label = "50%" },
            new() { Value =  75, Label = "75%", IsLabelHidden = true },
            new() { Value = 100, Label = "100%" }
        };

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Slider>(parameters => parameters
            .Add(p => p.Value, 50)
            .Add(p => p.CustomSteps, steps)
            .Add(p => p.IsDisabled, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-slider pf-m-disabled""
  style=""--pf-c-slider--value: 50%; --pf-c-slider__value--c-form-control--width-chars: 1;""
>
  <div
    class=""pf-c-slider__main""
  >
    <div
      class=""pf-c-slider__rail""
    >
      <div
        class=""pf-c-slider__rail-track""
      >
      </div>
    </div>
    <div
      aria-hidden=""true""
      class=""pf-c-slider__steps""
    >
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 0%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          0%
        </div>
      </div>
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 25%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
      </div>
      <div
        class=""pf-c-slider__step pf-m-active""
        style=""--pf-c-slider__step--Left: 50%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          50%
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 75%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
      </div>
      <div
        class=""pf-c-slider__step""
        style=""--pf-c-slider__step--Left: 100%""
      >
        <div
          class=""pf-c-slider__step-tick""
        >
        </div>
        <div
          class=""pf-c-slider__step-label""
        >
          100%
        </div>
      </div>
    </div>
    <div
      aria-disabled=""true""
      aria-label=""Value""
      aria-valuemax=""100.0""
      aria-valuemin=""0""
      aria-valuenow=""50""
      aria-valuetext=""50%""
      class=""pf-c-slider__thumb""
      role=""slider""
      tabIndex=""-1""
    />
  </div>
</div>
");
    }
}
