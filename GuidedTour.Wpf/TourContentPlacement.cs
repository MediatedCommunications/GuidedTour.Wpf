using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuidedTour.Wpf {
    public enum TourContentPlacement {
        TopLeft = 00,
        TopCenter = 01,
        TopRight =02,
        MiddleLeft =10,
        MiddleCenter=11,
        MiddleRight=12,
        BottomLeft=20,
        BottomCenter=21,
        BottomRight=22,

        Top = TopCenter,
        Bottom = BottomCenter,
        Left = MiddleLeft,
        Right = MiddleRight,
        Middle = MiddleCenter,

    }

    public class TourContentPlacementToRowConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var ret = 0;

            if (value is TourContentPlacement P) {
                ret = ((int)P / 10) % 10;
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }


    public class TourContentPlacementToColumnConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var ret = 0;
            if (value is TourContentPlacement P) {
                ret = ((int)P / 1) % 10;
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

}
