namespace WNBOT.Classes.DTO.SavedStream
{
    public class SavedStreamDTO
    {
        public required int savedStreamId { get; set; }
        public required string streamKey { get; set; }
        public required float startTime { get; set; }
        public required int viewers { get; set; }
        public required string category { get; set; }
        public required int sellerId { get; set; }
    }
}