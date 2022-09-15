using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public partial class CalendarMonth : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private ICalendarMonthInteropModule CalendarMonthInterop { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Month/year to base other dates around.</summary>
    [Parameter] public DateOnly? Date { get; set; }

    /// <summary>Callback when date is selected.</summary>
    [Parameter] public EventCallback<DateOnly?> DateChanged { get; set; }

    /// <summary>Form control value expression.</summary>
    [Parameter] public Expression<Func<DateOnly?>> DateExpression { get; set; }

    /// <summary>Functions that returns if a date is valid and selectable.</summary>
    [Parameter] public IEnumerable<IDateValidator> Validators { get; set; }

    // @hide Internal prop to allow pressing escape in select menu to not close popover.
    [Parameter] public EventCallback<bool> OnSelectToggle { get; set; }

    ///Flag to set browser focus on the passed date._
    [Parameter] public bool IsDateFocused { get; set; }

    /// <summary>Callback when month or year is changed.</summary>
    //[Parameter] public EventCallback<DateOnly> OnMonthChange { get; set; }

    /// <summary>If using the default formatters which locale to use.</summary>
    /// <summary>Undefined defaults to current locale.</summary>
    /// <summary>See https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl#Locale_identification_and_negotiation.</summary>
    [Parameter] public CultureInfo Locale { get; set; }

    /// <summary>Day of week that starts the week. 0 is Sunday, 6 is Saturday..</summary>
    [Parameter] public DayOfWeek? WeekStart { get; set; }

    /// <summary>Which date to start range styles from.</summary>
    [Parameter] public DateOnly? RangeStart { get; set; }

    /// <summary>Aria-label for the previous month button.</summary>
    [Parameter] public string PrevMonthAriaLabel { get; set; } = "Previous month";

    /// <summary>Aria-label for the next month button.</summary>
    [Parameter] public string NextMonthAriaLabel { get; set; } = "Next month";

    /// <summary>Aria-label for the year input.</summary>
    [Parameter] public string YearInputAriaLabel { get; set; } = "Select year";

    [Parameter] public bool IsSelectOpen { get; set; }

    ///How to format months in Select.
    public string MonthFormat(string monthName) => CurrentLocale.TextInfo.ToTitleCase(monthName);

    /// <summary>How to format week days in header.</summary>
    public string WeekdayFormat(DateOnly date) => date.ToString("ddd", CurrentLocale)[0..1].ToUpper();

    /// <summary>How to format days in header for screen readers.</summary>
    public string LongWeekdayFormat(DateOnly date) => CurrentLocale.TextInfo.ToTitleCase(date.ToString("dddd", CurrentLocale));

    /// <summary>How to format days in buttons in table cells.</summary>
    public string DayFormat(DateOnly date) => date.Day.ToString();

    /// <summary>Aria-label for the date cells.</summary>
    public string CellAriaLabel(DateOnly date) => date.ToString("dd MMMM yyyy", Locale);

    private ElementReference TableBodyReference { get; set; }
    private string           HiddenMonthId      { get; set; }
    private CultureInfo      CurrentLocale      { get => Locale ?? CultureInfo.CurrentUICulture; }
    private string[]         LongMonths         { get => CurrentLocale.DateTimeFormat.MonthNames; }
    private DateOnly?        HoveredDate        { get; set; }
    private string           MonthFormatted     { get; set; }

    private IReadOnlyList<CalendarDay[]> Calendar { get; set; }

    private DateOnly _focusedDate;
    private DateOnly FocusedDate
    {
        get => _focusedDate;
        set
        {
            if (!EqualityComparer<DateOnly>.Default.Equals(value, _focusedDate))
            {
                _focusedDate   = value;
                YearFormatted  = value.Year.ToString();
                MonthFormatted = MonthFormat(LongMonths[value.Month - 1]);
                Calendar       = CalendarBuilder.Build(value.Year, value.Month, WeekStart, CurrentLocale, Validators);
            }
        }
    }

    private string YearFormatted    { get; set; }
    private DateOnly PrevMonth      { get => AddMonths(-1); }
    private DateOnly NextMonth      { get => AddMonths(1); }
    private DateOnly Today          { get => new (DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day); }
    private bool IsHoveredDateValid { get => IsValidated(HoveredDate); }

    [DynamicDependency(nameof(OnKeyDown))]
    protected override void OnInitialized()
    {
        base.OnInitialized();

        HiddenMonthId = ComponentIdGenerator.Generate("hidden-month-span");
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        FocusedDate = !IsValidDate(Date)
            ? (IsValidDate(RangeStart) ? RangeStart.Value : Today)
                : Date.Value;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            await CalendarMonthInterop.OnKeydown(dotNetObjRef, TableBodyReference);
        }
    }

    private DateOnly AddMonths(int months)     => FocusedDate.AddMonths(months);
    private void SetHoveredDate(DateOnly date) => HoveredDate = Date;
    private bool IsValidDate(DateOnly? date)   => date.HasValue;

    private bool IsValidated(DateOnly? date)
    {
        if (!HoveredDate.HasValue)
        {
            return false;
        }
        if (!date.HasValue)
        {
            return false;
        }
        if (Validators == null || !Validators.Any())
        {
            return true;
        }
        return Validators.All(validator => validator.Validate(date.Value));
    }

    private async Task MonthToggleHandler(bool isExpanded)
    {
        IsSelectOpen = !IsSelectOpen;
        await OnSelectToggle.InvokeAsync(IsSelectOpen);
    }

    private void OnPreviousMonthClick(MouseEventArgs _) => OnMonthClick(PrevMonth);
    private void OnNextMonthClick(MouseEventArgs _)     => OnMonthClick(NextMonth);

    private void OnMonthClick(DateOnly newDate)
    {
        FocusedDate = newDate;
        HoveredDate = newDate;
        SetShouldFocus(false);
        // await OnMonthChange.InvokeAsync(newDate);
    }

    private void OnYearChanged(string newValue)
    {
        YearFormatted = newValue;
        FocusedDate   = new DateOnly(int.Parse(newValue), FocusedDate.Month, 01);
        HoveredDate   = FocusedDate;
        SetShouldFocus(false);
        // await OnMonthChange.InvokeAsync(FocusedDate);
    }

    private async Task MonthSelectedHandler(SelectOption option)
    {
        IsSelectOpen = false;
        await OnSelectToggle.InvokeAsync(false);
        FocusedDate  = new DateOnly(FocusedDate.Year, int.Parse(option.Value), 1);
        HoveredDate  = FocusedDate;
        SetShouldFocus(false);
        // await OnMonthChange.InvokeAsync(FocusedDate);
    }

    private async Task ChangeDate(DateOnly newDate)
    {
        Date        = newDate;
        FocusedDate = newDate;
        HoveredDate = newDate;
        await DateChanged.InvokeAsync(newDate);
        StateHasChanged();
    }

    private void SetShouldFocus(bool focus)
    {
    }

    private CalendarDayRenderInfo GetCalendarDayInfo(CalendarDay day)
    {
        var date            = day.Date;
        var dayFormatted    = DayFormat(date);
        var isToday         = date == Today;
        var isSelected      = IsValidDate(Date) && date == Date;
        var isFocused       = date == FocusedDate;
        var isAdjacentMonth = date.Month != FocusedDate.Month;
        var isRangeStart    = IsValidDate(RangeStart) && date == RangeStart;
        var isInRange       = false;
        var isRangeEnd      = false;

        if (IsValidDate(RangeStart) && IsValidDate(Date))
        {
            isInRange  = date > RangeStart && date < Date;
            isRangeEnd = date == Date;
        }
        else if (IsValidDate(RangeStart) && IsHoveredDateValid)
        {
            if (HoveredDate > RangeStart || HoveredDate == RangeStart)
            {
                isInRange    = date > RangeStart && date < HoveredDate;
                isRangeStart = date == RangeStart;
                isRangeEnd   = date == HoveredDate;
            }
            // Don't handle focused dates before start dates for now.
            // Core would likely need new styles
        }

        var cellCssClass = new CssBuilder("pf-c-calendar-month__dates-cell")
            .AddClass("pf-m-adjacent-month", isAdjacentMonth)
            .AddClass("pf-m-current"       , isToday)
            .AddClass("pf-m-selected"      , isSelected || isRangeStart)
            .AddClass("pf-m-disabled"      , !day.IsValid)
            .AddClass("pf-m-in-range"      , isInRange || isRangeStart || isRangeEnd)
            .AddClass("pf-m-start-range"   , isRangeStart)
            .AddClass("pf-m-end-range"     , isRangeEnd)
            .Build();

        var monthDateCssClass = new CssBuilder("pf-c-calendar-month__date")
            .AddClass("pf-m-hover"    , isRangeEnd)
            .AddClass("pf-m-disabled" , !day.IsValid)
            .Build();

        return new CalendarDayRenderInfo
        {
            Index             = day.Index,
            Date              = date,
            DayFormatted      = dayFormatted,
            TabIndex          = isFocused ? 0 : -1,
            IsDisabled        = !day.IsValid,
            IsToday           = isToday,
            IsSelected        = isSelected,
            IsFocused         = isFocused,
            IsAdjacentMonth   = isAdjacentMonth,
            IsInRange         = isInRange,
            IsRangeStart      = isRangeStart,
            IsRangeEnd        = isRangeEnd,
            CellCssClass      = cellCssClass,
            MonthDateCssClass = monthDateCssClass
        };
    }

    private IEnumerable<CalendarDayRenderInfo> GetCalendarWeekInfo(int weekIndex  )
    {
        return Calendar[weekIndex].Select(GetCalendarDayInfo);
    }

    [JSInvokable]
    public async Task OnKeyDown(KeyboardEventArgs args)
    {
        var newDate = FocusedDate;
        if (args.Key == Keys.ArrowUp) {
            newDate = newDate.AddDays(-7);
        } else if (args.Key == Keys.ArrowRight) {
            newDate = newDate.AddDays(1);
        } else if (args.Key == Keys.ArrowDown) {
            newDate = newDate.AddDays(7);
        } else if (args.Key == Keys.ArrowLeft) {
            newDate = newDate.AddDays(-1);
        }
        if (newDate != FocusedDate && IsValidated(newDate)) {
            FocusedDate = newDate;
            HoveredDate = newDate;
            SetShouldFocus(true);
            await ChangeDate(newDate);
        }
    }
}