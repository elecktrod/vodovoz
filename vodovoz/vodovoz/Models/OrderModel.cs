using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vodovoz.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Worker { get; set; }

        public OrderModel() { }

        public OrderModel(int number, string name, int worker) {
            Number = number;
            Name = name;
            Worker = worker;
        }

        public OrderModel Clone()
        {
            return new OrderModel { Id = this.Id, Number = this.Number, Name = this.Name, Worker = this.Worker };
        }

        public OrderModel CloneWithoutId(OrderModel order)
        {
            order.Number = this.Number;
            order.Name = this.Name;
            order.Worker = this.Worker;
            return order;
        }
    }
}
