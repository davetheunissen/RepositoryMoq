using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMoq
{
    public interface IProductRepository : IDocumentRepository
    {
        Task<Document> GetProductById(string productId);
    }

    public class ProductRepository : DocumentRepository, IProductRepository
    {
        public ProductRepository(IDocumentClient client)
            : base(client)
        { }

        public async Task<Document> GetProductById(string productId)
        {
            if(string.IsNullOrEmpty(productId))
                throw new ArgumentNullException("productId cannot be null or empty");

            return await GetDocumentById(productId);
        }
    }
}
