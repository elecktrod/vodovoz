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
        private DepartmentModel _department;
        public DepartmentModel Department
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

        public ObservableCollection<WorkerModel> Supervisors { get; set; }
        public int SelectedSupervisor { get; set; }

        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public delegate void UpdateDepartment(DepartmentModel department);
        public event UpdateDepartment AddDepartmentEvent;
        public event UpdateDepartment UpdateDepartmentEvent;

        public DepartmentViewModel(DepartmentModel department)
        {
            OkCommand = new RelayCommand(DoOk);
            CancelCommand = new RelayCommand(DoCancel);

            SelectedSupervisor = -1;
            Supervisors = new WorkersManager().GetWorkers();

            if (department == null)
            {
                Department = new DepartmentModel();
            }
            else
            {
                Department = department.Clone();
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
            (obj as Window).Close();
        }

    }
}
