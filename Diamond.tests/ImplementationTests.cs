namespace Diamond.tests
{
    public class ImplementationTests
    {
        [Fact]
        public void Creates_correct_number_of_rows()
        {
            Assert.Equal(1, Diamond.Create('A').Length);
            Assert.Equal(3, Diamond.Create('B').Length);
            Assert.Equal(5, Diamond.Create('C').Length);
        }

        [Fact]
        public void Creates_square()
        {
            var diamond = Diamond.Create('E');
            var numberOfRows = diamond.Length;
            var rowLengths = diamond.Select(x => x.Length);

            Assert.All(rowLengths, x=> { Assert.Equal(numberOfRows, x); });
        }

        [Fact]
        public void All_rows_contain_a_letter()
        {
            var diamond = Diamond.Create('E');
            Assert.All(diamond, row => { Assert.Contains(row, item => char.IsLetter(item)); });
        }

        [Fact]
        public void Calculates_right_position_for_letter()
        {
            var diamond = Diamond.Create('C');
            var numberOfRows = diamond.Length;
            var centerColumnIndex = (numberOfRows - 1)/2;

            Assert.Equal(centerColumnIndex, diamond[0].IndexOf("A"));
            Assert.Equal(centerColumnIndex-1, diamond[1].IndexOf("B"));
            Assert.Equal(centerColumnIndex-2, diamond[2].IndexOf("C"));
        }

        [Fact]
        public void Rows_are_horizontally_symmetrical()
        {
            var diamond = Diamond.Create('E');
            var numberOfRows = diamond.Length;
            var elementsPriorAndAfter = (numberOfRows -1) / 2;
            var elementsTotake = elementsPriorAndAfter + 1;
            
            var firstHalf = diamond.Take(elementsTotake);
            var secondHalf = diamond.Skip(elementsPriorAndAfter).Take(elementsTotake);

            Assert.Equal(firstHalf, secondHalf.Reverse());
        }

        [Fact]
        public void Rows_are_vertically_symmetrical()
        {
            var diamond = Diamond.Create('E');
            var numberOfRows = diamond.Length;
            var rowLength = numberOfRows;

            Assert.All(diamond, row =>
            {
                var indexOfMiddleCharacter = (numberOfRows - 1) / 2;
                var numberOfCharactersToTake = indexOfMiddleCharacter + 1;

                var leftPart = row.Substring(0, numberOfCharactersToTake);
                var rightPart = row.Substring(indexOfMiddleCharacter, numberOfCharactersToTake);
                
                Assert.Equal(numberOfCharactersToTake, leftPart.Length);
                Assert.Equal(numberOfCharactersToTake, rightPart.Length);
                Assert.Equal(leftPart, new String(rightPart.Reverse().ToArray()));
            });
        }
    }
}