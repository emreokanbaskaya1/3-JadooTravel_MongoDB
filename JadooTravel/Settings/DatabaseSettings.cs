namespace JadooTravel.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string DatabaseName
        {
            get => Database;
            set => Database = value;
        }
        public string CategoryCollectionName { get; set; }
        public string DestinationCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string TripPlanCollectionName { get; set; }
    }
}
