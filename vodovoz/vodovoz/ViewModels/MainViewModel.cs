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
        public ObservableCollection<Worker> Workers { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public RelayCommand OpenWorkerCommand { get; private set; }
        public RelayCommand NewWorkerCommand { get; private set; }
        public RelayCommand OpenDepartmentCommand { get; private set; }
        public RelayCommand NewDepartmentCommand { get; private set; }
        public RelayCommand OpenOrderCommand { get; private set; }
        public RelayCommand NewOrderCommand { get; private set; }

        public MainViewModel()
        {
            OpenWorkerCommand = new RelayCommand(DoOpenWorkerView);
            NewWorkerCommand = new RelayCommand(DoNewWorkerView);
            OpenDepartmentCommand = new RelayCommand(DoOpenDepartmentView);
            NewDepartmentCommand = new RelayCommand(DoNewDepartmentView);
            OpenOrderCommand = new RelayCommand(DoOpenOrderView);
            NewOrderCommand = new RelayCommand(DoNewOrderView);

            UpdateWorkers();
            UpdateDepartments();
            UpdateOrders();
        }

        private void DoNewOrderView(object obj)
        {
            OrderViewModel ovm = new OrderViewModel(null);
            ovm.AddOrderEvent += AddOrder;
            ovm.ShowView();
        }

        private void DoOpenOrderView(object obj)
        {
            if (obj == null)
                return;
            OrderViewModel ovm = new OrderViewModel((Order)obj);
            ovm.UpdateOrderEvent += UpdateOrder;
            ovm.ShowView();
        }

        private void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        private void UpdateOrder(Order order)
        {
            int index = Orders.IndexOf(Orders.FirstOrDefault(d => d.Id == order.Id));
            Orders[index] = (Order)order.Clone();
        }

        private void DoNewDepartmentView(object obj)
        {
            DepartmentViewModel dvm = new DepartmentViewModel(null);
            dvm.AddDepartmentEvent += AddDepartment;
            dvm.ShowView();
        }

        private void DoOpenDepartmentView(object obj)
        {
            if (obj == null)
                return;
            DepartmentViewModel dvm = new DepartmentViewModel((Department)obj);
            dvm.UpdateDepartmentEvent += UpdateDepartment;
            dvm.ShowView();
        }

        private void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        private void UpdateDepartment(Department department)
        {
            int index = Departments.IndexOf(Departments.FirstOrDefault(d => d.Id == department.Id));
            Departments[index] = (Department)department.Clone();
            UpdateWorkers();
        }

        private void DoNewWorkerView(object obj)
        {
            WorkerViewModel wvm = new WorkerViewModel(null);
            wvm.AddWorkerEvent += AddWorker;
            wvm.ShowView();
        }

        private void DoOpenWorkerView(object obj)
        {
            if (obj == null)
                return;
            WorkerViewModel wvm = new WorkerViewModel((Worker)obj);
            wvm.UpdateWorkerEvent += UpdateWorker;
            wvm.ShowView();
        }

        private void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        private void UpdateWorker(Worker worker)
        {
            int index = Workers.IndexOf(Workers.FirstOrDefault(w => w.Id == worker.Id));
            Workers[index] = (Worker)worker.Clone();
            UpdateDepartments();
            UpdateOrders();
        }

        private void UpdateWorkers()
        {
            Workers = new WorkersManager().GetWorkers();
            RaisePropertyChanged(nameof(Workers));

        }

        private void UpdateDepartments()
        {
            Departments = new DepartmentsManager().GetDepartments();
            RaisePropertyChanged(nameof(Departments));
        }

        private void UpdateOrders()
        {
            Orders = new OrdersManager().GetOrders();
            RaisePropertyChanged(nameof(Orders));
        }
    }
}
