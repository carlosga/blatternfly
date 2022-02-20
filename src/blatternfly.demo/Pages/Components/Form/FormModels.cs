using System.ComponentModel.DataAnnotations;

namespace Blatternfly.Demo.Pages.Components.Form;

public static class FormHelper
{
    public static List<Tuple<string, string, bool>> SelectOptions => new()
    {
        new Tuple<string, string, bool>("select one", "Select one", false),
        new Tuple<string, string, bool>("mr"        , "Mr"        , false),
        new Tuple<string, string, bool>("miss"      , "Miss"      , false),
        new Tuple<string, string, bool>("mrs"       , "Mrs"       , false),
        new Tuple<string, string, bool>("ms"        , "Ms"        , false),
        new Tuple<string, string, bool>("dr"        , "Dr"        , false),
        new Tuple<string, string, bool>("other"     , "Other"     , false)
    };
}

public sealed class BasicModel
{
    [Required]
    [StringLength(10, ErrorMessage = "Name is too long.")]
    public string Name            { get; set; }
    public string Email           { get; set; }
    public string Phone           { get; set; }
    public string Title           { get; set; }
    public string Experience      { get; set; }
    public bool   ContactEmail    { get; set; }
    public bool   ContactPhone    { get; set; }
    public bool   DisallowContact { get; set; }
    public string Notes           { get; set; } = "disabled";
    public bool   EmailUpdates    { get; set; }
}

public sealed class AgeModel
{
    public string Value { get; set; } = "Five";
    public ValidatedOptions? Validated { get; set; } = ValidatedOptions.Error;

    public void OnAgeChanged(string newValue)
    {
        Validated = int.TryParse(newValue, out _) ? ValidatedOptions.Success : ValidatedOptions.Error;
        Value = newValue;
    }
}

public sealed class MixModel
{
    public bool Check1 { get; set; }
    public bool Check2 { get; set; }
}

public sealed class FormSectionsModel
{
    public string TextValue1 { get; set; }
    public string TextValue2 { get; set; }
}

public class FormGridModel
{
    public string TextValue1 { get; set; }
    public string TextValue2 { get; set; }
    public string TextValue3 { get; set; }
}

public sealed class FieldGroupsModel
{
    public string TextValue { get; set; }
}
