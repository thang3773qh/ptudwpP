using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbLesson
{
    public int LessonId { get; set; }

    public int ModuleId { get; set; }

    public string Title { get; set; } = null!;

    public int? Duration { get; set; }

    public string? Type { get; set; }

    public int OrderIndex { get; set; }

    public virtual TbModule Module { get; set; } = null!;
}
