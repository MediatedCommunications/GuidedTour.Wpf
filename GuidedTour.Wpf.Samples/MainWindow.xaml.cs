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
using System.Windows.Threading;

namespace GuidedTour.Tests {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private DispatcherTimer Timer;
        public MainWindow() {
            InitializeComponent();

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(.1);
            Timer.Tick += this.Timer_Tick;
            Timer.Start();
        }


        private double Offset = -1;

        private void Timer_Tick(object sender, EventArgs e) {
            Button1.Margin = new Thickness(Button1.Margin.Left + Offset, Button1.Margin.Top + Offset, Button1.Margin.Right, Button1.Margin.Bottom);

        }

        private void Button1_Click(object sender, RoutedEventArgs e) {
            GuidedTour.MoveNext();
        }

        private void Button2_Click(object sender, RoutedEventArgs e) {
            GuidedTour.MoveNext();
        }

        private void Button3_Click(object sender, RoutedEventArgs e) {
            GuidedTour.MoveNext();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {

        }

        private void NextFrame_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.Handled = true;

            e.CanExecute = true;
        }

        private void NextFrame_Execute(object sender, ExecutedRoutedEventArgs e) {
            e.Handled = true;
            this.GuidedTour.MoveNext();
        }

        private void Previous_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.Handled = true;
            e.CanExecute = true;

        }

        private void Previous_Execute(object sender, ExecutedRoutedEventArgs e) {
            e.Handled = true;
        }
    }
}
