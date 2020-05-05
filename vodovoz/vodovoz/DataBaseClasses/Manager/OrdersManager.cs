using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using vodovoz.Models;

namespace vodovoz.DataBaseClasses.Manager
{
    public class OrdersManager
    {
        public int AddOrder(Order order)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return order.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var result = db.Orders.SingleOrDefault(o => o.Id == order.Id);

                    result = order.CloneWithoutId(result);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public Order GetOrder(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Orders.FirstOrDefault(order => order.Id == id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ObservableCollection<Order> GetOrders()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return new ObservableCollection<Order>(db.Set<Order>());
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
