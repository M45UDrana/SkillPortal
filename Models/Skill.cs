namespace SkillPortal.Models;

public partial class Skill
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? SkillName { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
