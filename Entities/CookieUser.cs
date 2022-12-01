using System.ComponentModel.DataAnnotations;

namespace CookieReader.Entities
{
    public class CookieUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
