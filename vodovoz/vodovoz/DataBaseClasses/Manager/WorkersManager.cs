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
        public void AddWorker(WorkerModel worker)
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

        public void UpdateWorker(WorkerModel worker)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var result = db.Workers.SingleOrDefault(w => w.Id == worker.Id);

                    result = worker.CloneWithoutId(result);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public WorkerModel GetWorker(int id)
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

        public ObservableCollection<WorkerModel> GetWorkers()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return new ObservableCollection<WorkerModel>(db.Set<WorkerModel>());
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
