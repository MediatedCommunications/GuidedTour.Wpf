using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuidedTour.Wpf {
    public class HalfValueConverter : IMultiValueConverter {
        #region IMultiValueConverter Members

        public object Convert(object[] values,
                              Type targetType,
                              object parameter,
                              CultureInfo culture) {
            if (values == null || values.Length < 2) {
                throw new ArgumentException(
                    "HalfValueConverter expects 2 double values to be passed" +
                    " in this order -> totalWidth, width",
                    "values");
            }

            var totalWidth = 0.0;
            if(values[0] is double tw) {
                totalWidth = tw;
            }

            var width = 0.0;
            if (values[1] is double w) {
                width = w;
            }

            return (object)((totalWidth - width) / 2);
        }

        public object[] ConvertBack(object value,
                                    Type[] targetTypes,
                                    object parameter,
                                    CultureInfo culture) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
