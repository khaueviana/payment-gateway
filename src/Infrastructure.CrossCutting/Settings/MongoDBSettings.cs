namespace Infrastructure.CrossCutting.Settings
{
    using Infrastructure.CrossCutting.Interfaces;

    public class MongoDBSettings : IMongoDBSettings
    {
        public string ConnectionString { get; set; }
    }
}
