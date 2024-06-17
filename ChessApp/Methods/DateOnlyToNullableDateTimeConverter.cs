using System.Globalization;
using System.Windows.Data;

namespace ChessApp.Methods;

internal class DateOnlyToNullableDateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateOnly date)
            return new Nullable<DateTime>(new DateTime(date.Year, date.Month, date.Day));
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime date)
            return new DateOnly(date.Year, date.Month, date.Day);
        return null;
    }
}