using Exercises.Algorithms;
using Shouldly;
using Xunit;

namespace ExercisesTests.Algorithms
{
    public class BinarySearchTests
    {
        [Theory]
        [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
        [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
        [InlineData(new int[] { 2, 5, 8, 13, 20, 21, 23, 35, 80 }, 35, 7)]
        [InlineData(new int[] { 2, 5, 8, 13, 20, 21, 23, 35, 80 }, 80, 8)]
        [InlineData(new int[] { 2, 5, 8, 13, 20, 21, 23, 35, 80 }, 2, 0)]
        [InlineData(new int[] { 2, 5, 8, 13, 20, 21, 23, 35, 80 }, 1, -1)]
        [InlineData(null, 2, -1)]
        public void Search(int[] numbers, int searchTarget, int expected)
        {
            var binarySearch = new BinarySearch();
            var result = binarySearch.Search(numbers, searchTarget);
            result.ShouldBe(expected);
        }
    }
}
