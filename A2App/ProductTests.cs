using NUnit.Framework;

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

            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Product ID is VALID";

            //Act
            string actual = Product.ValidProductID(testProduct);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void ValidProductID_Input6andTShirtand12_OutputValidProductID()
        {
            //Arrange
            int _productID = 6;
            string _productName = "TShirt";
            decimal _productPrice = 12;
            int _productStock = 500;

            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Product ID is NOT VALID";

            //Act
            string actual = Product.ValidProductID(testProduct);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void ValidProductID_Input70001andTShirtand12_OutputValidProductID()
        {
            //Arrange
            int _productID = 70001;
            string _productName = "TShirt";
            decimal _productPrice = 12;
            int _productStock = 500;

            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Product ID is NOT VALID";

            //Act
            string actual = Product.ValidProductID(testProduct);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
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

            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Product name is VALID";

            //Act
            string actual = Product.ValidProductName(testProduct);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void ValidProductName_Input10andNULLand12and500_ValidProductName()
        {
            //Arrange
            int _productID = 10;
            string _productName = "";
            decimal _productPrice = 12;
            int _productStock = 500;

            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Product name is NOT VALID";

            //Act
            string actual = Product.ValidProductName(testProduct);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void ValidProductName_Input10andEmptySpaceand12and500_ValidProductName()
        {
            //Arrange
            int _productID = 10;
            string _productName = "     ";
            decimal _productPrice = 12;
            int _productStock = 500;

            Product testProduct = new Product(_productID, _productName, _productPrice, _productStock);
            string expected = "Product name is NOT VALID";

            //Act
            string actual = Product.ValidProductName(testProduct);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
