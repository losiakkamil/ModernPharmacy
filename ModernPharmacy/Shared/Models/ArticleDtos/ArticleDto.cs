using ModernPharmacy.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPharmacy.Shared.Models.ArticleDtos
{
    public class ArticleDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public int ParentId { get; set; } = 0;
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public string PagePath { get; set; } = string.Empty;
    }
}
