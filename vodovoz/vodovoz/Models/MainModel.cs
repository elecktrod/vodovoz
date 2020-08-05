using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using vodovoz.DataBaseClasses.Manager;

namespace vodovoz.Models
{
    public class MainModel
    {
        public ObservableCollection<Worker> Workers { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public MainModel()
        {
            UpdateWorkers();
            UpdateDepartments();
            UpdateOrders();
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            int index = Departments.IndexOf(Departments.FirstOrDefault(d => d.Id == department.Id));
            Departments[index] = department.Clone();
            UpdateWorkers();
        }

        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public void UpdateWorker(Worker worker)
        {
            int index = Workers.IndexOf(Workers.FirstOrDefault(w => w.Id == worker.Id));
            Workers[index] = worker.Clone();
            UpdateDepartments();
            UpdateOrders();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            int index = Orders.IndexOf(Orders.FirstOrDefault(d => d.Id == order.Id));
            Orders[index] = order.Clone();
        }

        public void UpdateWorkers()
        {
            Workers = new WorkersManager().GetWorkers();
        }

        public void UpdateDepartments()
        {
            Departments = new DepartmentsManager().GetDepartments();
        }

        public void UpdateOrders()
        {
            Orders = new OrdersManager().GetOrders();
        }

    }
}
