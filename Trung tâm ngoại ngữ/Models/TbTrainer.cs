using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbTrainer
{
    public int TrainerId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Speciality { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Instagram { get; set; }

    public string? LinkedIn { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }
}
