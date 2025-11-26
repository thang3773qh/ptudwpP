using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbModule
{
    public int ModuleId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int OrderIndex { get; set; }

    public int? TotalLessons { get; set; }

    public int? TotalDuration { get; set; }

    public virtual TbCourse Course { get; set; } = null!;

    public virtual ICollection<TbLesson> TbLessons { get; set; } = new List<TbLesson>();
}
