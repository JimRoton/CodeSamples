namespace Extensions_Sample
{
    public static class StringExts
    {
        /// <summary>
        /// This extension is used to abstract
        /// the String.TryParse extension away
        /// from the user. It attempts to parse
        /// the string value and if it is
        /// unsuccessful, it returns zero.
        /// </summary>
        /// <param name="val">This String</param>
        /// <returns>Int or Zero</returns>
        public static int ToIntOrZero(this string val)
        {
            return int.TryParse(val, out int rtn) ? rtn : 0;
        }
    }
}
