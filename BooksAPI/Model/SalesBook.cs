using System;

namespace BooksAPI.Model
{
    public class SalesBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CostumerId { get; set; }
        public DateTime SalesDate { get; set; }
        public virtual Book Book{get;set;}
        public virtual Costumer Costumer { get; set; }
    }
}
