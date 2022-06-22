namespace PaymentGateway.Data.MongoDB.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class BsonCollectionAttribute : Attribute
    {
        public BsonCollectionAttribute(string collectionName)
        {
            this.CollectionName = collectionName;
        }

        public string CollectionName { get; }
    }
}
