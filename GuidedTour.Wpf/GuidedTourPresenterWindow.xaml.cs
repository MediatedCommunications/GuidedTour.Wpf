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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GuidedTour.Wpf {
    /// <summary>
    /// Interaction logic for GuidedTourWindow.xaml
    /// </summary>
    public partial class GuidedTourPresenterWindow : Window {
        public GuidedTourPresenterWindow() {
            InitializeComponent();
        }

        private void ThisWindow_Loaded(object sender, RoutedEventArgs e) {
            this.Screen = new VirtualScreen();


            WindowInteropHelper wndHelper = new WindowInteropHelper(this);

            int exStyle = (int)Win32.GetWindowLong(wndHelper.Handle, (int)Win32.GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)Win32.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            Win32.SetWindowLong(wndHelper.Handle, (int)Win32.GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
        }

        public static readonly DependencyPropertyKey ScreenPropertyKey = DependencyProperty.RegisterReadOnly(nameof(Screen), typeof(VirtualScreen), typeof(GuidedTourPresenterWindow), new PropertyMetadata(null));
        public static readonly DependencyProperty ScreenProperty = ScreenPropertyKey.DependencyProperty;
        public VirtualScreen Screen {
            get {
                return (VirtualScreen)GetValue(ScreenProperty);
            }
            protected set {
                SetValue(ScreenPropertyKey, value);
            }
        }

    }
}
