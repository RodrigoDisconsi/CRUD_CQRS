using CRUDCleanArchitecture.Application.Common.Interfaces;

namespace CRUDCleanArchitecture.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
