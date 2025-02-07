using System;
using System.Collections.Generic;

#nullable disable

namespace EXE_PROJECT.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
