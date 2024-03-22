using System.Text.Json.Serialization;

namespace ItransitionMVC.Models
{
    public class CustomCollectionItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CollectionId { get; set; }
        public CustomCollection Collection { get; set; }
        public List<Tag>? Tags { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Like>? Likes { get; set; }

        
        public bool Custom_string1_state { get; set; } = false;
        public string? Custom_string1_name { get; set; } = null;
        public bool Custom_string2_state { get; set; } = false;
        public string? Custom_string2_name { get; set; } = null;
        public bool Custom_string3_state { get; set; } = false;
        public string? Custom_string3_name { get; set; } = null;
        public bool Custom_int1_state { get; set; } = false;
        public int? Custom_int1_name { get; set; }
        public bool Custom_int2_state { get; set; } = false;
        public int? Custom_int2_name { get; set; }
        public bool Custom_int3_state { get; set; } = false;
        public int? Custom_int3_name { get; set; }
        public bool Custom_chekbox1_state { get; set; } = false;
        public bool Custom_chekbox1_name { get; set; } = false;
        public bool Custom_chekbox2_state { get; set; } = false;
        public bool Custom_chekbox2_name { get; set; } = false;
        public bool Custom_chekbox3_state { get; set; } = false;
        public bool Custom_chekbox3_name { get; set; } = false;

        
    }
}
