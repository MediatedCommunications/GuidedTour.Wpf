using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuidedTour.Wpf {
    /// <summary>
    /// Interaction logic for GuidedTourControl.xaml
    /// </summary>
    public partial class GuidedTourPresenter : UserControl {
        public GuidedTourPresenter() {
            InitializeComponent();
        }

        public static DependencyProperty FrameProperty = DependencyProperty.Register(nameof(Frame), typeof(Frame), typeof(GuidedTourPresenter));

        public Frame Frame {
            get {
                return (Frame)GetValue(FrameProperty);
            }
            set {
                SetValue(FrameProperty, value);
            }
        }

        private const double FocusAreaTop_Default = 25;
        public static DependencyProperty FocusAreaTopProperty = DependencyProperty.Register(nameof(FocusAreaTop), typeof(double), typeof(GuidedTourPresenter), new PropertyMetadata(FocusAreaTop_Default, FocusAreaTopChanged));

        private static void FocusAreaTopChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is GuidedTourPresenter P) {
                P.SetMargin();
            }
        }

        public double FocusAreaTop {
            get {
                return (double)GetValue(FocusAreaTopProperty);
            }
            set {
                SetValue(FocusAreaTopProperty, value);
            }
        }

        private const double FocusAreaLeft_Default = 25;
        public static DependencyProperty FocusAreaLeftProperty = DependencyProperty.Register(nameof(FocusAreaLeft), typeof(double), typeof(GuidedTourPresenter), new PropertyMetadata(FocusAreaLeft_Default, FocusAreaLeftChanged));

        private static void FocusAreaLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if(d is GuidedTourPresenter P) {
                P.SetMargin();
            }
        }

        public double FocusAreaLeft {
            get {
                return (double)GetValue(FocusAreaLeftProperty);
            }
            set {
                SetValue(FocusAreaLeftProperty, value);
            }
        }

        private const double FocusAreaHeight_Default = 25;
        public static DependencyProperty FocusAreaHeightProperty = DependencyProperty.Register(nameof(FocusAreaHeight), typeof(double), typeof(GuidedTourPresenter), new PropertyMetadata(FocusAreaHeight_Default));
        public double FocusAreaHeight {
            get {
                return (double)GetValue(FocusAreaHeightProperty);
            }
            set {
                SetValue(FocusAreaHeightProperty, value);
            }
        }

        private const double FocusAreaWidth_Default = 150;
        public static DependencyProperty FocusAreaWidthProperty = DependencyProperty.Register(nameof(FocusAreaWidth), typeof(double), typeof(GuidedTourPresenter), new PropertyMetadata(FocusAreaWidth_Default));
        public double FocusAreaWidth {
            get {
                return (double)GetValue(FocusAreaWidthProperty);
            }
            set {
                SetValue(FocusAreaWidthProperty, value);
            }
        }

        public static DependencyPropertyKey FocusAreaMarginPropertyKey = DependencyProperty.RegisterReadOnly(nameof(FocusAreaMargin), typeof(Thickness), typeof(GuidedTourPresenter), new PropertyMetadata(new Thickness(FocusAreaLeft_Default, FocusAreaTop_Default, 0, 0)));
        public static DependencyProperty FocusAreaMarginProperty = FocusAreaMarginPropertyKey.DependencyProperty;

        private void SetMargin() {
            FocusAreaMargin = new Thickness() {
                Left = FocusAreaLeft,
                Top = FocusAreaTop,
            };
        }

       
        /*
        protected override Geometry GetLayoutClip(Size layoutSlotSize) {
            var Group = new GeometryGroup();
            Group.Children.Add(new RectangleGeometry(new Rect() {
                X = FocusAreaLeft,
                Y = FocusAreaTop,
                Height = FocusAreaHeight,
                Width = FocusAreaWidth
            }));

            Group.Children.Add(new RectangleGeometry(new Rect(layoutSlotSize)));

            return Group;
        }
        */

        public Thickness FocusAreaMargin {
            get {
                return (Thickness)GetValue(FocusAreaMarginProperty);
            }
            protected set {
                SetValue(FocusAreaMarginPropertyKey, value);
            }
        }

    }
}
