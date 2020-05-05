using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using vodovoz.Models;

namespace vodovoz.DataBaseClasses.Manager
{
    public class DepartmentsManager
    {
        public int AddDepartment(Department department)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                    return department.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var result = db.Departments.SingleOrDefault(d => d.Id == department.Id);

                    result = department.CloneWithoutId(result);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public Department GetDepartment(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Departments.FirstOrDefault(department => department.Id == id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ObservableCollection<Department> GetDepartments()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return new ObservableCollection<Department>(db.Set<Department>());
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
