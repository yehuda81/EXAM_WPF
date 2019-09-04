using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace Exam_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Click;
        private MainWindowViewModel vm;       
        public MainWindow()
        {
            InitializeComponent();
            this.vm = new MainWindowViewModel(); 
            this.DataContext = this.vm;
        }

        private void ElpsedEventHandler(object sender, ElapsedEventArgs e)
        {         
            
            Action a = new Action(() => timerTXT.Text = $"{e.SignalTime.Millisecond}");
            SafeInvoke(a);                                   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Click = true;            
            Task.Run(() =>
            {               
                Timer timer = new Timer(1);
                timer.Elapsed += ElpsedEventHandler;
                timer.Start();
            });
            Task.Run(() =>
            {               
                string size = vm.ReadUrl2();
                Action action = new Action(() => SizeBox.Text = size);                
                SafeInvoke(action);                              
            });
        }
        public void SafeInvoke(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                action.Invoke();
                return;
            }
            else
            {
                this.Dispatcher.BeginInvoke(action);
            }
        }
    }
}
