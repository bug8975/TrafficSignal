﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignal.Server.Enums
{
    public static class StringToByteArray
    {
        /// <summary>
        /// Converts a space-separated hexadecimal string to a byte array.
        /// </summary>
        /// <param name="hexString">The space-separated hexadecimal string.</param>
        /// <returns>The corresponding byte array.</returns>
        /// <exception cref="ArgumentException">Thrown when the input string is not a valid space-separated hexadecimal string.</exception>
        public static byte[] Convert(string hexString)
        {
            if (string.IsNullOrWhiteSpace(hexString))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            // Split the string by spaces
            var hexValues = hexString.Split(' ');

            // Convert each hex value to a byte
            try
            {
                return hexValues.Select(hex => System.Convert.ToByte(hex, 16)).ToArray();
            }
            catch (FormatException)
            {
                throw new ArgumentException("Input string contains invalid hexadecimal characters.");
            }
        }
    }
}