using System;

namespace GameLogic
{
    public static class StringExtensions
    {
        public static int ToInt32(this string s)
        {
            try
            {
                int i = Convert.ToInt32(s);

                return i;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to convert string [{s}] to Int32.", ex);
            }
        }
    }
}