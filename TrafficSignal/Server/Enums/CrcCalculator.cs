using System;
using System.Linq;
using log4net;

namespace TrafficSignal.Server.Enums
{
    public static class CrcCalculator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CrcCalculator));

        public static string CalculateCrc(string hexString)
        {
            if (string.IsNullOrWhiteSpace(hexString))
            {
                log.Error("Input hex string is null or empty");
                throw new ArgumentException("Input hex string cannot be null or empty", nameof(hexString));
            }

            try
            {
                // Clean and normalize the hex string
                var cleanedHexString = CleanHexString(hexString);
                log.Info($"Normalized hex string: {cleanedHexString}");

                byte[] bytes = cleanedHexString.Split(' ')
                                               .Select(x => Convert.ToByte(x, 16))
                                               .ToArray();

                int crc = 0xFFFF;

                foreach (byte b in bytes)
                {
                    crc ^= b;

                    for (int i = 0; i < 8; i++)
                    {
                        if ((crc & 0x0001) != 0)
                        {
                            crc = (crc >> 1) ^ 0xA001;
                        }
                        else
                        {
                            crc >>= 1;
                        }
                    }
                }

                string crcResult = $"{(crc & 0xFF):X2} {(crc >> 8):X2}";
                log.Info($"Calculated CRC: {crcResult}");
                return crcResult;
            }
            catch (FormatException ex)
            {
                log.Error("Hex string contains invalid characters", ex);
                throw new ArgumentException("Hex string contains invalid characters", nameof(hexString), ex);
            }
            catch (Exception ex)
            {
                log.Error("An error occurred while calculating CRC", ex);
                throw;
            }
        }

        private static string CleanHexString(string hexString)
        {
            var cleaned = hexString.Trim()
                                   .Replace("  ", " ")
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(part => part.Trim())
                                   .Aggregate((current, next) => current + " " + next);

            if (!IsValidHexString(cleaned))
            {
                log.Error($"Invalid hex string after cleaning: {cleaned}");
                throw new ArgumentException("Hex string contains invalid format after cleaning", nameof(hexString));
            }

            return cleaned;
        }

        private static bool IsValidHexString(string hexString)
        {
            return hexString.Split(' ').All(part => part.Length == 2 && part.All(IsHexDigit));
        }

        private static bool IsHexDigit(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
        }
    }
}