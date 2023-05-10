using System;
using System.Collections.Generic;

namespace EFcore.Entities;

public partial class Tag
{
    public string Content { get; set; } = null!;

    public int TagId { get; set; }

    public virtual ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
}
