namespace AppNamoro.Payloads;

public record USerCreatePayload(
    string Name,
    Guid ID,
    int Age,
    string Gender
);