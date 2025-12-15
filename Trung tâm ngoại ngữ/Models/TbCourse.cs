using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbCourse
{
    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public int Price { get; set; }

    public int? PriceSale { get; set; }

    public int? ContentHours { get; set; }

    public int? TotalWeeks { get; set; }

    public string? Level { get; set; }

    public string? Language { get; set; }

    public string? Prerequisites { get; set; }

    public DateOnly? LastUpdate { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }

    public int TrainerId { get; set; }

    public int? CategoryId { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbModule> TbModules { get; set; } = new List<TbModule>();

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();

    public virtual TbTrainer? Trainer { get; set; } = null!;
}
