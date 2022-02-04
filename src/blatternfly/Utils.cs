namespace Blatternfly;

internal static class Utils
{
    internal static string Pluralize(int i, string singular, string plural = null)
    {
        if (string.IsNullOrEmpty(plural))
        {
            plural = $"{singular}s";
        }
        return $"{i} {((i == 1) ? singular : plural)}";
    }
}
