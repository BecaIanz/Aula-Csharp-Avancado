namespace backend.EndPoints;

public static class ReverseEndPoints
{
    public static void ConfigureReverseEndpoints(this WebApplication app)
    {
        app.MapGet("reverse/{word}", async (string word) =>
        {
            var reversed = string.Concat(word.Reverse());
            bool isPalindrome = false;

            if (word == reversed)
                isPalindrome = true;

            return Results.Ok(new
            {
                result = reversed,
                palindrome = isPalindrome
            });
        });
    }
}
