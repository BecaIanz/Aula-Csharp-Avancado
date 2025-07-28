namespace backend.EndPoints;


public static class CuritibaEndPoints
{
    public static void ConfigureCuritibaEndpoints(this WebApplication app)
    {
        app.MapGet("curitiba", async (string cep, string cpf) =>
        {
            using var client = new HttpClient();
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var response = await client.GetAsync(url);


            return Results.Ok(new
            {

            });
        });
    }
}