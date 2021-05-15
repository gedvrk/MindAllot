using MindAllot.Data.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MindAllot.Converters
{
    public class TaskStateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((TaskState)value)
            {
                case TaskState.Ongoing:
                    return false;
                case TaskState.Completed:
                default:
                    return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return TaskState.Completed;

            return TaskState.Ongoing;
        }
    }
}
