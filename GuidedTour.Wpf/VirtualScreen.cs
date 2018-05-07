using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuidedTour.Wpf {
    public class VirtualScreen : DependencyObject {
        private static readonly DependencyPropertyKey TopPropertyKey = DependencyProperty.RegisterReadOnly(
           nameof(Top), typeof(double), typeof(VirtualScreen), new PropertyMetadata()
           );

        private static readonly DependencyPropertyKey LeftPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(Left), typeof(double), typeof(VirtualScreen), new PropertyMetadata()
            );

        private static readonly DependencyPropertyKey ActualHeightPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(Height), typeof(double), typeof(VirtualScreen), new PropertyMetadata()
            );

        private static readonly DependencyPropertyKey ActualWidthPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(Width), typeof(double), typeof(VirtualScreen), new PropertyMetadata()
            );


        public static readonly DependencyProperty TopProperty = TopPropertyKey.DependencyProperty;
        public static readonly DependencyProperty LeftProperty = LeftPropertyKey.DependencyProperty;
        public static readonly DependencyProperty HeightProperty = ActualHeightPropertyKey.DependencyProperty;
        public static readonly DependencyProperty WidthProperty = ActualWidthPropertyKey.DependencyProperty;

        public VirtualScreen() {
            CheckForNewValues();
        }

        public void CheckForNewValues() {
            Top = SystemParameters.VirtualScreenTop;
            Left = SystemParameters.VirtualScreenLeft;
            Height = SystemParameters.VirtualScreenHeight;
            Width = SystemParameters.VirtualScreenWidth;

        }


        public double Top {
            get {
                return (double)GetValue(TopProperty);
            }
            protected set {
                SetValue(TopPropertyKey, value);
            }
        }

        public double Left {
            get {
                return (double)GetValue(LeftProperty);
            }
            protected set {
                SetValue(LeftPropertyKey, value);
            }
        }

        public double Height {
            get {
                return (double)GetValue(HeightProperty);
            }
            protected set {
                SetValue(ActualHeightPropertyKey, value);
            }
        }

        public double Width {
            get {
                return (double)GetValue(WidthProperty);
            }
            protected set {
                SetValue(ActualWidthPropertyKey, value);
            }
        }

    }
}
