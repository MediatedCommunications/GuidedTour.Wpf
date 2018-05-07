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
    /// Interaction logic for WindowGuidedTour.xaml
    /// </summary>
    public partial class WindowGuidedTour : UserControl {
        public WindowGuidedTour() {
            InitializeComponent();
            this.ContentGrid.Visibility = Visibility.Collapsed;
        }

        public List<Frame> Frames { get; } = new List<Frame>();

        public static DependencyProperty CurrentFrameProperty = DependencyProperty.Register(nameof(CurrentFrame), typeof(Frame), typeof(WindowGuidedTour), new PropertyMetadata(null, CurrentFramePropertyChanged));

        private static void CurrentFramePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if(d is WindowGuidedTour T) {
                var NewIndex = T.Frames.IndexOf(e.NewValue as Frame);
                T.CurrentFrameIndex = NewIndex;

                T.DisplayCurrentFrame();
            }
        }

        private GuidedTourAdorner LastAdorner;
        private void DisplayCurrentFrame() {
            var LastLayer = (LastAdorner?.Parent) as AdornerLayer;
            if(LastLayer != null) {
                LastLayer.Remove(LastAdorner);
            }

            var NewAdorner = default(GuidedTourAdorner);
            if(this.CurrentFrame != null) {
                var FocusArea = CurrentFrame.FocusArea;
                var NewLayer = AdornerLayer.GetAdornerLayer(FocusArea);
                NewAdorner = new GuidedTourAdorner(FocusArea, CurrentFrame);

                NewLayer.Add(NewAdorner);
            }

            LastAdorner = NewAdorner;

        }


        public Frame CurrentFrame {
            get {
                return (Frame)this.GetValue(CurrentFrameProperty);
            }
            set {
                SetValue(CurrentFrameProperty, value);
            }
        }

        public static DependencyProperty CurrentFrameIndexProperty = DependencyProperty.Register(nameof(CurrentFrameIndex), typeof(int), typeof(WindowGuidedTour), new PropertyMetadata(-1, CurrentFrameIndexChanged));

        private static void CurrentFrameIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if(d is WindowGuidedTour T && e.NewValue is int I) {
                if(I >= 0 && I < T.Frames.Count) {
                    T.CurrentFrame = T.Frames[I];
                } else {
                    T.CurrentFrame = null;
                    T.CurrentFrameIndex = -1;
                }
            }
        }

        public int CurrentFrameIndex {
            get {
                return (int)this.GetValue(CurrentFrameIndexProperty);
            }
            set {
                SetValue(CurrentFrameIndexProperty, value);
            }
        }
        
       
        public void MoveNext() {
            CurrentFrameIndex += 1;
        }

        public void MovePrevious() {
            CurrentFrameIndex -= 1;
        }

    }
}
