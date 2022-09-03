namespace Blatternfly.Components;

/// <summary>
/// https://www.digitala11y.com/aria-haspopup-properties/
/// </summary>
public enum AriaPopupVariant
{
    /// <summary>
    /// Indicates the element does not have a popup.
    /// </summary>
    NoPopup,

    /// <summary>
    /// Indicates the popup is a menu.
    /// </summary>
    Menu,

    /// <summary>
    /// Indicates the popup is a listbox.
    /// </summary>
    Listbox,

    /// <summary>
    /// Indicates the popup is a tree.
    /// </summary>
    Tree,

    /// <summary>
    /// Indicates the popup is a grid.
    /// </summary>
    Grid,

    /// <summary>
    /// Indicates the popup is a dialog.
    /// </summary>
    Dialog
}
