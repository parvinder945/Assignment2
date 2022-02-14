using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

        }
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int min = 0;//declaring a variable to store the min index
                int max = nums.Length - 1;//declaring a variable to store the max index 
                int final = -1;//declaring output integer
                while (min <= max)
                {
                    int mid = (min + max) / 2;//getting the mid value from min and max 
                    if (target == nums[mid])//checking if target is equal to mid
                    {
                        final = mid;
                        break;
                    }
                    else if (target < nums[mid])//if target is lesser than mid the then reduce the max value
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;//increasing the min value
                    }
                    
                }
                if (final == -1)//checking if target is found or not, the value if not updated if target is not found
                {
                    final = min;//Min or Max gives the position where value needs to be inserted
                }
                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                string s = "";//Declaring new string
                foreach (char a in paragraph)//Removing special characters from the string
                {
                    if (a != '!' && a != '?' && a != '\'' && a != ';' && a != ',' && a != '.')
                    {
                        s = s + a;
                    }
                    else
                    {
                        s = s + ' ';
                    }
                }
                string s1 = s.ToLower();//converting new string to lower case
                string[] s2 = s1.Split(" ");//splitting the string at " " and storing it in a string array
                foreach(string x in s2)//removing empty spaces created while removing special characters
                {
                    s2 = s2.Where(y => y != "").ToArray();
                }
                foreach (string x in banned)//removing banned elements from the string array
                {
                    s2 = s2.Where(y => y != x.ToLower()).ToArray();
                }
                Dictionary<string, int> lookup = new Dictionary<string, int>();//creating a dictionary to store distinct strings and their count
                foreach (string a in s2.Distinct())//lookping over the distinct strings s2 array 
                {
                    int count = 0;
                    foreach (string b in s2)//looping over the s2 array for count of each string
                    {
                        if (a == b)
                        {
                            count = count + 1;//incrementing count 
                        }
                    }
                    lookup.Add(a, count);//adding the string and its count to dictionary
                }
                string final = "";
                foreach (KeyValuePair<string, int> x in lookup)//looping around dictionary
                {
                    if (x.Value == lookup.Values.Max())//getting max value from dictionary values
                    {
                        final = x.Key;//getting key of the max value 
                    }
                }
                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int FindLucky(int[] arr)
        {
            try
            {
                int l = arr.Length;
                Array.Sort(arr);
                ArrayList result = new ArrayList();//creating a array list
                int[] distArr = arr.Distinct().ToArray();//getting distinct values from the input array
                int[] count = new int[distArr.Length];
                for (int i = 0; i < count.Length; i++)
                {
                    count[i] = arr.Count(s => s == distArr[i]);//getting count of each number in the array
                }
                for (int i = 0; i < count.Length; i++)
                {
                    if (distArr[i] == count[i])//if number value is equal to its count
                    {
                        result.Add(distArr[i]);//add to the array list
                    }
                }
                int final = -1;
                if (result.Count != 0)//if array list is not null
                {
                    final = (int)result[result.Count - 1];//update return value from array list
                }

                return final;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string GetHint(string secret, string guess)
        {
            try
            {
                string s1 = "";//declaring empty string
                string s2 = "";//declaring empty string
                int b = 0;
                int c = 0;
                for (int i = 0; i < secret.Length; i++)//looping around secret
                {
                    if (secret[i] == guess[i])//getting bulls count
                    {
                        b = b + 1;//incrementing bull count
                    }
                    else
                    {
                        s1 = s1 + secret[i];//creating secret with non bull values
                        s2 = s2 + guess[i];//creating guess with non bull values
                    }
                }
                foreach (char a in s2)//looping around non bull guess
                {
                    int flag = 0;//set flag to 0
                    for (int j = 0; j < s1.Length; j++)//looping around non bull secret
                    {
                        if (a == s1[j] & flag == 0)//if secret found in bull for first time
                        {
                            s1 = s1.Remove(j, 1);//remove value from secret
                            c = c + 1;//increment cow count
                            flag = 1;//set flag to 1
                        }
                    }
                }
                string final = b + "A" + c + "B";//creating final string
                return final;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int l = s.Length;
                int a = 0;//storing the overall loop count
                List<int> final = new List<int>();//creating a array to store final values
                while (a < s.Length)//looping around the complete input string
                {
                    int l2 = s.LastIndexOf(s[a]);//getting last occurance of the character
                    char x = s[a];
                    for (int i = 0; i <= l2; i++)
                    {
                        char y = s[i];
                        if (y != x)
                        {
                            if (s.LastIndexOf(y) > l2)
                            {
                                l2 = s.LastIndexOf(y);//updating the break point of the inner loop as a character exists beyond the lasst point of the first character of the string
                            }
                        }
                        a = i + 1;//storing index of last value in "a" which will be used to fetch the next character after this loop ends
                    }
                    int d = a - final.Sum();//getting the difference between the current a value and the last a value(string length)
                    final.Add(d);//pushing the length of the substring in the list
                }
                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                int l1 = widths.Length;
                int l2 = s.Length;
                Dictionary<char, int> lookup = new Dictionary<char, int>();
                for (int i = 0; i < l1; i++)//looping around the string
                {
                    int temp = i + 97;//getting index of the char in widths array
                    char x = Convert.ToChar(temp);
                    lookup.Add(x, widths[i]);//adding char and its value from the widths array to dictionary
                }
                int sum = 0;
                int count = 0;
                for (int i = 0; i < l2; i++)//looping around the string
                {
                    int temp = lookup[s[i]];//getting the value from dictionary for the respective char
                    if (sum + temp > 100)//if sum + next char value is greater than 100
                    {
                        sum = temp;//sum = next char value
                        count = count + 1;//incrementing line value
                    }
                    else if (sum + temp == 100 & i != (l2 - 1))//if sum + next char is 100 and its not the last char then
                    {
                        sum = 0;//making sum as zero
                        count = count + 1;//incrementing line value
                    }
                    else if (sum + temp == 100 & i == (l2 - 1))//if sum + next char is 100 and its the last char then
                    {
                        sum = sum + temp;//sum = sum +next char
                        count = count + 1;//incrementing line value
                    }
                    else
                    {
                        sum = sum + temp;//sum = sum + next char
                    }
                }
                if (sum < 100)//if sum is greater than 100
                {
                    count = count + 1;//incrementing line value
                }
                List<int> result = new List<int>();//creating a list
                result.Add(count);//adding line count to list
                result.Add(sum);//adding sum to list
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                int l = bulls_string10.Length;
                ArrayList check = new ArrayList();
                Dictionary<string, string> lookup = new Dictionary<string, string>();//creating dictionary
                lookup.Add("}", "{");//adding key value to the dictionary
                lookup.Add("]", "[");//adding key value to the dictionary
                lookup.Add(")", "(");//adding key value to the dictionary
                int counter = -1;
                for (int i = 0; i < l; i++)//looping around the string
                {
                    string a = bulls_string10[i].ToString();
                    if (lookup.ContainsValue(a))//if char is a value or not
                    {
                        check.Add(a);//adding to a array list
                        counter = counter + 1;//getting current size of arraylist
                    }
                    else if (lookup.ContainsKey(a) & counter != -1)//if char is a key or not
                    {
                        if (lookup[a] == check[counter].ToString())//checking if the input char associated value is equal to the last enetered value in arraylist
                        {
                            check.RemoveAt(counter);//removing from the arraylist
                            counter = counter - 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (counter == -1)//checking if there is anything remaining in the arraylist
                    {
                        return false;
                    }
                }
                if (counter != -1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] lookup = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                int l1 = words.Length;
                string[] final = new string[l1];
                for (int i = 0; i < l1; i++)//looping around the array
                {
                    string x = words[i];
                    int l2 = x.Length;
                    string p = "";
                    for (int j = 0; j < l2; j++)//looping around the string
                    {
                        int y = x[j] - 97;//getting ascii value of the char and reducing 97 to get the index to fetch from lookup array.
                        p = p + lookup[y];//adding the moose code of the char to the string
                    }
                    final[i] = p;//storing the final moose code in a array
                }
                int count = final.Distinct().Count();//getting distinct count from the final aaray
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }                
    }
}
