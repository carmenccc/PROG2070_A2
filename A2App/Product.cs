using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2App
{
    public class Product
    {
        private int _prodID;
        private string _productName;
        private decimal _itemPrice;
        private int _stockAmount;
        public int ProdID //7 - 70,000
        {
            get { return _prodID; }
            set
            {
                if (value < 7 || value > 70000)
                    throw new ArgumentOutOfRangeException(nameof(ProdID), "Product ID is NOT VALID.");
                _prodID = value;
            }
        } 
        
        public string ProdName 
        { 
            get{
                return _productName;
            } 
            set{
                value = value.Trim();
                if (value == null || value.Length == 0 || value == string.Empty)
                {
                    throw new ArgumentException("Product name cannot be empty or whitespace.", nameof(ProdName));
                }
                _productName = value;
            } 
        }
        
        public decimal ItemPrice //$7 - 7000
        {
            get { return _itemPrice; }
            set
            {
                if (value < 7 || value > 7000)
                    throw new ArgumentOutOfRangeException(nameof(ItemPrice), "Item price must be between $7 and $7000.");
                _itemPrice = value;
            }
        }
        
        public int StockAmount  //7 - 700,000
        { 
            get{
                return _stockAmount;
            } set{
                if (value < 7 || value > 700000)
                {
                    throw new ArgumentOutOfRangeException(nameof(StockAmount), "Stock amount must be between 7 and 700,000.");
                }
                _stockAmount = value;
            } 
        }

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
