using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vodovoz.Models
{
    [Table("Departments")]
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Supervisor { get; set; }

        public DepartmentModel() { }

        public DepartmentModel(string name, int supervisor)
        {
            Name = name;
            Supervisor = supervisor;
        }

        public DepartmentModel Clone()
        {
            return new DepartmentModel { Id = this.Id, Name = this.Name, Supervisor = this.Supervisor };
        }

        public DepartmentModel CloneWithoutId(DepartmentModel department)
        {
            department.Name = this.Name;
            department.Supervisor = this.Supervisor;
            return department;
        }
    }
}
