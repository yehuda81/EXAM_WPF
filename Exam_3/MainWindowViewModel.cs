using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Exam_3
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {        
        public string URL { get; set; }        
        public DelegateCommand MyDelegate { get; set; }
        private string _size;
        private bool _ButtonIsEnabled;        
        public event PropertyChangedEventHandler PropertyChanged;    
       
        public bool ButtonIsEnabled
        {
            get
            {
                return _ButtonIsEnabled;
            }
            set
            {
                _ButtonIsEnabled = value;
            }
        }
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        public MainWindowViewModel()
        {
            MyDelegate = new DelegateCommand(ExecuteCommand, CanExecuteMethod);
            Size = "Please Wait...";
            ButtonIsEnabled = true;
        }
        private bool CanExecuteMethod()
        {            
            return true;
        }        
        private void ExecuteCommand()
        {            
            ButtonIsEnabled = false;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ButtonIsEnabled"));            
        //Debug.WriteLine(URL);
        // Option 1 ------------------
        //ReadUrl(URL);
        // option 2 ------------------
        //Task.Run(() =>
        //    {
        //        Action action = new Action(() => ReadUrl2(URL));
        //        Thread.Sleep(2000);
        //        action.Invoke();                
        //    });            
        }        
        public string ReadUrl2()
        {
            string url = URL;
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response = webRequest.GetResponseAsync().Result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {                
                string text = reader.ReadToEndAsync().Result;
                // text.Length == is the length of the result 
                Size = text.Length.ToString();                            
            }
            ButtonIsEnabled = true;           
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ButtonIsEnabled"));
            return Size;
        }

            private async void ReadUrl(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response = await webRequest.GetResponseAsync();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                Thread.Sleep(2000);
                string text = await reader.ReadToEndAsync();
                // text.Length == is the length of the result 
                Size = text.Length.ToString();
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Size"));
            }
            ButtonIsEnabled = true;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ButtonIsEnabled"));            
        }
    }
}
