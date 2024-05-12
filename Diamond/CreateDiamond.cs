
namespace Diamond
{
    public static class Diamond
    {
        private static List<char> _letters = Enumerable.Range(65, 26).Select(x => (char)x).ToList();

        public static string[] Create(char maxLetter)
        {
            int index = _letters.IndexOf(maxLetter);
            char[] previousLetters = _letters.GetRange(0, index).ToArray();

            List<char> letters = new List<char>([..previousLetters, maxLetter, ..previousLetters.Reverse()]);

            return letters.Select(x => "_").ToArray();
        }
    }
}
