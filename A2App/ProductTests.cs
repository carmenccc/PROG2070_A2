using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace A2App
{
    internal class ProductTests
    {
        /* Total amount of tests = 18
         *  --> + 3 tests per product attribute (3*4 = 12)
         *  --> + 3 tests per stock increase methods (3*2 = 6)
         *  
         *  Written Tests distribution
         *  Elowynne Xiong
         *      - Product ID Tests (3)
         *      - Product Name Tests (3)
         *  Annlin Padammattumel George
         *      -DecreaseStock Tests(3)
         *      -IncreaseStock Tests(3)
         *  Huiwen Cai
         *      - ItemPrice Tests (3): 
         *          [Test cases]: valid input/input below minimum value/input above max value
         *          [Why]: the ItemPrice setter validates for a value range within 7-7000,
         *                 and the constructor populate the field using the property constructor,
         *                 these tests are essential to ensure the product constructor works properly
         *                 at each innitiation.
         *      - StockAmount Tests (3)
         *          [Test cases]: valid input/input below minimum value/input above max value
         *          [Why]: the StockAmount setter validates for a value range within 7-70,000,
         *                 and the constructor populate the field using the property constructor,
         *                 these tests are essential to ensure the product constructor works properly
         *                 at each innitiation. 
         */
    }

    [TestFixture]
    public class TestingProductID
    {
        [Test]
        public void ValidProductID_Input7andTShirtand12and500_OutputValidProductID()
        {
            //Arrange
            int _productID = 7;
            string _productName = "TShirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            
            //Act
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);


            //Assert
            Assert.That(testProduct.ProdID, Is.EqualTo(7));
        }

        [Test]
        public void ValidProductID_Input6andTShirtand12_ThrowsException()
        {
            //Arrange
            int _productID = 6;
            string _productName = "TShirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            ArgumentOutOfRangeException error = null;

            //Act
            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }catch (ArgumentOutOfRangeException e)
            {
                error = e;
            }
            

            //Assert
            Assert.That(error.ParamName, Is.EqualTo("ProdID"));
        }

        [Test]
        public void ValidProductID_Input70001andTShirtand12_ThrowsException()
        {
            //Arrange
            int _productID = 70001;
            string _productName = "TShirt";
            decimal _productPrice = 12;
            int _productStock = 500;

            ArgumentOutOfRangeException error = null;

            //Act
            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }
            catch (ArgumentOutOfRangeException e)
            {
                error = e;
            }


            //Assert
            Assert.That(error.ParamName, Is.EqualTo("ProdID"));
        }
    }

    [TestFixture]
    public class TestingProductName
    {
        [Test]
        public void ValidProductName_Input10andTShirtand12and500_ValidProductName()
        {
            //Arrange
            int _productID = 10;
            string _productName = "TShirt";
            decimal _productPrice = 12;
            int _productStock = 500;

            //Act
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);

            //Assert
            Assert.That(testProduct.ProdName, Is.EqualTo("TShirt"));
        }

        [Test]
        public void ValidProductName_Input10andNULLand12and500_ThrowsException()
        {
            //Arrange
            int _productID = 10;
            string _productName = "";
            decimal _productPrice = 12;
            int _productStock = 500;
            ArgumentException error = null;

            //Act
            try
            {
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }catch(ArgumentException e)
            {
                error = e;
            }

            //Assert
            Assert.That(error, Is.Not.Null);
            Assert.That(error.ParamName, Is.EqualTo("ProdName"));
        }

        [Test]
        public void ValidProductName_Input10andEmptySpaceand12and500_ValidProductName()
        {
            //Arrange
            int _productID = 10;
            string _productName = "     ";
            decimal _productPrice = 12;
            int _productStock = 500;
            ArgumentException error = null;

            //Act
            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }
            catch (ArgumentException e)
            {
                error = e;
            }

            //Assert
            Assert.That(error, Is.Not.Null);
            Assert.That(error.ParamName, Is.EqualTo("ProdName"));
        }
    }

    // ------------------- Tests for ItemPrice -------------------
    [TestFixture]
    public class TestingItemPrice
    {
        [Test]
        public void ItemPrice_InputValidValue1000_OutputValidItemPrice()
        {
            // Arrange & Act
            Product testProduct = new Product(10, "pen", 1000, 500);

            // Assert
            Assert.That(testProduct.ItemPrice, Is.EqualTo(1000));
        }

        [Test]
        public void ItemPrice_InputBelowMinValue6_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Pen";
            decimal _productPrice = 6;
            int _productStock = 500;

            // Act
            ArgumentOutOfRangeException error = null;

            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }
            catch (ArgumentOutOfRangeException e)
            {
                error = e;
            }

            // Assert
            Assert.That(error, Is.Not.Null);  // Corrected here
            Assert.That(error.ParamName, Is.EqualTo("ItemPrice"));
        }

        [Test]
        public void ItemPrice_InputAboveMaxValue7001_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Pen";
            decimal _productPrice = 7001;
            int _productStock = 500;

            // Act
            ArgumentOutOfRangeException error = null;

            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }
            catch (ArgumentOutOfRangeException e)
            {
                error = e;
            }

            // Assert
            Assert.That(error, Is.Not.Null);  // Corrected here
            Assert.That(error.ParamName, Is.EqualTo("ItemPrice"));
        }
    }

    // ------------------- Tests for StockAmount -------------------
    [TestFixture]
    public class TestingStockAmount
    {
        [Test]
        public void StockAmount_SetValidValue50000_DoesNotThrow()
        {
            // Arrange & Act
            var product = new Product(100, "Laptop", 500, 50000);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(50000));
        }

        [Test]
        public void StockAmount_InputBelowMinValue6_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Arrange
            int _productID = 10;
            string _productName = "Pen";
            decimal _productPrice = 500;
            int _productStock = 6;
            ArgumentOutOfRangeException error = null;

            // Act
            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }
            catch (ArgumentOutOfRangeException e)
            {
                error = e;
            }

            // Assert
            Assert.That(error, Is.Not.Null);
            Assert.That(error.ParamName, Is.EqualTo("StockAmount"));
        }

        [Test]
        public void StockAmount_InputAboveMaxValue6_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Arrange
            int _productID = 10;
            string _productName = "Pen";
            decimal _productPrice = 500;
            int _productStock = 700001;
            ArgumentOutOfRangeException error = null;

            // Act
            try
            {
                Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            }
            catch (ArgumentOutOfRangeException e)
            {
                error = e;
            }

            // Assert
            Assert.That(error, Is.Not.Null);
            Assert.That(error.ParamName, Is.EqualTo("StockAmount"));
        }
    }

    // ------------------- Tests for DecreaseStock -------------------
    [TestFixture]
    public class TestsForDecreaseStock
    {
        [Test]
        public void DecreaseStock_DecreaseAmountInput_Negetive1()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Tshirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            int _decreaseStockValue = -1;
            string actual = "";
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Invalid amount input.";
            // act
            try
            {
                testProduct.DecreaseStock(_decreaseStockValue);

            }
            catch (Exception ex)
            { 
            actual = ex.Message;
            }
            // Assert
            Assert.That (actual, Is.EqualTo(expected));
        }
        [Test]
        public void DecreaseStock_DecreaseAmountInput_700()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Tshirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            int _decreaseStockValue = 700;
            string actual = "";
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "The amount exists current stocking!";
            // act
            try
            {
                testProduct.DecreaseStock(_decreaseStockValue);

            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void DecreaseStock_DecreaseAmountInput_400()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Tshirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            int _decreaseStockValue = 400;
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            int expected = 100 ;
            // act
            testProduct.DecreaseStock(_decreaseStockValue);
            int actual = testProduct.StockAmount;
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
    // ------------------- Tests for IncreaseStock -------------------

    [TestFixture]
    public class TestsForIncreaseStock
    {
        [Test]
        public void IncreaseStock_IncreaseAmountInput_Negetive1()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Tshirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            int _increaseStockValue = -1;
            string actual = "";
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Invalid amount input.";
            // act
            try
            {
                testProduct.IncreaseStock(_increaseStockValue);

            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void IncreaseStock_IncreaseAmountInput_700()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Tshirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            int _increaseStockValue = 700;
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            int expected = 1200;
            // act
            testProduct.IncreaseStock(_increaseStockValue);
            int actual = testProduct.StockAmount;
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void IncreaseStock_IncreaseAmountInput_Zero()
        {
            // Arrange
            int _productID = 10;
            string _productName = "Tshirt";
            decimal _productPrice = 12;
            int _productStock = 500;
            int _increaseStockValue = 0;
            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            int expected = 500;
            // act
            testProduct.IncreaseStock(_increaseStockValue);
            int actual = testProduct.StockAmount;
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}
