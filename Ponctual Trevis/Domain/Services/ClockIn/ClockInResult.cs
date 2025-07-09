namespace Ponctual.Domain.Services.ClockIn;

public record ClockInResult(
    bool IsClockIn,
    bool IsSuccess,
    string Reason
);