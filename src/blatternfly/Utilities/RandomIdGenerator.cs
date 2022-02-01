using System;
using System.Security.Cryptography;
using System.Text;

namespace Blatternfly.Utilities;

public sealed class RandomIdGenerator : IRandomIdGenerator
{
    public string GenerateId(string prefix = "pf")
    {
        var random = GenerateRandom(10);
        var uid    = EncodeToHexString(random);
        return $"{prefix}-{uid}";
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
