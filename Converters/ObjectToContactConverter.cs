using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Remeberme.Converters
{
    public class ObjectToContactConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new object();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new object();
        }
    }
}
