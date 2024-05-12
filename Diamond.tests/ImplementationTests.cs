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
            var diamond = Diamond.Create('C');
            var numberOfRows = diamond.Length;
            var rowLengths = diamond.Select(x => x.Length);

            Assert.All(rowLengths, x=> { Assert.Equal(numberOfRows, x); });
        }

        [Fact]
        public void All_rows_contain_a_letter()
        {
            var diamond = Diamond.Create('C');
            Assert.All(diamond, row => { Assert.Contains(row, item => char.IsLetter(item)); });
        }
    }
}