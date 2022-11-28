using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAid.Models
{
    public class ItemsModel
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public int Priority { get; set; } = 0;

        public ItemsModel()
        {

        }

        public ItemsModel(string name, double price, int priority)
        {
            Name = name;
            Price = price;
            Priority = priority;
        }

        public ItemsModel(string name)
        {
            Name = name;
        }

        public void setPriority(int i)
        {
            this.Priority = i;
        }
    }
}
