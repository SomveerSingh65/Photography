namespace Photography.Models
{
    public class MediaModel
    {
        public int MediaId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }  // "Photo" or "Video"
        public int BookingId { get; set; }
        public BookingModel Booking { get; set; }
    }
}
