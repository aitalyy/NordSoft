﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KinoSoft
{
    class LogicDisk
    {
        Contex My = new Contex();
        public void AddDisk(string name, string format, int copy, int cost)
        {
            Disk disk = new Disk
            {
                Name = name,
                cost = cost,
                format = format,
                copy = copy
            };

            My.Disks.Add(disk);
            My.SaveChanges();
        }
    }
}