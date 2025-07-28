namespace backend.EndPoints;

public static class ImaExpEndPoints
{
    public static void ConfigureImaExpEndpoints(this WebApplication app)
    {
        app.MapGet("imaexp", async (double A, double b) =>
        {
            double Re = A * Math.Sin(b);
            double Im = A * Math.Cos(b);

            return Results.Ok(new
            {
                Re,
                Im
            });
        });
    }
}