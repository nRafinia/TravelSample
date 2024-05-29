namespace TravelSample.Infra.Extensions;

internal static class StringExt
{
    public static string ToBase64(this string plainText) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
}