namespace Domain.Common;

public class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.NowUtc;
    public DateTime? ModifiedAt { get; set; }
}