using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using vodovoz.Base;
using vodovoz.DataBaseClasses.Manager;
using vodovoz.Models;
using vodovoz.Views;

namespace vodovoz.ViewModels
{
    public class DepartmentViewModel : BaseViewModel
    {
        private DepartmentView _view;

        private Department _department;
        public Department Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    RaisePropertyChanged(nameof(Department));
                }
            }
        }

        public ObservableCollection<Worker> Supervisors { get; set; }
        public int SelectedSupervisor { get; set; }

        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public delegate void UpdateDepartment(Department department);
        public event UpdateDepartment AddDepartmentEvent;
        public event UpdateDepartment UpdateDepartmentEvent;

        public DepartmentViewModel(Department department)
        {
            _view = new DepartmentView();
            _view.DataContext = this;

            OkCommand = new RelayCommand(DoOk);
            CancelCommand = new RelayCommand(DoCancel);

            SelectedSupervisor = -1;
            Supervisors = new WorkersManager().GetWorkers();

            if (department == null)
            {
                Department = new Department();
            }
            else
            {
                Department = (Department)department.Clone();
                SelectedSupervisor = Supervisors.IndexOf(Supervisors.Where(s => s.Id == department.Supervisor).FirstOrDefault());
            }
        }

        private void DoOk(object obj)
        {
            if(SelectedSupervisor>-1)
                Department.Supervisor = Supervisors[SelectedSupervisor].Id;
            try
            {
                if (Department.Id == 0)
                {
                    new DepartmentsManager().AddDepartment(Department);
                    AddDepartmentEvent(Department);
                }
                else
                {
                    new DepartmentsManager().UpdateDepartment(Department);
                    UpdateDepartmentEvent(Department);
                }
                MessageBox.Show("Данные обновлены");
            }
            catch { MessageBox.Show("Ошибка"); }
        }

        private void DoCancel(object obj)
        {
            _view.Close();
        }

        public void ShowView()
        {
            _view.ShowDialog();
        }
    }
}
