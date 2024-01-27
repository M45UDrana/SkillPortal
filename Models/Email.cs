namespace SkillPortal.Models;

public partial class Email
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? EmailAddress { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual User? User { get; set; }
}
