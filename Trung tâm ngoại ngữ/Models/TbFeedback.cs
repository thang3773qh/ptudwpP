using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbFeedback
{
    public int FeedbackId { get; set; }

    public string FullName { get; set; } = null!;

    public string? JobTitle { get; set; }

    public string? AvatarPath { get; set; }

    public int? Rating { get; set; }

    public string? Content { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool IsActive { get; set; }
}
