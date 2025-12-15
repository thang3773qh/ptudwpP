using System;
using System.Collections.Generic;

namespace LinguaCenter.Models;

public partial class TbContact
{
    public int ContactId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    public DateTime CreatedDate { get; set; }
}
