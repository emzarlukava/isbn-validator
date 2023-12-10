namespace IsbnValidator
{
    public static class Validator
    {
        /// <summary>
        /// Returns true if the specified <paramref name="isbn"/> is valid; returns false otherwise.
        /// </summary>
        /// <param name="isbn">The string representation of 10-digit ISBN.</param>
        /// <returns>true if the specified <paramref name="isbn"/> is valid; false otherwise.</returns>
        /// <exception cref="ArgumentException"><paramref name="isbn"/> is empty or has only white-space characters.</exception>
        public static bool IsIsbnValid(string isbn)
        {
            string cleanedIsbn = isbn.Replace("-", string.Empty).Replace(" ", string.Empty);

            if (cleanedIsbn.Length != 10)
            {
                return false;
            }

            int checksum = 0;
            for (int i = 0; i < 10; i++)
            {
                int digit = (i == 9 && cleanedIsbn[i] == 'X') ? 10 : int.Parse(cleanedIsbn[i].ToString());
                checksum += (10 - i) * digit;
            }

            return checksum % 11 == 0;
        }
    }
}
