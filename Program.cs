using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Codility.LinkedListSample;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FirstUniqChar("loveleetcode");
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static void shortenPath(string input)
        {
            input = "/../";
            var path_split = input.Split("/");

            Stack<string> st = new Stack<string>();
            var isRelativePath = (input[0] == '/') ? false : true;

            for (int i = 0; i < path_split.Length; i++)
            {
                var item = path_split[i];


                

                if (item == "..")
                {

                    if (st.Count > 0)
                    {
                        if (isRelativePath && st.Peek() == "..")
                        {
                            st.Push(item);
                            continue;
                        }

                        if (st.Peek() != "/")
                        {
                            st.Pop();
                            continue;
                        }
                        
                    }

                    if (isRelativePath)
                    {
                        st.Push(item);
                    }
                }
                else if (item == "" || item == ".")
                {
                    continue;
                }
                else
                {
                    if (!isRelativePath && st.Count == 0)
                    {
                        st.Push($"/{item}");
                        continue;
                    }
                    st.Push(item);
                }
            }

            if (!isRelativePath && st.Count == 0)
            {
                st.Push($"/");
            }
            var tmp = new Stack<string>();
            while (st.Count > 0)
            {
                tmp.Push(st.Pop());
            }

            Console.WriteLine(string.Join("/", tmp));
        }


        public static void closestNumbers(List<int> numbers)
        {
            var _a = numbers.ToArray();
            Array.Sort(_a);
            int minDiff = Int32.MaxValue;
            for (int _a_i = 1; _a_i < _a.Length; _a_i++)
                minDiff = Math.Min(_a[_a_i] - _a[_a_i - 1], minDiff);
            for (int _a_i = 1; _a_i < _a.Length; _a_i++)
            {
                if (minDiff == _a[_a_i] - _a[_a_i - 1])
                {
                    Console.WriteLine($"{_a[_a_i - 1]} {_a[_a_i]}");

                }
            }
        }

        static int[] QuickSort2(List<int> arr)
        {
            var pivot = arr[0];
            var smallerItems = new List<int>();
            var equalItems = new List<int>();
            var biggerItems = new List<int>();
            var outputArr = new int[arr.Count];

            equalItems.Add(arr[0]);

            for (var i = 1; i < arr.Count; i++)
            {
                if (arr[i] < pivot)
                    smallerItems.Add(arr[i]);
                else if (arr[i] > pivot)
                {
                    biggerItems.Add(arr[i]);
                }
                else
                    equalItems.Add(arr[i]);
            }

            if (smallerItems.Count > 1)
                smallerItems = QuickSort2(smallerItems).ToList();

            if (biggerItems.Count > 1)
                biggerItems = QuickSort2(biggerItems).ToList();

            var j = 0;

            foreach (var item in smallerItems)
                outputArr[j++] = item;

            foreach (var item in equalItems)
                outputArr[j++] = item;

            foreach (var item in biggerItems)
                outputArr[j++] = item;

            return outputArr;
        }

        public static int[] StringPairsCommonLetter(string[] S)
        {
            //["abc","bca", "cab"]
            //var firstpair = S.FirstOrDefault();
            //var firstpair_arr = firstpair.ToCharArray();

            for (int i = 0; i < S.Length - 1; i++)
            {
                var firstpair_arr = S[i].ToCharArray();
                var remaining_arr = S.Except(new List<string> { S[i] }).ToList();
                for (int k = 0; k < remaining_arr.Count(); k++)
                {
                    var nextpair_arr = remaining_arr[k].ToCharArray();
                    for (int j = 0; j < firstpair_arr.Length; j++)
                    {
                        if (firstpair_arr[j] == nextpair_arr[j])
                        {
                            var second_index = Array.FindIndex(S, a => a == remaining_arr[k]);
                            return new int[] { i, second_index, j };
                        }
                    }
                }



            }

            return new int[] { };
        }

        public int LightBulb(int[] arr)
        {
            int rightmax = -1;
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > rightmax)
                {
                    rightmax = arr[i];
                }

                if (rightmax == i + 1)
                {
                    count++;
                }
            }
            return count;
        }

        public int FindLengthOfShortestSubarray(int[] arr)
        {
            int len = arr.Length;
            int i = 0;
            while (i < len - 1 && arr[i] <= arr[i + 1])
            {
                i++;
            }

            if (i == len - 1)
                return 0;

            int j = len - 1;
            while (j > 0 && arr[j] >= arr[j - 1])
            {
                j--;
            }

            //try removing towards right
            int r = j;
            while (r < len && arr[i] > arr[r])
            {
                r++;
            }

            int sublen1 = r - i - 1;

            //try moving towards left
            int l = i;
            while (l >= 0 && arr[j] < arr[l])
            {
                l--;
            }

            int sublen2 = j - l - 1;

            //try removing from middle
            l = i; r = j;
            while (l >= 0 && r < len && arr[l] > arr[r])
            {
                l--;
                r++;
            }

            int sublen3 = r - l - 1;

            int result = Math.Min(sublen1, Math.Min(sublen2, sublen3));
            return result;
        }

        public static void RemoveIdenticalCharFromString()
        {
            //get identical letters
            //get minimum cost
            //remove all identical with minimum cost

            //0,1,2,3,4
            //a,b,c,d,d
            //1,1,1,1,1
            var sample = "aabbccddd";
            var costs = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1 }.ToArray();

            var sample_arr = sample.ToCharArray();
            var sample_dict = new List<KeyValuePair<int, char>>();
            for (int i = 0; i < sample_arr.Length; i++)
            {
                sample_dict.Add(new KeyValuePair<int, char>(costs[i], sample_arr[i]));
            }

            //sample_dict.Where(a => a.Value)

            var identicals = "";
            for (int i = 0; i < sample_arr.Length - 1; i++)
            {
                var next = sample_arr[i + 1];
                if (next == sample_arr[i])
                {
                    identicals += next;
                }
            }

            var total = 0;
            for (int i = 0; i < identicals.Length; i++)
            {
                var tempi = i;
                var temp = identicals[i];
                var lowest_cost_item = sample_dict.Where(a => a.Value == identicals[i]).OrderBy(a => a.Key).FirstOrDefault();
                var lowest_cost = lowest_cost_item.Key;

                sample_dict.Remove(lowest_cost_item);
                total += lowest_cost;

            }
            Console.WriteLine(total);
        }

        public static List<Transaction> TransactionList(string Id, string subid = null)
        {
            var newlist = new List<Transaction>
            {
                new Transaction{ Id = "1" ,  SubId = "001"},
                new Transaction{ Id = "2" ,  SubId = "002"},
                new Transaction{ Id = "2" ,  SubId = "002"},
                new Transaction{ Id = "1" ,  SubId = "003"},
                new Transaction{ Id = "1" ,  SubId = "003"},
                new Transaction{ Id = "1" ,  SubId = "003"},
            };

            var ids = newlist.Where(a => (a.Id == Id) && (a.SubId == subid || subid == null)).ToList();
            return ids;
        }

        public static async Task MultipleApiCalls()
        {
            var currentTime = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                var httpclient = new HttpClient();
                var res = await httpclient.GetAsync("https://jsonplaceholder.typicode.com/todos/{i}");
                Console.WriteLine(res.Content.ReadAsStringAsync());

            }

            var result = (DateTime.Now - currentTime).TotalSeconds;
            Console.WriteLine(result);

        }

        public static async Task MultipleApiCallsAsync()
        {
            var currentTime = DateTime.Now;

            var allTasks = new List<Task<HttpResponseMessage>>();

            for (int i = 0; i < 10; i++)
            {
                var httpclient = new HttpClient();
                var res = httpclient.GetAsync("https://jsonplaceholder.typicode.com/todos/{i}");
                //Console.WriteLine(res.Content.ReadAsStringAsync());
                allTasks.Add(res);
                await Task.WhenAll(allTasks);
            }

            foreach (var item in allTasks)
            {
                var res = await item;
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }


            var result = (DateTime.Now - currentTime).TotalSeconds;
            Console.WriteLine(result);
        }

        public static void findMinNumberOfMoves(string S)
        {

            var charArray = S.ToCharArray();
            var charArrayList = S.ToCharArray().ToList();
            List<char> balloon_array = new List<char> { 'B', 'A', 'L', 'L', 'O', 'O', 'N' };
            List<char> new_array = new List<char> { };
            List<char> unwanted = new List<char> { };
            int result = 0;

            for (int i = 0; i < charArray.Length; i++)
            {

                if (balloon_array.Contains(charArray[i]) && balloon_array.Count > 0)
                {
                    new_array.Add(charArray[i]);
                    var find_index = balloon_array.FindIndex(a => a == charArray[i]);
                    balloon_array.RemoveAt(find_index);
                }
                else
                {
                    unwanted.Add(charArray[i]);
                }


            }

            if (balloon_array.Count == 0)
            {
                // remove unwanted letters
                //unwanted = charArrayList.Except(balloon_array).ToList();

                while (unwanted.Count > 0)
                {
                    if (unwanted.Count >= 7)
                    {
                        //unwanted = unwanted.SkipLast(7).ToList();
                        unwanted = SkipLast(unwanted, 7).ToList();
                        result++;
                    }
                    else
                    {
                        unwanted = unwanted.Skip(unwanted.Count).ToList();
                        result++;
                    }

                }

            }
            else
            {
                result = 0;
            }

            Console.WriteLine(result);
        }

        public static List<char> SkipLast(List<char> list, int max)
        {
            var max_loop = list.Count - max;
            for (int i = list.Count - 1; i >= max_loop; i--)
            {
                list.RemoveAt(i);
            }

            return list;
        }

        public static void findlongestdistance(int[] blocks)
        {
            //[2,6,8,5]
            //int index = 0;
            var longestdistance = 0;

            for (int index = 0; index < blocks.Length; index++)
            {

                var frog_one_position = index;
                var frog_two_position = index;
                var currentdistance = 0;

                //check for outside bounds array

                while ((frog_two_position + 1 < blocks.Length) && (blocks[frog_two_position + 1] >= blocks[frog_two_position]))
                {
                    frog_two_position = frog_two_position + 1;

                }

                while ((frog_one_position - 1 >= 0) && (blocks[frog_one_position - 1] >= blocks[frog_one_position]))
                {
                    frog_one_position = frog_one_position - 1;

                }

                currentdistance = frog_two_position - frog_one_position + 1;

                if (currentdistance > longestdistance)
                {
                    longestdistance = currentdistance;
                }


            }

            Console.WriteLine($"longest distance : {longestdistance}");

        }


        public static int BinarySearch()
        {
            var arr = new int[] { -2, 3, 4, 7, 8 , 9, 11, 13 };
            var target = 4;

            var left = 0;
            var right = arr.Length - 1;

            var mid = 0;

            while (left <= right)
            {
                mid = (int)Math.Floor(Convert.ToDecimal((left + right) / 2));

                if (target == arr[mid])
                {
                    return mid;
                }

                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }

                else 
                {
                    right = mid - 1;
                }
            }

            return -1;

        }

        public static void QuickSort(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            var p = partition(arr, l, r);
            QuickSort(arr, l, p - 1);
            QuickSort(arr, p + 1, r);
        }

        public static int partition(int[] arr, int l, int r)
        {
            //pivot will be the last index of the arr
            var pivot = arr[r];
            int i = l - 1;

            //loop through the arr
            for (int j = 0; j < arr.Length; j++)
            {
                // if current value is less than pivot
                //increment i
                //swap i with current value
                if (arr[j] < pivot)
                {
                    i++;
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            //place pivot in the middle
            var temp2 = arr[i + 1];
            arr[i + 1] = arr[r];
            arr[r] = temp2;

            return i + 1;
        }


        public static bool ContainsDuplicate()
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            var sample = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (sample.Contains(nums[i]))
                {
                    return true;
                }
                else
                {
                    sample.Add(nums[i]);
                }

            }

            return false;
        }

        public static bool validAnagram()
        {
            var s = "anagram";
            var t = "nagaram";

            var sArray = s.ToCharArray();
            var tArray = t.ToCharArray();

            Array.Sort(sArray);
            Array.Sort(tArray);

            for (int i = 0; i < s.Length; i++)
            {
                if (sArray[i] != tArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var templist = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var current_value = nums[i];
                var other_pair = target - current_value;

                if (templist.ContainsKey(other_pair))
                {
                    return new int[] { templist[other_pair], i };
                }

                if (!templist.ContainsKey(nums[i]))
                {
                    templist.Add(nums[i], i);
                }
            }

            return new int[] { };
        }

        public static int FindLargestDoubleDigits(int num)
        {
            var num_string = num.ToString();
            var max = 0;

            for (int i = 0; i < num_string.Length; i++)
            {
                var double_digit = $"{num_string[i]}{num_string[i + 1]}";
                var double_digit_int = int.Parse(double_digit);
                if (double_digit_int > max)
                {
                    max = double_digit_int;
                }
            }

            return max;

        }

        public static int FirstUniqChar(string s)
        {
            var bucket = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (bucket.ContainsKey(s[i]))
                {
                    bucket[s[i]]++;
                }
                else
                {
                    bucket.Add(s[i], 1);
                }
            }

            foreach(var key in bucket.Keys)
            {
                if (bucket[key] == 1)
                {
                    return s.IndexOf(key);
                }
            }

            return -1;
        }

    }


    public class Transaction
    {
        public string Id { get; set; }
        public string SubId { get; set; }
    }
}
