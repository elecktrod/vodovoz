using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using vodovoz.Base;
using vodovoz.DataBaseClasses.Manager;
using vodovoz.Models;
using vodovoz.Views;

namespace vodovoz.ViewModels
{
    public class WorkerViewModel : BaseViewModel
    {
        private WorkerModel _worker;
        public WorkerModel Worker
        {
            get{ return _worker; }
            set { 
                if (_worker != value)
                {
                    _worker = value;
                    RaisePropertyChanged(nameof(Worker));
                }
            }
        }

        public ObservableCollection<DepartmentModel> Departments { get; set; }
        public int SelectedDepartments { get; set; }

        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public delegate void UpdateWorker(WorkerModel worker);
        public event UpdateWorker AddWorkerEvent;
        public event UpdateWorker UpdateWorkerEvent;

        public WorkerViewModel(WorkerModel worker)
        {
            OkCommand = new RelayCommand(DoOk);
            CancelCommand = new RelayCommand(DoCancel);

            SelectedDepartments = -1;
            Departments = new DepartmentsManager().GetDepartments();

            if (worker == null)
            {
                Worker = new WorkerModel();
            }
            else
            {
                Worker = worker.Clone();
                SelectedDepartments = Departments.IndexOf(Departments.Where(x=>x.Id == worker.Department).FirstOrDefault());
            }
        }

        private void DoOk(object obj)
        {
            if(SelectedDepartments>-1)
                Worker.Department = Departments[SelectedDepartments].Id;
            try
            {
                if (Worker.Id == 0)
                {
                    new WorkersManager().AddWorker(Worker);
                    AddWorkerEvent(Worker);
                }
                else
                {
                    new WorkersManager().UpdateWorker(Worker);
                    UpdateWorkerEvent(Worker);
                }
                MessageBox.Show("Данные обновлены");
            }
            catch{ MessageBox.Show("Ошибка"); }
        }

        private void DoCancel(object obj)
        {
            (obj as Window).Close();
        }
    }
}
