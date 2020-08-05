using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using vodovoz.Base;
using vodovoz.DataBaseClasses.Manager;
using vodovoz.Models;
using vodovoz.Views;

namespace vodovoz.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private OrderModel _order;
        public OrderModel Order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                    RaisePropertyChanged(nameof(Order));
                }
            }
        }
        public ObservableCollection<WorkerModel> Workers { get; set; }
        public int SelectedWorker { get; set; }

        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public delegate void UpdateOrder(OrderModel order);
        public event UpdateOrder AddOrderEvent;
        public event UpdateOrder UpdateOrderEvent;

        public OrderViewModel(OrderModel order)
        {
            OkCommand = new RelayCommand(DoOk);
            CancelCommand = new RelayCommand(DoCancel);

            SelectedWorker = -1;
            Workers = new WorkersManager().GetWorkers();

            if (order == null)
            {
                Order = new OrderModel();
            }
            else
            {
                Order = order.Clone();
                SelectedWorker = Workers.IndexOf(Workers.Where(w => w.Id == order.Worker).FirstOrDefault());
            }
        }

        private void DoOk(object obj)
        {
            if(SelectedWorker>-1)
                Order.Worker = Workers[SelectedWorker].Id;
            try
            {
                if (Order.Id == 0)
                {
                    new OrdersManager().AddOrder(Order);
                    AddOrderEvent(Order);
                }
                else
                {
                    new OrdersManager().UpdateOrder(Order);
                    UpdateOrderEvent(Order);
                }
                MessageBox.Show("Данные обновлены");
            }
            catch { MessageBox.Show("Ошибка"); }
        }

        private void DoCancel(object obj)
        {
            (obj as Window).Close();
        }
    }
}
