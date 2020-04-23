using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoSoft.FormsOrder
{
    class LogicOrder
    {
        Contex My = new Contex();
        void AddOrder(DateTime date, DateTime endDate, OrderStatus status)
        {
            var lastId = My.Clients.OrderByDescending(k => k.Id).FirstOrDefault();
            Client client = My.Clients.Where(k => k.Id == lastId.Id).FirstOrDefault();

            My.Orders.Add(new Order
            {
                Client = client,
                ClientId = lastId.Id,
                Date = date,
                EndDate = endDate,
                Status = status
            });

            My.SaveChanges();
        }
    }
}
