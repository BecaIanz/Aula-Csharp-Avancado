using Ponctual.Domain.Models;

namespace Ponctual.Domain.Services.ClockIn;

public interface IClockInService
{
    Task<ClockInResult> ClockIn(int userId);

    Task<ICollection<Registro>> GetClockIns(ClockInFilter filter);
}