using Microsoft.Azure.Documents;
using Moq;
using RepositoryMoq;
using System.Threading.Tasks;
using Xunit;

namespace RepositoryMoqTest
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task ProductRepository_GetProductById_ShouldReturnProductDocument()
        {
            var mockDocumentClient = new Mock<IDocumentClient>();
            var mockProductDocument = new Document { Id = "product-12345" };
            var mockProductRepository = new Mock<ProductRepository>(It.IsAny<IDocumentClient>());
            mockProductRepository.Setup(x => x.GetDocumentById(It.IsAny<string>())).ReturnsAsync(mockProductDocument);

            var result = await mockProductRepository.Object.GetProductById("product-12345");

            Assert.NotNull(result);
            Assert.Equal(mockProductDocument.Id, result.Id);
        }
    }
}
