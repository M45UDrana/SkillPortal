using System;
using System.Collections.Generic;

namespace SkillPortal.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? SkillName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
