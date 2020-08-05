using System;

namespace vodovoz.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Supervisor { get; set; }

        public Department() { }

        public Department(string name, int supervisor)
        {
            Name = name;
            Supervisor = supervisor;
        }

        public Department Clone()
        {
            return new Department { Id = this.Id, Name = this.Name, Supervisor = this.Supervisor };
        }

        public Department CloneWithoutId(Department department)
        {
            department.Name = this.Name;
            department.Supervisor = this.Supervisor;
            return department;
        }
    }
}
