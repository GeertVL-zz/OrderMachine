using System.Data;
using System.Data.SqlClient;
using FakeItEasy;
using Xunit;
using OrderMachine.Data;

namespace OrderMachine.Tests
{
    [Trait("Category", "SqlReaderHelper")]
    public class SqlReaderHelperTests
    {

        [Fact(DisplayName = "Check if you can read values")]
        public void SpecificationName()
        {
            var connection = A.Fake<IDbConnection>();
            var command = connection.CreateCommand();
            var reader = command.ExecuteReader();
            A.CallTo(() => reader["name"]).Returns("test");
            A.CallTo(() => reader["description"]).Returns("test");
            var product = new Product
            {
                Name = reader.Q<string>("name"),
                Description = reader.Q<string>("description")
            };

            Assert.Equal(product.Name, "test");
        }
    }
}
