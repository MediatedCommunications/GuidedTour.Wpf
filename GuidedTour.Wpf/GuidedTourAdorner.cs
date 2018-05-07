using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace GuidedTour.Wpf {
    public class GuidedTourAdorner : Adorner {

        public FrameworkElement AdornedControl;
        public Frame Frame { get; private set; }
        

        public GuidedTourAdorner(FrameworkElement adornedElement, Frame Frame) : base(adornedElement) {
            this.AdornedControl = adornedElement;

            this.Frame = Frame;
            this.Presenter = new GuidedTourPresenter() {
                Frame = Frame
            };
        }

        protected override int VisualChildrenCount {
            get {
                return 1;
            }
        }

        protected override Visual GetVisualChild(int index) {
            if (index != 0) throw new ArgumentOutOfRangeException();
            return Presenter;
        }

        private GuidedTourPresenter __Presenter;
        public GuidedTourPresenter Presenter {
            get { return __Presenter; }
            set {
                if (__Presenter != null) {
                    RemoveVisualChild(__Presenter);
                }
                __Presenter = value;
                if (__Presenter != null) {
                    AddVisualChild(__Presenter);
                }
            }
        }

        private void Resize() {

            var P = AdornedControl.TranslatePoint(new Point(0, 0), this)
                ;

            Presenter.FocusAreaLeft = P.X;
            Presenter.FocusAreaTop = P.Y;
            Presenter.FocusAreaHeight = AdornedControl.ActualHeight;
            Presenter.FocusAreaWidth = AdornedControl.ActualWidth;
        }

        
        protected override Size MeasureOverride(Size constraint) {
            __Presenter.Measure(constraint);

            Resize();

            return constraint;
        }

        protected override Size ArrangeOverride(Size finalSize) {
            __Presenter.Arrange(new Rect(finalSize));

            Resize();

            return __Presenter.RenderSize;
        }


        public override GeneralTransform GetDesiredTransform(GeneralTransform transform) {

            return new TranslateTransform(0, 0);
        }
      


      

    }
}
