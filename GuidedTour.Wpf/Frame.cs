using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GuidedTour.Wpf {
    public class Frame : FrameworkElement {


        #region Focus Area 

        public static readonly DependencyProperty FocusAreaProperty = DependencyProperty.Register(nameof(FocusArea), typeof(FrameworkElement), typeof(Frame), new PropertyMetadata(null, FocusAreaChanged));

        private static void FocusAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {

        }

        public FrameworkElement FocusArea {
            get {
                return (FrameworkElement)GetValue(FocusAreaProperty);
            }
            set {
                SetValue(FocusAreaProperty, value);
            }
        }

        private const double FocusAreaOpacity_Default = 0.7;

        public static readonly DependencyProperty FocusAreaOpacityProperty = DependencyProperty.Register(nameof(FocusAreaOpacity), typeof(double), typeof(Frame), new PropertyMetadata(FocusAreaOpacity_Default));
        public double FocusAreaOpacity {
            get {
                return (double)GetValue(FocusAreaOpacityProperty);
            }
            set {
                SetValue(FocusAreaOpacityProperty, value);
            }
        }

        public static readonly DependencyProperty FocusAreaBrushProperty = DependencyProperty.Register(nameof(FocusAreaBrush), typeof(Brush), typeof(Frame), new PropertyMetadata(null));
        public Brush FocusAreaBrush {
            get {
                return (Brush)GetValue(FocusAreaBrushProperty);
            }
            set {
                SetValue(FocusAreaBrushProperty, value);
            }
        }

        #endregion

        #region Overlay

        private const double OverlayOpacity_Default = 0.7;

        public static readonly DependencyProperty OverlayOpacityProperty = DependencyProperty.Register(nameof(OverlayOpacity), typeof(double), typeof(Frame), new PropertyMetadata(OverlayOpacity_Default));
        public double OverlayOpacity {
            get {
                return (double)GetValue(OverlayOpacityProperty);
            }
            set {
                SetValue(OverlayOpacityProperty, value);
            }
        }


        public static readonly DependencyProperty OverlayBrushProperty = DependencyProperty.Register(nameof(OverlayBrush), typeof(Brush), typeof(Frame), new PropertyMetadata(Brushes.Black));
        public Brush OverlayBrush {
            get {
                return (Brush)GetValue(OverlayBrushProperty);
            }
            set {
                SetValue(OverlayBrushProperty, value);
            }
        }

        #endregion

        #region AdditionalContent 

        public static readonly DependencyProperty TourContentProperty = DependencyProperty.Register(nameof(TourContent), typeof(object), typeof(Frame), new PropertyMetadata(null));
        public object TourContent {
            get {
                return GetValue(TourContentProperty);
            }
            set {
                SetValue(TourContentProperty, value);
            }
        }

        public static readonly DependencyProperty TourContentPlacementProperty = DependencyProperty.Register(nameof(TourContentPlacement), typeof(TourContentPlacement), typeof(Frame), new PropertyMetadata(TourContentPlacement.BottomCenter));
        public TourContentPlacement TourContentPlacement {
            get {
                return (TourContentPlacement)GetValue(TourContentPlacementProperty);
            }
            set {
                SetValue(TourContentPlacementProperty, value);
            }
        }

        private const int TourContentRowSpan_Default = 1;
        public static readonly DependencyProperty TourContentRowSpanProperty = DependencyProperty.Register(nameof(TourContentRowSpan), typeof(int), typeof(Frame), new PropertyMetadata(TourContentRowSpan_Default));
        public int TourContentRowSpan {
            get {
                return (int)GetValue(TourContentRowSpanProperty);
            }
            set {
                SetValue(TourContentRowSpanProperty, value);
            }
        }

        private const int TourContentColumnSpan_Default = 1;
        public static readonly DependencyProperty TourContentColumnSpanProperty = DependencyProperty.Register(nameof(TourContentColumnSpan), typeof(int), typeof(Frame), new PropertyMetadata(TourContentColumnSpan_Default));
        public int TourContentColumnSpan {
            get {
                return (int)GetValue(TourContentColumnSpanProperty);
            }
            set {
                SetValue(TourContentColumnSpanProperty, value);
            }
        }

        private const bool TourContentCenterHorizontally_Default = true;
        public static readonly DependencyProperty TourContentCenterHorizontallyProperty = DependencyProperty.Register(nameof(TourContentCenterHorizontally), typeof(bool), typeof(Frame), new PropertyMetadata(TourContentCenterHorizontally_Default));
        public bool TourContentCenterHorizontally {
            get {
                return (bool)GetValue(TourContentCenterHorizontallyProperty);
            }
            set {
                SetValue(TourContentCenterHorizontallyProperty, value);
            }
        }

        private const bool TourContentCenterVertically_Default = false;
        public static readonly DependencyProperty TourContentCenterVerticallyProperty = DependencyProperty.Register(nameof(TourContentCenterVertically), typeof(bool), typeof(Frame), new PropertyMetadata(TourContentCenterVertically_Default));
        public bool TourContentCenterVertically {
            get {
                return (bool)GetValue(TourContentCenterVerticallyProperty);
            }
            set {
                SetValue(TourContentCenterVerticallyProperty, value);
            }
        }

        #endregion


    }
}
