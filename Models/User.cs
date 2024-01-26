namespace SkillPortal.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Mobile { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual ICollection<Email> EmailsNavigation { get; } = new List<Email>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
