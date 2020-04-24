using System;

namespace vodovoz.Models
{
    public class Department : ICloneable
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

        public object Clone()
        {
            return new Department { Id = this.Id, Name = this.Name, Supervisor = this.Supervisor };
        }
    }
}
