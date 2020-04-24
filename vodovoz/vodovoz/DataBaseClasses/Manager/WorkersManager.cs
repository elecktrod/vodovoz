using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vodovoz.Models;

namespace vodovoz.DataBaseClasses.Manager
{
    public class WorkersManager
    {
        public void AddWorker(Worker worker)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Workers.Add(worker);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdateWorker(Worker worker)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var result = db.Workers.SingleOrDefault(w => w.Id == worker.Id);

                    result.Name = worker.Name;
                    result.Surname = worker.Surname;
                    result.Patronymic = worker.Patronymic;
                    result.Sex = worker.Sex;
                    result.Birthday = worker.Birthday;
                    result.Department = worker.Department;

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public Worker GetWorker(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Workers.FirstOrDefault(worker => worker.Id == id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ObservableCollection<Worker> GetWorkers()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return new ObservableCollection<Worker>(db.Set<Worker>());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
