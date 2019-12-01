using System;

namespace Infrastructure.Models
{
    public class Image
    {
        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public Tag[] Tags { get; set; }
        
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public string PreviewFileUrl { get; set; } //using sample file url here
        
        public string FileUrl { get; set; }
        
        public string SourceFileUrl { get; set; }
        
        public string Artist { get; set; }
        
        public string Copyright { get; set; }
        
        public string[] Characters { get; set; }
        
    }
}