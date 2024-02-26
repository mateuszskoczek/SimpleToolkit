using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToolkit.UI.WinUI.Converters
{
    public class ObjectToStringConverter : IValueConverter
    {
        #region METHODS

        public object Convert(object value, Type targetType, object parameter, string language) => value.ToString();
        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

        #endregion
    }
}
