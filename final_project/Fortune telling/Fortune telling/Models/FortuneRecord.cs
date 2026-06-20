using System;

namespace Fortune_telling.Models
{
    public class FortuneRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Result { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
