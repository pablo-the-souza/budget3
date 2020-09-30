using System;

namespace Core.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value {get; set; }
        public DateTime Date {get; set; }
        public int CategoryId {get; set; }
        public Category Category { get; set; }
        public int Type {get; set; }
    }
}