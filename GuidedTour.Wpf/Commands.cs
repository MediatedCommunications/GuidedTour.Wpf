using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuidedTour.Wpf {
    public static class Commands {

        public static readonly RoutedUICommand NextFrame = new RoutedUICommand("Next", nameof(NextFrame), typeof(Commands));
        public static readonly RoutedUICommand PreviousFrame= new RoutedUICommand("Previous", nameof(PreviousFrame), typeof(Commands));

        public static readonly RoutedUICommand ShowFrame = new RoutedUICommand("Show", nameof(ShowFrame), typeof(Commands));
        public static readonly RoutedUICommand CloseFrame = new RoutedUICommand("Close", nameof(CloseFrame), typeof(Commands));

    }
}
