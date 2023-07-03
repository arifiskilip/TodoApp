namespace Entities.DTOs
{
    public class UpdateWorkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; } = true;
    }
}
