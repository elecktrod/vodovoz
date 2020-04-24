using System;

namespace vodovoz.Models
{
    public class Order : ICloneable
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Worker { get; set; }

        public Order() { }

        public Order(int number, string name, int worker) {
            Number = number;
            Name = name;
            Worker = worker;
        }

        public object Clone()
        {
            return new Order { Id = this.Id, Number = this.Number, Name = this.Name, Worker = this.Worker };
        }
    }
}
