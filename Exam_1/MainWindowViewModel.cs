using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Exam_1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {        
        public DelegateCommand MyDelegate { get; set; }
        public Double Slide1Value { get; set; }
        public Double Slide2Value { get; set; }
        public string Text { get; set; }
        public MainWindowViewModel()
        {            
            MyDelegate = new DelegateCommand(ExecuteCommand, CanExecuteMethod);
            Slide1Value = 100;
            Slide2Value = 50;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool CanExecuteMethod()
        {
            return true;
        }

        private void ExecuteCommand()
        {
            Window1 window = new Window1(this);
            window.ShowDialog();
        }
        

    }
}
