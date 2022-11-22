using System;

namespace BooksAPI.Dto
{
    public class SalesBookDto
    {
        public int SalesBookId { get; set; }
        public int CostumerId { get; set; }
        public int BookId { get; set; }
        public DateTime SalesDate { get; set; }
        public string TitleBook { get; set; }
        public double PriceBook { get; set; }
        public string CustomerName { get; set; }
        public long CustomerZipCode { get; set; }
        public string CustomerAddress { get; set; }
    }
}
