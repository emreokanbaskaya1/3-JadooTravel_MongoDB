namespace JadooTravel.Dtos.FeatureDtos
{
    public class GetFeatureByIdDto
    {
        // ✅ Id VAR
        public string Id { get; set; }
        // ✅ Genellikle TÜM alanlar var (detay sayfası için)
        public string Title { get; set; }
        public string MainTitle { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}
