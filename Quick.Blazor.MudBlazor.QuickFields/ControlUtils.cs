using System.Text;
using MudBlazor;
using Quick.Fields;

namespace Quick.Blazor.MudBlazor.QuickFields;

internal static class ControlUtils
{
    
    public static Variant GetVariant(FieldForGet field)
    {
        if (field.InputButton_IsOutline.HasValue && field.InputButton_IsOutline.Value)
            return Variant.Outlined;
        return Variant.Filled;
    }
    public static Size GetSize(FieldForGet field)
    {
        if(field.Input_IsSmall.HasValue && field.Input_IsSmall.Value)
            return Size.Small;
        if(field.Input_IsLarge.HasValue && field.Input_IsLarge.Value)
            return Size.Large;
        return Size.Medium;
    }
    public static Color GetColor(FieldForGet field)
    {
        switch (field.Theme)
        {
            case FieldTheme.Primary:
                return Color.Primary;
            case FieldTheme.Secondary:
                return Color.Secondary;
            case FieldTheme.Success:
                return Color.Success;
            case FieldTheme.Danger:
                return Color.Error;
            case FieldTheme.Warning:
                return Color.Warning;
            case FieldTheme.Info:
                return Color.Info;
            case FieldTheme.Dark:
                return Color.Dark;
            case FieldTheme.Light:
                return Color.Default;
            default:
                return Color.Default;
        }
    }


    private static void appendCommonClass(StringBuilder sb, FieldForGet field)
    {
        if (field.Margin.HasValue)
            sb.Append(" m-" + field.Margin.Value);
        if (field.MarginLeft.HasValue)
            sb.Append(" ml-" + field.MarginLeft.Value);
        if (field.MarginTop.HasValue)
            sb.Append(" mt-" + field.MarginTop.Value);
        if (field.MarginRight.HasValue)
            sb.Append(" mr-" + field.MarginRight.Value);
        if (field.MarginBottom.HasValue)
            sb.Append(" mb-" + field.MarginBottom.Value);

        if (field.Padding.HasValue)
            sb.Append(" p-" + field.Padding.Value);
        if (field.PaddingLeft.HasValue)
            sb.Append(" pl-" + field.PaddingLeft.Value);
        if (field.PaddingTop.HasValue)
            sb.Append(" pt-" + field.PaddingTop.Value);
        if (field.PaddingRight.HasValue)
            sb.Append(" pr-" + field.PaddingRight.Value);
        if (field.PaddingBottom.HasValue)
            sb.Append(" pb-" + field.PaddingBottom.Value);

        if (field.ColumnWidth.HasValue)
        {
            if (field.ColumnWidth.Value <= 0)
                sb.Append(" col");
            else
                sb.Append(" col-" + field.ColumnWidth.Value);
        }
    }

    public static string GetCommonClass(FieldForGet field, string baseClass = null)
    {
        if (!string.IsNullOrEmpty(field.Html_Class))
            return field.Html_Class;
        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(baseClass))
            sb.Append(baseClass);
        appendCommonClass(sb, field);
        return sb.ToString();
    }

    public static bool GetInputReadOnly(FieldForGet field)
    {
        if (field.Input_ReadOnly == null)
            return false;
        return field.Input_ReadOnly.Value;
    }

    public static Severity GetSeverity(FieldForGet field)
    {
        switch (field.Theme)
        {
            case FieldTheme.Warning:
                return Severity.Warning;
            case FieldTheme.Info:
                return Severity.Info;
            case FieldTheme.Success:
                return Severity.Success;
            case FieldTheme.Danger:
                return Severity.Error;
            default:
                return Severity.Normal;
        }
    }
}
