namespace AndonWebApi.Entities
{
    public class Display : BaseEntity
    {
        public int OrderId { get; set; }
        public float Duration { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
