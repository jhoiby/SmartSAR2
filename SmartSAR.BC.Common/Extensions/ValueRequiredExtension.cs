using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSAR.BC.Common.Extensions
{
    public static class ValueRequiredExtension
    {
        // String validations
        public static string Require(this string requiredString, string parameterName = null)
        {
            if (requiredString == null)
            {
                throw new ArgumentNullException(nameof(requiredString));
            }

            if (requiredString.Length == 0)
            {
                throw new ArgumentException("Value must not be empty.", nameof(requiredString));
            }

            if (requiredString.Trim().Length == 0)
            {
                throw new ArgumentException("Value must contain more than white space.", nameof(requiredString));
            }

            return requiredString;
        }

        // Guid validations
        public static Guid Require(this Guid requiredGuid, string parameterName = null)
        {
            if (requiredGuid == Guid.Empty)
            {
                throw new ArgumentException("Guid must not be empty (default)", nameof(requiredGuid));
            }

            return requiredGuid;
        }
    }
}
