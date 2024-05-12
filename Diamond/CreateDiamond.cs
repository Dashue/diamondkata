
namespace Diamond
{
    public static class Diamond
    {
        private static List<char> _letters = Enumerable.Range(65, 26).Select(x => (char)x).ToList();

        public static string[] Create(char maxLetter)
        {
            int index = _letters.IndexOf(maxLetter);
            char[] previousLetters = _letters.GetRange(0, index).ToArray();

            var numberOfColumns = previousLetters.Length * 2 + 1;

            var rows = new LinkedList<string>();
            rows.AddFirst($"{maxLetter}{new string('_', numberOfColumns > 2 ? numberOfColumns-2 :0)}{maxLetter}");


            var i = 1;
            foreach (var letter in previousLetters.Reverse().ToArray())
            {
                var middleSpaces = numberOfColumns - (i*2)-2;
                string row;

                if (middleSpaces > 0)
                {
                    row = $"{new string('_', i)}{letter}{new string('_', middleSpaces)}{letter}{new string('_', i)}";
                }
                else
                {
                    row = $"{new string('_', i)}{letter}{new string('_', i)}";
                }

                rows.AddFirst(row);
                rows.AddLast(row);
                i++;
            }               


            return rows.ToArray();
        }
    }
}
