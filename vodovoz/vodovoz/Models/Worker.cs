using System;

namespace vodovoz.Models
{
    public class Worker : ICloneable
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Sex { get; set; }
        public int Department { get; set; }

        public Worker() { }

        public Worker(string surname, string name, string patronymic, DateTime birthday, Sex sex, int department)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
            Sex = sex;
            Department = department;
        }

        public object Clone()
        {
            return new Worker { Id = this.Id, Surname = this.Surname, Name = this.Name, 
                Patronymic = this.Patronymic, Birthday = this.Birthday, Sex = this.Sex, Department = this.Department };
        }
    }
}
