using NUnit.Framework;
using SeleniumFullTutorial.Model;
using System;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class AddProductTests : AuthTestBase
    {
        [Test]
        public void AddNewProductTest()
        {
            ProductData prodouct = new ProductData()
            {
                Name = GenerateRandomString(10),
                Code = GenerateRandomString(3),
                Images = "black_duck.jpg",
                Manufacturer = "ACME Corp.",
                ShortDescription = GenerateRandomString(10),
                Description = GenerateRandomString(30),
                Quantity = GenerateRandomString(2, true),
                DateValidFrom = GenerateRandomDate(),
                PurchasePrice = GenerateRandomString(2, true)
            };
            prodouct.DateValidTo = GenerateRandomDate(prodouct.DateValidFrom);

            app.Navigator.GoToAdminCatalogPage();
            app.AddProduct.CreateNewProduct(prodouct);
            bool result = app.AddProduct.ShowInList(prodouct.Name);
            Console.WriteLine($"{result} - {prodouct.Name}");
        }
    }
}
