using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbCourse> TbCourses { get; set; } = new List<TbCourse>();
}
