using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace DALTest
{
    public class ProductRepositoryTest
    {
        IRepository<int, Product> _repository;
        [SetUp]
        public void Setup()
        {
            _repository =  new ProductRepository();
        }

        [Test]
        public void AddProductTest()
        {
            //Arrange

            //Action
            var result = _repository.Add(new Product { Id = 100, Name = "Pencil" });
            //Assert
            Assert.IsNotNull(result);
        }
    }
}