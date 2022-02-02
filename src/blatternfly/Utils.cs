using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Blatternfly;

internal static class Utils
{
    private static long _counter;

    private static string GetRandomId(string prefix = "pf")
    {
        var random = GenerateRandom(10);
        var uid    = EncodeToHexString(random);
        return $"{prefix}-{uid}";
    }

    private static string GetUniqueId(string prefix = "pf")
    {
        var uid = Interlocked.Increment(ref _counter);
        return $"{prefix}-{uid}";
    }

    internal static string Pluralize(int i, string singular, string plural = null)
    {
        if (string.IsNullOrEmpty(plural))
        {
            plural = $"{singular}s";
        }
        return $"{i} {((i == 1) ? singular : plural)}";
    }

    private static byte[] GenerateRandom(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        var buffer = new byte[count];

        using var rng = RandomNumberGenerator.Create();

        rng.GetBytes(buffer);

        return buffer;
    }

    private static string EncodeToHexString(in byte[] buffer) => EncodeToHexString(buffer, string.Empty);

    private static string EncodeToHexString(in byte[] buffer, in string separator)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        var hex = new StringBuilder((buffer.Length * 2) * 2);

        foreach (var t in buffer)
        {
            if (!string.IsNullOrEmpty(separator) && hex.Length > 0)
            {
                hex.Append(separator);
            }
            hex.Append(t.ToString("X2"));
        }

        return hex.ToString();
    }
}
