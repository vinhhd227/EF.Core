using System;
using System.Collections.Generic;

namespace EFcore.Entities;

public partial class ArticleTag
{
    public int ArticleTagId { get; set; }

    public int TagId { get; set; }

    public int ArticleId { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
