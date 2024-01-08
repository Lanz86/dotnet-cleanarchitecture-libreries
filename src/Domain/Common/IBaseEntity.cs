using System.ComponentModel.DataAnnotations.Schema;

namespace LanzDev.CleanArchitecture.Libraries.Domain.Common;
public interface IBaseEntity
{
    [NotMapped]
    IReadOnlyCollection<BaseEvent> DomainEvents { get; }

    void AddDomainEvent(BaseEvent domainEvent);

    void RemoveDomainEvent(BaseEvent domainEvent);

    void ClearDomainEvents();
}
