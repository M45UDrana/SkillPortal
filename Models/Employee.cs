namespace SkillPortal.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? EmployeeName { get; set; }

    public string? EducationalQualification { get; set; }

    public decimal? BasicSalary { get; set; }

    public DateTime? JoiningDate { get; set; }

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
