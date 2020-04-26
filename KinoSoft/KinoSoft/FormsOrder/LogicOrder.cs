﻿using System;
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
            Client client = My.Clients.Where(k => k.Id == idClient).FirstOrDefault();

            My.Orders.Add(new Order
            {
                Client = client,
                ClientId = idClient,
                Date = date,
                EndDate = endDate,
                Status = OrderStatus.Open,
                Cost = cost
            });

            My.SaveChanges();

            

            for (int i=0; i<2; i++)
            {
                int diskId = Convert.ToInt32(arrayDisk[i]);
                Disk disk = My.Disks.Where(k => k.Id == diskId).FirstOrDefault();
                DiskOrder diskOrder = new DiskOrder//add DiskOrder
                {
                    Disk = disk,
                    DiskId = diskId,
                    Order = My.Orders.Where(k => k.Id == idOrder).FirstOrDefault(),
                    OrderId = idOrder,
                };

                var order = new Order();
                order.Disks = new Collection<DiskOrder>();
                order.Disks.Add(diskOrder);

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
