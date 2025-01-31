using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2App
{
    public class Product
    {
        public int ProdID { get; set; } //7 - 70,000
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; } //$7 - 7000
        public int StockAmount { get; set; } //7 - 700,000

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

        public static string ValidProductID(Product product)
        {
            string result;

            if (product.ProdID >= 7 && product.ProdID <= 70000)
            {
                result = "Product ID is VALID";
            }
            else
            {
                result = "Product ID is NOT VALID";
            }

            return result;
        }

        public static string ValidProductName(Product product)
        {
            string result;

            if ((product.ProdName != null) && (product.ProdName.Length > 0) && (product.ProdName.Replace(" ", string.Empty) != string.Empty))
            {
                result = "Product name is VALID";
            }
            else
            {
                result = "Product name is NOT VALID";
            }

            return result;
        }
    }
}
