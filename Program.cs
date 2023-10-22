/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3,34, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 6, 5, 3, 2, 1 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "609";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 4, 5, 6, 7 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 4, 4, 3 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            List<IList<int>> missingRanges = new List<IList<int>>(); // Creating a list to store missing values
            if (lower > upper)
            {
                return missingRanges;
            }
            try
            {
                for (int i = 0; i < nums.Length; i++) //iteration through the sorted array of numbers
                {
                    if (nums[i] > upper)
                        break;

                    // Check for gaps between the current number and the previous number
                    if (nums[i] > lower)
                    {
                        if (nums[i] - 1 > lower) // if gap greater than one it will be added to as missing range 
                        {
                            missingRanges.Add(new List<int> { lower, nums[i] - 1 });
                        }
                        else if (nums[i] - 1 == lower) // if gap is equal to 1 then it will be added as  single number
                        {
                            missingRanges.Add(new List<int> { lower });
                        }
                    }
                    lower = nums[i] + 1; //updating the lower value for the next interation
                }
                if (lower <= upper) // check the value of lower is less or equal to the upper bound value 
                {
                    missingRanges.Add(new List<int> { lower, upper });
                }
                
                // Write your code here and you can modify the return value according to the requirements
                
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            return missingRanges; //return statement
        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                char[] stack = new char[s.Length]; // creating a char stack and initializing top index as  -1
                int top = -1;

                foreach (char c in s) // iteration through each character in input string begins
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack[++top] = c; // If an opening parenthesis is encountered, push it onto the stack
                    }
                    else if (c == ')' && (top == -1 || stack[top--] != '('))
                    {
                        return false; // If an closing parenthesis is encountered, push it onto the stack
                    }
                    else if (c == ']' && (top == -1 || stack[top--] != '['))
                    {
                        return false; //If an closing square bracket is encountered, push it onto the stack
                    }
                    else if (c == '}' && (top == -1 || stack[top--] != '{'))
                    {
                        return false; // if  a closing flower bracket is encountered, push it onto the stack
                    }
                }
                return top == -1; // return the top value as -1.
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }



        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (prices == null || prices.Length < 2) // check if array is null or has number of elements less than 2
                    return 0;

                // Value initialization for max profit and minimum price 
                int minPrice = prices[0]; 
                int maxProfit = 0;

                for (int i = 1; i < prices.Length; i++) //iteration through the price array
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - minPrice); // calculate maximum profit 
                    minPrice = Math.Min(minPrice, prices[i]); // calculating minimum price 
                }

                return maxProfit;  // return the max profit value again.
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirement

                // pointer initialization for the left and right side of the string 
                    int n = s.Length;
                    int left = 0;
                    int right = n - 1;
                // Defining a dictionary to create pairs
                    Dictionary<char, char> strobogrammaticPairs = new Dictionary<char, char>
                     {
                         { '0', '0' },
                         { '1', '1' },
                         { '6', '9' },
                         { '8', '8' },
                         { '9', '6' }
                     };

                    while (left <= right) // iteration from both left and right ends of the string
                    {
                        char leftChar = s[left];
                        char rightChar = s[right];

                        if (!strobogrammaticPairs.ContainsKey(leftChar) || !strobogrammaticPairs.ContainsKey(rightChar) || strobogrammaticPairs[leftChar] != rightChar)
                            return false;

                        // Moving the pointer towards the center from both the ends
                        left++;
                        right--;
                    }
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {

                Dictionary<int, int> countDict = new Dictionary<int, int>();
                int goodPairs = 0;

                foreach (int num in nums)
                {
                    if (countDict.ContainsKey(num))
                    {
                        // If the number is already in the dictionary, increment the count
                        int count = countDict[num];
                        goodPairs += count; // Increment  with the count
                        countDict[num] = count + 1; // Increment the count in the dictionary
                    }
                    else
                    {
                        countDict[num] = 1; // If the number is not in the dictionary, add it with count 1
                    }
                }
                // Write your code here and you can modify the return value according to the requirements
                return goodPairs;
            }
            catch (Exception)
            {
                return 0 ;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // intializing the variables to have a track on first second and thrid numbers
                long firstMax = long.MinValue;
                long secondMax = long.MinValue;
                long thirdMax = long.MinValue;

                foreach (int num in nums) // interating the numbers through the input array
                {
                    if (num > firstMax) //check if the number is more than the first maximum number
                    {
                        // update the firdt second and third values 
                        thirdMax = secondMax;
                        secondMax = firstMax;
                        firstMax = num;
                    }
                    else if (num < firstMax && num > secondMax)// check if number is less than first and greater than second maximumvalue
                    {
                        // update the values of third max and second max values accordingly
                        thirdMax = secondMax;
                        secondMax =  num;
                    }
                    else if (num < secondMax && num > thirdMax)// If the number is not the first or second maximum, check if it is the third maximum
                    {
                        thirdMax = num; // update the thrid value accrodingly
                    }
                }
                // Write your code here and you can modify the return value according to the requirements

                // if thrid  maximum doesn't exist return first maximu otherwise return thrid maximum.
                return thirdMax == long.MinValue ? (int)firstMax : (int)thirdMax;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []  
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            IList<string> possibleStates = new List<string>(); // List creation
            try
            {
                for (int i = 0; i < currentState.Length - 1; i++) // interating through the characters in the input string.
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+') //check for consecutive ++ in the string.
                    {

                        // creating a new string by replacing ++ with --
                        char[] newState = currentState.ToCharArray();
                        newState[i] = '-';
                        newState[i + 1] = '-';
                        possibleStates.Add(new string(newState));
                    }
                }
                // Write your code here and you can modify the return value according to the requirements
                return possibleStates; // return to the list of possiblesStates
            }
            catch (Exception)
            {
                return new List<string>(); // unexpected exceptions empty string is returned.
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            if (string.IsNullOrEmpty(s))
                return "no input given";

            // Define a set of vowels for efficient lookup
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            // StringBuilder to construct the result
            StringBuilder result = new StringBuilder();

            foreach (char c in s)//iterate through the inout string of the array
            {
                if (!vowels.Contains(c))// check whether the current vowel is there or not 
                    result.Append(c);
            }

            return result.ToString(); // return the result as the string with vowels removed.
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
