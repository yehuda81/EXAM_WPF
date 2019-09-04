using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Exam_1
{
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Double sliderValue = (Double)value;
            
                if (sliderValue > 200 && sliderValue < 300)
                {
                    return "MEDIUM";
                }

                if (sliderValue > 300 && sliderValue < 400)
                {
                    return "LARGE";
                }
                if (sliderValue > 400)
                {
                    return "EXTRA LARGE";
                } 
            return "SMALL";
        }            
        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
