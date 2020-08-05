using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using vodovoz.Base;
using vodovoz.DataBaseClasses;
using vodovoz.DataBaseClasses.Manager;
using vodovoz.Models;
using vodovoz.Views;

namespace vodovoz.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand OpenWorkerCommand { get; private set; }
        public RelayCommand NewWorkerCommand { get; private set; }
        public RelayCommand OpenDepartmentCommand { get; private set; }
        public RelayCommand NewDepartmentCommand { get; private set; }
        public RelayCommand OpenOrderCommand { get; private set; }
        public RelayCommand NewOrderCommand { get; private set; }

        public MainModel MainModel { get; set; }

        public MainViewModel()
        {
            MainModel = new MainModel();

            OpenWorkerCommand = new RelayCommand(DoOpenWorkerView);
            NewWorkerCommand = new RelayCommand(DoNewWorkerView);
            OpenDepartmentCommand = new RelayCommand(DoOpenDepartmentView);
            NewDepartmentCommand = new RelayCommand(DoNewDepartmentView);
            OpenOrderCommand = new RelayCommand(DoOpenOrderView);
            NewOrderCommand = new RelayCommand(DoNewOrderView);
        }

        private void DoNewOrderView(object obj)
        {
            OrderViewModel ovm = new OrderViewModel(null);
            ovm.AddOrderEvent += MainModel.AddOrder;
            OrderView oView = new OrderView { DataContext = ovm };
            oView.ShowDialog();
        }

        private void DoOpenOrderView(object obj)
        {
            if (obj == null)
                return;
            OrderViewModel ovm = new OrderViewModel((Order)obj);
            ovm.UpdateOrderEvent += MainModel.UpdateOrder;
            OrderView oView = new OrderView{ DataContext = ovm };
            oView.ShowDialog();
        }

        private void DoNewDepartmentView(object obj)
        {
            DepartmentViewModel dvm = new DepartmentViewModel(null);
            dvm.AddDepartmentEvent += MainModel.AddDepartment;
            DepartmentView dView = new DepartmentView { DataContext = dvm };
            dView.ShowDialog();
        }

        private void DoOpenDepartmentView(object obj)
        {
            if (obj == null)
                return;
            DepartmentViewModel dvm = new DepartmentViewModel((Department)obj);
            dvm.UpdateDepartmentEvent += MainModel.UpdateDepartment;
            DepartmentView dView = new DepartmentView { DataContext = dvm };
            dView.ShowDialog();
        }

        private void DoNewWorkerView(object obj)
        {
            WorkerViewModel wvm = new WorkerViewModel(null);
            wvm.AddWorkerEvent += MainModel.AddWorker;
            WorkerView wView = new WorkerView { DataContext = wvm };
            wView.ShowDialog();
        }

        private void DoOpenWorkerView(object obj)
        {
            if (obj == null)
                return;
            WorkerViewModel wvm = new WorkerViewModel((Worker)obj);
            wvm.UpdateWorkerEvent += MainModel.UpdateWorker;
            WorkerView wView = new WorkerView { DataContext = wvm };
            wView.ShowDialog();
        }   
    }
}
