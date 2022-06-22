namespace PaymentGateway.Data.MongoDB.Attributes.Repositories
{
    using global::MongoDB.Driver;
    using PaymentGateway.Data.MongoDB.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;

    public class BaseRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> collection;

        public BaseRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        public Task InsertOneAsync(TDocument document)
        {
            return this.collection.InsertOneAsync(SetCreatedAt(document));
        }

        public Task InsertManyAsync(IEnumerable<TDocument> documents)
        {
            return this.collection.InsertManyAsync(SetCreatedAt(documents));
        }

        public async Task<List<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter)
        {
            var list = await this.collection.FindAsync(filter);
            return list.ToList();
        }

        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter)
        {
            var list = await this.collection.FindAsync(filter);
            return list.FirstOrDefault();
        }

        public async Task<TDocument> FindByIdAsync(Guid id)
        {
            var list = await this.collection.FindAsync(x => x.Id == id).ConfigureAwait(false);
            return list.FirstOrDefault();
        }

        public Task ReplaceOneAsync(TDocument document)
        {
            return this.collection.FindOneAndReplaceAsync(x => x.Id == document.Id, SetUpdatedAt(document));
        }

        public Task UpsertAsync(TDocument document)
        {
            var options = new FindOneAndReplaceOptions<TDocument> { IsUpsert = true };
            return this.collection.FindOneAndReplaceAsync<TDocument>(x => x.Id == document.Id, SetCreatedUpdatedAt(document), options);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter)
        {
            return this.collection.FindOneAndDeleteAsync(filter);
        }

        public Task DeleteByIdAsync(Guid id)
        {
            return this.collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filter)
        {
            return this.collection.DeleteManyAsync(filter);
        }

        public IQueryable<TDocument> AsQueryable()
        {
            return this.collection.AsQueryable();
        }

        private static string GetCollectionName(ICustomAttributeProvider documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                                                         .FirstOrDefault())?.CollectionName;
        }

        private static TDocument SetCreatedAt(TDocument document, DateTimeOffset createdAt)
        {
            var updatedDocument = document;
            document.CreatedAt = createdAt;
            return updatedDocument;
        }

        private static TDocument SetCreatedAt(TDocument document)
        {
            return SetCreatedAt(document, DateTimeOffset.UtcNow);
        }

        private static IEnumerable<TDocument> SetCreatedAt(IEnumerable<TDocument> documents)
        {
            var createdAt = DateTimeOffset.UtcNow;
            return documents.Select(document => SetCreatedAt(document, createdAt));
        }

        private static TDocument SetUpdatedAt(TDocument document)
        {
            var updatedDocument = document;
            document.UpdatedAt = DateTimeOffset.UtcNow;
            return updatedDocument;
        }

        private static TDocument SetCreatedUpdatedAt(TDocument document)
        {
            var updatedDocument = document;
            updatedDocument = document.CreatedAt == DateTimeOffset.MinValue ? SetCreatedAt(updatedDocument) : SetUpdatedAt(updatedDocument);

            return updatedDocument;
        }
    }
}
