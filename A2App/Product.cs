using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2App
{
    public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount = 0)
        {
            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        // Methods
        public void IncreaseStock(int increaseAmount)
        {
            if (increaseAmount < 0)
            {
                throw new ArgumentException("Invalid amount input.");
            }
            StockAmount += increaseAmount;
        }

        public void DecreaseStock(int decreaseAmount)
        {
            if (decreaseAmount < 0)
            {
                throw new ArgumentException("Invalid amount input.");
            }

            if (decreaseAmount > StockAmount)
            {
                throw new ArgumentException("The amount exists current stocking!");
            }

            StockAmount -= decreaseAmount;
        }
    }
}
