using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimaUrsova.EF
{
    public partial class Ordersss
    {
        public string Price { get
            {
                string formattedAllSum = string.Format("{0:f2} ₴", AllSum);
                return formattedAllSum;
            }
        }
        public string AllSearch
        {
            get
            {
                return $"{this.CustomerCodeNavigation.CustomerPib} {this.WorkerCodeMasNavigation.WorkerPib} {this.OrdersCode} {this.WorkerCodeMenNavigation.WorkerPib} {this.DateOrder} {this.NameDevice}";
            }
        }
        public string ShortDetails
        {
            get
            {
                if (this.NameDevice == null)
                {
                    return "";
                }
                if (this.NameDevice.Length > 8)
                {
                    return this.NameDevice.Remove(8)+"...";
                }
                return NameDevice;
            }
        }
        public string ShortCustPIB { 
            get
            {
                try
                {
                    var temp = this.CustomerCodeNavigation.CustomerPib.Split(" ");
                    return $"{temp[0]} {temp[1].Remove(1)}.{(temp.Length > 2 ? temp[2].Remove(1) : "")}.";
                }
                catch (Exception)
                {

                    return this.CustomerCodeNavigation.CustomerPib;
                }
               
            }
        }
        public string ShortManagerPIB
        {
            get
            {

                try
                {
                    var temp = this.WorkerCodeMenNavigation.WorkerPib.Split(" ");
                    return $"{temp[0]} {temp[1].Remove(1)}.{(temp.Length > 2 ? temp[2].Remove(1) : "")}.";
                }
                catch (Exception)
                {

                    return this.WorkerCodeMenNavigation.WorkerPib;
                }
              
            }
        }
        public string ShortMasterPIB
        {
            get
            {
                try
                {
                    var temp = this.WorkerCodeMasNavigation.WorkerPib.Split(" ");
                    return $"{temp[0]} {temp[1].Remove(1)}.{(temp.Length > 2 ? temp[2].Remove(1) : "")}.";
                }
                catch (Exception)
                {

                    return this.WorkerCodeMasNavigation.WorkerPib;
                }
    
            }
        }
        public string MapState
        {
            get
            {
                switch (this.Status)
                {
                    case "Виконано":
                        return "✓";
                    case "Активні":
                        return "⌚";
                    case "Виконується":
                        return "🔨";
                    case "На діагностиці":
                        return "🔬";
                    default:
                        return this.Status;
                }
            }
        }
    }
    public partial class _123Context
    {
        public override int SaveChanges()
        {
           
                int result = base.SaveChanges();
                App.Context = new _123Context();
                App.PreLoadBD();
                return result;
           
        }
    }
    public partial class Worker
    {
        public string AllSearch
        {
            get
            {
                return $"{this.WorkerPib} {this.WorkerNumber}";
            }
        }
    }

    public partial class Customer
    {
        public string AllSearch
        {
            get
            {
                return $"{this.CustomerCode} {this.CustomerNomer}";
            }
        }
    }

    public partial class Detail
    {
        public string AllSearch
        {
            get
            {
                return $"{this.NameDetails} {this.CostDetails} {this.CostService}";
            }
        }
    }
    public partial class Login
    {
        public string AllSearch
        {
            get
            {
                return $"{this.Login1}{this.PositionWorker}";
            }
        }
    }


}

