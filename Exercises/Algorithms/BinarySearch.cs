namespace Exercises.Algorithms
{
    public class BinarySearch
    {
        /*
            Given an array of integers nums which is sorted in ascending order, 
            and an integer target, write a function to search target in nums. 
            If target exists, then return its index. Otherwise, return -1.
            You must write an algorithm with O(log n) runtime complexity.

            Example 1:
            Input: nums = [-1,0,3,5,9,12], target = 9
            Output: 4
            Explanation: 9 exists in nums and its index is 4

            Example 2:
            Input: nums = [-1,0,3,5,9,12], target = 2
            Output: -1
            Explanation: 2 does not exist in nums so return -1

            Constraints:
            1 <= nums.length <= 104
            -104 < nums[i], target < 104
            All the integers in nums are unique.
            nums is sorted in ascending order.
        */

        private const int NotFound = -1;

        public int Search(int[] numbers, int target)
        {
            if (numbers == null) return NotFound;
            var maxPosition = numbers.Length - 1;
            var result = binarySearch(numbers, target, 0, maxPosition);
            return result;
        }

        private int binarySearch(int[] nums, int target, int minPosition, int maxPosition)
        {
            var pivotIndex = (minPosition + maxPosition) / 2;
            var value = nums[pivotIndex];

            if (value == target) return pivotIndex;
            if (nums[minPosition] == target) return minPosition;
            if (nums[maxPosition] == target) return maxPosition;
            if (minPosition == maxPosition) return NotFound;

            if (value < target) return binarySearch(nums, target, minPosition+1, maxPosition);
            else return binarySearch(nums, target, minPosition, maxPosition-1);
        }
    }
}
