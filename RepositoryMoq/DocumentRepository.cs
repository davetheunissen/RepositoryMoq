using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMoq
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentById(string documentId);
    }

    public class DocumentRepository : IDocumentRepository
    {
        private static readonly string databaseName = "sample-database";
        private static readonly string collectionName = "sample-collection";
        private static IDocumentClient client;

        public DocumentRepository(IDocumentClient documentClient)
        {
            client = documentClient;
        }

        public virtual async Task<Document> GetDocumentById(string documentId)
        {
            var response = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentId));
            return response.Resource;
        }
    }
}
