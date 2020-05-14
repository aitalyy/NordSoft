using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Data.Entity;
using System.ComponentModel;

namespace KinoSoft.FormsOrder
{
    class LogicOrder
    {
        Contex My = new Contex();

        public void AddOrder(DateTime date, DateTime endDate, ArrayList arrayDisk, int idClient, int idOrder, int cost)
        {
            using(Contex My = new Contex())
            {
                Client client = My.Clients.Where(k => k.Id == idClient).FirstOrDefault();
                //var arrayDisk1 = new Collection<DiskOrder>();

                Order order = new Order
                {
                    Id = idOrder,
                    Client = client,
                    ClientId = idClient,
                    Date = date,
                    EndDate = endDate,
                    Status = OrderStatus.Open,
                    Cost = cost,
                    //Disks = arrayDisk1
                };
                My.Orders.Add(order);

                using (Contex db = new Contex())
                {
                    for (int i = 0; i < arrayDisk.Count; i++)
                    {
                        int diskId = Convert.ToInt32(arrayDisk[i]);
                        Disk disk = db.Disks.Where(k => k.Id == diskId).FirstOrDefault();
                        int orderId = order.Id;
                        DiskOrder diskOrder = new DiskOrder//add DiskOrder
                        {
                            Disk = disk,
                            DiskId = diskId,
                            //Order = order,
                            Order = My.Orders.Where(k => k.Id == orderId).FirstOrDefault(),
                            OrderId = orderId,
                        };
                        db.DiskOrders.Add(diskOrder);
                        //arrayDisk1.Add(diskOrder);
                    }
                    //order.Disks = arrayDisk1;
                    db.SaveChanges();
                }
                My.SaveChanges();
                
            }
            
        }

        public void GetListOrder(DataGridView asd)
        {
            My.Disks.Load();
            asd.DataSource = My.Disks.Local.ToBindingList();
            var list = My.Disks;
            
            var result = from a in My.Orders
                         select new
                         {
                             id = a.Id,
                             Имя = a.Client.FirstName,
                             Фамилия = a.Client.LastName,
                             Отчество = a.Client.SecondName,
                             Дата_сдачи = a.Date,
                             Конец_аренды = a.EndDate,
                             Статус = a.Status,
                             Цена = a.Cost
            };
            asd.DataSource = result.ToList();
        }
    }
}
