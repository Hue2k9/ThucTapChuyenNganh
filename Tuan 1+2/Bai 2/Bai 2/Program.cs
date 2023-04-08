namespace Bai_2
{
    internal class Program
    {
        /*
         * Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
          Return the running sum of nums.
         */
        static public int[] RunningSum(int[] nums)
        {
            int[] runningSum = new int[nums.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                runningSum[i] = sum;
            }
            return runningSum;
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            int[] runningSum = RunningSum(nums);
            for(int i=0; i<runningSum.Length; i++)
            {
                Console.Write(runningSum[i]+" ");
            }
        }
    }
}