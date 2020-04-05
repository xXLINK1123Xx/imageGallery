namespace Infrastructure.Models
{
    public class Tag
    {
        public string Name { get; set; }
        public TagType Type { get; set; }
        public enum TagType
        {
            Standard = 1,
            Artist,
            Copyright,
            Character
        }
    }
}