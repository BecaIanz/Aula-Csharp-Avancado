using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace backend.EndPoints;

public static class CollatzEndPoints
{
    public static void ConfigureCollatzEndpoints(this WebApplication app)
    {
        app.MapGet("collatz", (int step, int current) =>
        {
            for (int i = 0; i < step; i++)
            {
                if (current % 2 == 0)
                {
                    current /= 2;
                }
                else
                {
                    current = 3 * current + 1;
                }  
            }

            return Results.Ok(new
            {
                current
            });
        });
    }
}