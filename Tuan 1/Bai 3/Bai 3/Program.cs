namespace Bai_3
{
    internal class Program
    {
        /*Given an array of integers nums, calculate the pivot index of this array.

      The pivot index is the index where the sum of all the numbers strictly to the left of
        the index is equal to the sum of all the numbers strictly to the index's right.

      If the index is on the left edge of the array, then the left sum is 0 because 
      there are no elements to the left. This also applies to the right edge of the array.

       Return the leftmost pivot index. If no such index exists, return -1.
         * 
         * */
        static public int PivotIndex(int[] nums)
        {
            int totalSum = 0;
            foreach(int nuin in nums)
            {
               totalSum += nuin;
            }

            int leftSum = 0;
            for(int i=0; i<nums.Length; i++) {
                if (leftSum == totalSum - leftSum - nums[i])
                    return i;
                leftSum += nums[i];
              }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] nums = { 1, 7, 3, 6, 5, 6 };
            Console.WriteLine(PivotIndex(nums));
        }
    }
}