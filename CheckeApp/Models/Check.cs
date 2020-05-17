using System;

namespace CheckeApp.Models
{
    public class Check
    {
        public int Id { get; set; } 
        public decimal Amount { get; set; }
        public string AmountInWords { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateCreated { get; set; }
    }
}   