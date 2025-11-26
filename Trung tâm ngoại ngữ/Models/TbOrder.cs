using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbOrder
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int CourseId { get; set; }

    public decimal Price { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual TbCourse Course { get; set; } = null!;
}
