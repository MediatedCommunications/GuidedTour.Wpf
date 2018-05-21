using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace GuidedTour.Wpf {
    public class WindowGuidedTour : Selector {

        public WindowGuidedTour() {
            Initialize();
        }

        private void Initialize() {
            this.Height = 0;
            this.Width = 0;
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e) {
            DisplayCurrentFrame();
            base.OnSelectionChanged(e);
        }

        private GuidedTourAdorner LastAdorner;
        private void DisplayCurrentFrame() {
            var LastLayer = (LastAdorner?.Parent) as AdornerLayer;
            if (LastLayer != null) {
                LastLayer.Remove(LastAdorner);
            }

            var NewAdorner = default(GuidedTourAdorner);
            if (this.SelectedItem is Frame CurrentFrame) {
                var FocusArea = CurrentFrame.FocusArea;
                var NewLayer = AdornerLayer.GetAdornerLayer(FocusArea);
                if(NewLayer != null) {
                    NewAdorner = new GuidedTourAdorner(FocusArea, CurrentFrame);

                    NewLayer.Add(NewAdorner);
                }
            }

            LastAdorner = NewAdorner;

        }


        public void MoveNext() {
            if(this.SelectedIndex + 1 < this.Items.Count) {
                this.SelectedIndex += 1;
            } else {
                this.SelectedIndex = -1;
            }
        }

        public void MovePrevious() {
            if (this.SelectedIndex - 1 >= 0) {
                this.SelectedIndex -= 1;
            } else {
                this.SelectedIndex = -1;
            }

        }

    }

}

