namespace DTO.Entities
{
    public class EBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public EUser Owner { get; set; }
    }
}