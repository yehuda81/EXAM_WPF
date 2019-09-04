using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Exam_2
{
    public class ViewModel : INotifyPropertyChanged
    {
        public DelegateCommand MyDelegate { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int MathIndex { get; set; }
        public int RightButton { get; set; }
        public string Operation { get; set; }
        public int Result { get; set; }
        public string Button1 { get; set; }
        public string Button2 { get; set; }
        public string Button3 { get; set; }
        public string Button4 { get; set; }
        public bool ButtonIsEnabled { get; set; }        

        public ViewModel()
        {
            MyDelegate = new DelegateCommand(ExecuteCommand, CanExecuteMethod);
            ButtonIsEnabled = true;
        }
        public string Exercise
        {
            get
            {
                return $"{Num1} {Operation} {Num2} ?";
            }
            set
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RandomExercise()
        {
            switch (MathIndex)
            {
                case 0:
                    {
                        Operation = "+";
                        Result = Num1 + Num2;
                        break;
                    }
                case 1:
                    {
                        Operation = "-";
                        Result = Num1 - Num2;
                        break;
                    }
                case 2:
                    {
                        Operation = "*";
                        Result = Num1 * Num2;
                        break;
                    }
                case 3:
                    {
                        Operation = "/";
                        Result = Num1 / Num2;
                        break;
                    }
            }            
        }
        public void GetRightButton()
        {
            switch (RightButton)
            {
                case 0:
                    Button1 = Result.ToString();
                    break;
                case 1:
                    Button2 = Result.ToString();
                    break;
                case 2:
                    Button3 = Result.ToString();
                    break;
                case 3:
                    Button4 = Result.ToString();
                    break;
            }
        }
        private bool CanExecuteMethod()
        {
            return true;
        }
        private void ExecuteCommand()
        {
            ButtonIsNotEnabled();           
        }

        public void ButtonIsNotEnabled()
        {
            ButtonIsEnabled = false;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ButtonIsEnabled"));            
        }
    }   
    
}
