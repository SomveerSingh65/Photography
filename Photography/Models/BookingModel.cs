using System;

namespace Photography.Models
{
    public class BookingModel
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string PhoographerName {  get; set; }
        public DateTime Date { get; set; }
        public string EventType { get; set; }
        public string Contact { get; set; }
    }
}


    