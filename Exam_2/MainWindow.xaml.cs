using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

namespace Exam_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        ViewModel vm;
        Random r = new Random();
        bool clickButton = false;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
            this.DataContext = vm;
            RandomVariables();            
            vm.RandomExercise();
            RandomAnswers();
            vm.GetRightButton();
            Task t = Task.Run(() =>
            {
                for (int i = 30; i >= 0; i--)
                {
                    if (!clickButton)
                    {
                        Action action = new Action(() => timerTXT.Text = i.ToString());
                        //Dispatcher.BeginInvoke(action);
                        SafeInvoke(action);
                        Thread.Sleep(1000);
                        if (i == 15)
                        {
                            Action s = new Action(() => timerTXT.Foreground = Brushes.Red);
                            SafeInvoke(s);                            
                        }
                    }
                }                
                
                Action a = new Action(() => vm.ButtonIsNotEnabled());                
                SafeInvoke(a);
                
                if (!clickButton)
                {
                    Action e = new Action(() => questionTXT.Background = Brushes.Red);
                    SafeInvoke(e);
                }
            });           
        }

        private void RandomAnswers()
        {
            vm.Button1 = r.Next(vm.Result + 500).ToString();
            vm.Button2 = r.Next(vm.Result + 500).ToString();
            vm.Button3 = r.Next(vm.Result + 500).ToString();
            vm.Button4 = r.Next(vm.Result + 500).ToString();
        }

        private void RandomVariables()
        {
            vm.Num1 = r.Next(100);
            vm.Num2 = r.Next(100);
            vm.MathIndex = r.Next(4);
            vm.RightButton = r.Next(4);
            vm.Result = 0;
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            clickButton = true;
            if (vm.Button1 == $"{vm.Result}")
            {
                questionTXT.Background = Brushes.LawnGreen;
            }
            else
            {
                questionTXT.Background = Brushes.Red;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            clickButton = true;
            if (vm.Button2 == $"{vm.Result}")
            {
                questionTXT.Background = Brushes.LawnGreen;
            }
            else
            {
                questionTXT.Background = Brushes.Red;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            clickButton = true;
            if (vm.Button3 == $"{vm.Result}")
            {
                questionTXT.Background = Brushes.LawnGreen;
            }
            else
            {
                questionTXT.Background = Brushes.Red;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            clickButton = true;
            if (vm.Button4 == $"{vm.Result}")
            {
                questionTXT.Background = Brushes.LawnGreen;
            }
            else
            {
                questionTXT.Background = Brushes.Red;
            }
        }
    }
}
