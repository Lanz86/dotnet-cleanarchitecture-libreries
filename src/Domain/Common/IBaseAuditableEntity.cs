namespace LanzDev.CleanArchitecture.Libreries.Domain.Common;

public interface IBaseAuditableEntity
{
    DateTimeOffset Created { get; set; }

    string? CreatedBy { get; set; }

    DateTimeOffset LastModified { get; set; }

    string? LastModifiedBy { get; set; }
}
