using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Exam_1
{
    class ValueConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Double sliderValue = (Double)value;

            if (sliderValue > 100 && sliderValue < 150)
            {
                return "MEDIUM";
            }

            if (sliderValue > 150 && sliderValue < 200)
            {
                return "LARGE";
            }
            if (sliderValue > 200)
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

