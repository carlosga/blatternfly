using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Blatternfly
{
    public static class Utils
    {
        private static long _counter = 0;
        private static long _optionsToggleCounter = 0; 
        
        public static long CurrentOptionsToggleCounter => _optionsToggleCounter;
        
        internal static string GetUniqueId(string prefix = "pf")
        {
            // var random = GenerateRandom(10);
            // var uid    = EncodeToHexString(random);
            // return $"{prefix}-{uid}";
            var uid = Interlocked.Add(ref _counter, 1);
            return $"{prefix}-{uid}";
        }
        
        internal static string GetOptionsToggleId(string prefix)
        {
            var uid = Interlocked.Add(ref _optionsToggleCounter, 1);
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

        // internal static byte[] GenerateRandom(int count)
        // {
        //     if (count <= 0)
        //     {
        //         throw new ArgumentOutOfRangeException(nameof(count));
        //     }
        //
        //     var buffer = new byte[count];
        //
        //     using var rng = RandomNumberGenerator.Create();
        //     
        //     rng.GetBytes(buffer);
        //
        //     return buffer;
        // }
        //
        // internal static string EncodeToHexString(in byte[] buffer) => EncodeToHexString(buffer, string.Empty);
        //
        // internal static string EncodeToHexString(in byte[] buffer, in string separator)
        // {
        //     if (buffer == null)
        //     {
        //         throw new ArgumentNullException(nameof(buffer));
        //     }
        //
        //     var hex = new StringBuilder((buffer.Length * 2) * 2);
        //
        //     for (var i = 0; i < buffer.Length; i++)
        //     {
        //         if (!string.IsNullOrEmpty(separator) && hex.Length > 0)
        //         {
        //             hex.Append(separator);
        //         }
        //         hex.Append(buffer[i].ToString("X2"));
        //     }
        //
        //     return hex.ToString();
        // }
    }
}
