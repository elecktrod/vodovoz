using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using vodovoz.Models;

namespace vodovoz.Converters
{
    public class DepartmentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int id = (int)values[0];
            ObservableCollection<Department> departments = values[1] as ObservableCollection<Department>;
            var department = departments.Where(d=>d.Id==id).FirstOrDefault();
            if (department == null)
            {
                return "Не выбран";
            }
            return department.Name;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
