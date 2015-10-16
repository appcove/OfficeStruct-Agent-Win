using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OfficeStruct_Agent_Win.Classes
{
    public static class Extensions
    {
        public static bool IsLike(this string str, string pattern)
        {
            return new Regex(
                "^" + Regex.Escape(pattern)
                    .Replace(@"\*", ".*")
                    .Replace(@"\?", ".") + "$",
                RegexOptions.IgnoreCase | RegexOptions.Singleline
                ).IsMatch(str);
        }
        public static string ToSha256(this string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                var sha = new SHA256Managed();
                var checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }
        public static bool IsValidFilename(this string filename)
        {
            if (String.IsNullOrEmpty(filename)) return false;
            var invChars = Path.GetInvalidFileNameChars();
            return !filename.Any(c => Array.IndexOf(invChars, c) >= 0);
        }
        public static bool IsValidFolder(this string folder)
        {
            return !String.IsNullOrEmpty(folder)
                   && Directory.Exists(folder);
        }
    }
}
