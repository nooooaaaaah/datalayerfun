namespace WNBOT.Classes.BO.SavedStream
{
    public class SavedStreamBO
    {
        public required int savedStreamId { get; set; }
        public required string streamKey { get; set; }
        public required float startTime { get; set; }
        public required int viewers { get; set; }
        public required string category { get; set; }
        public required int sellerId { get; set; }
    }
}