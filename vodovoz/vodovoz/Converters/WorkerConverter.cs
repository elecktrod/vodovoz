using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using vodovoz.Models;

namespace vodovoz.Converters
{
    public class WorkerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        int id = (int)values[0];
        ObservableCollection<WorkerModel> workers = values[1] as ObservableCollection<WorkerModel>;
        var worker = workers.Where(d => d.Id == id).FirstOrDefault();
        if (worker == null)
        {
            return "Не выбран";
        }
        return worker.Surname + " " + worker.Name + " " + worker.Patronymic;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}
