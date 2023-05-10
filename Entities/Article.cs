using System;
using System.Collections.Generic;

namespace EFcore.Entities;

public partial class Article
{
    public int ArticleId { get; set; }

    public string Name { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
}
