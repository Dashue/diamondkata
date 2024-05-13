
namespace Diamond
{
    public static class Diamond
    {
        private static List<char> _letters = Enumerable.Range(65, 26).Select(x => (char)x).ToList();

        public static string[] Create(char maxLetter)
        {
            int index = _letters.IndexOf(maxLetter);
            char[] previousLetters = _letters.GetRange(0, index).ToArray();

            if (previousLetters.Length == 0)
            {
                return [$"{maxLetter}"];
            }

            var numberOfColumns = previousLetters.Length * 2 + 1;

            var rows = new LinkedList<string>();

            /* Start by adding Middle Row */
            rows.AddFirst($"{maxLetter}{new string('_', numberOfColumns > 2 ? numberOfColumns - 2 : 0)}{maxLetter}");


            var offsetFromMiddleRow = 1;
            /* Populate diamond outwards from Middle Row one row at a time, increasing level of indentation for each row */
            foreach (var letter in previousLetters.Reverse().ToArray())
            {
                var numberOfSpacesAtStart = offsetFromMiddleRow;
                var numberOfSpacesAtEnd = offsetFromMiddleRow;
                var numberOfLettersPerRow = 2;

                /* Calculate number of spaces in the center of the string */
                var middleSpaces = numberOfColumns - numberOfSpacesAtStart - numberOfSpacesAtEnd - numberOfLettersPerRow;

                string row;
                if (middleSpaces > 0)
                {
                    row = $"{new string('_', numberOfSpacesAtStart)}{letter}{new string('_', middleSpaces)}{letter}{new string('_', numberOfSpacesAtEnd)}";
                }
                else
                {
                    row = $"{new string('_', numberOfSpacesAtStart)}{letter}{new string('_', numberOfSpacesAtEnd)}";
                }

                rows.AddFirst(row);
                rows.AddLast(row);

                offsetFromMiddleRow++;
            }


            return rows.ToArray();
        }
    }
}
