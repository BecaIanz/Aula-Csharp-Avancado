namespace Ponctual.Domain.Services.ClockIn;

public record ClockInFilter(
    int Page = 1,
    int PageSize = 20,
    DateTime? InitialTime = null,
    DateTime? FinalTime = null
);