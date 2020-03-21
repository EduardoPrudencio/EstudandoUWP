using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Remeberme.Converters
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = new DateTimeOffset(((DateTime)value).ToUniversalTime());
            return date;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime;
        }
    }
}
