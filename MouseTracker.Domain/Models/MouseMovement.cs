namespace MouseTracker.Domain.Models
{
    public class MouseMovement
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
