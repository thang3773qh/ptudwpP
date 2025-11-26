using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbEvent
{
    public int EventId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }
}
