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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace MineServers {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            #region window stuff
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            int style = GetWindowLong(hwnd, GetWindowLong(hwnd, -16));
            style |= 0x00C00000 | 0x00080000 | 0x00020000;
            style &= ~0x00040000;
            SetWindowLong(hwnd, -16, style);
            #endregion

            EventAdder();
        }

        void EventAdder() {
            this.MouseMove += Window_MouseMove;
        }

        #region window stuff
        private void Window_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr WinHelper, int nIdx);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr WinHelper, int nIdx, int dwNewLong);

        private void btn_Exit_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }

        private void btn_Minisize_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
        #endregion
    }
}
