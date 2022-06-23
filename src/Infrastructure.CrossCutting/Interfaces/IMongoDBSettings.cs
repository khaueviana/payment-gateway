namespace Infrastructure.CrossCutting.Interfaces
{
    public interface IMongoDBSettings
    {
        public string ConnectionString { get; set; }
    }
}
