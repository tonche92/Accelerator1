using System;
using System.Collections.Generic;

namespace Accelerator1.Model;

public partial class UrlRedirection
{
    public int Id { get; set; }

    public string? ShortUrl { get; set; }

    public string? Website { get; set; }
}
