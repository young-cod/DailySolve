using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using YsTools;

namespace ProgrammersScript
{
    public static class Solution
    {
        #region Factorial
        /*
         * ���� ����
        i���丮�� (i!)�� 1���� i���� ������ ���� �ǹ��մϴ�. ������� 5! = 5 * 4 * 3 * 2 * 1 = 120 �Դϴ�. ���� n�� �־��� �� ���� ������ �����ϴ� ���� ū ���� i�� return �ϵ��� solution �Լ��� �ϼ����ּ���.

        i! �� n
        ���ѻ���
        0 < n �� 3,628,800
         */
        public static int Factorial(int n)
        {
            int answer = 0;
            List<int> gapList = new List<int>();

            int chkNum = 0;
            for (int i = 1; i < 11; i++)
            {
                chkNum = EasyTool.Factorial(i);
                if (chkNum <= n)
                {
                    gapList.Add(Mathf.Abs(n - chkNum));
                }
            }

            int findIdx = 4000000;
            for (int i = 0; i < gapList.Count; i++)
            {
                if (gapList[i] < findIdx)
                {
                    findIdx = gapList[i];
                    answer = i + 1;
                }
            }
            return answer;
        }
        /* =========Else Solution============
         *  public int solution(int n) {
        int answer = 1;
        for(int i=1;i<=11;i++)
        {
            answer*=i;
            if(answer>n)
            {
                return i-1;
            }
        }
        return answer;
    }
    //=========Solution 2===============
    public int solution(int n) 
    {
        int answer = 1;

        while (true)
        {
            if (n <= answer)
                break;

            answer++;
            n /= answer;
        }

        return answer;
    }
         */
        #endregion

        #region �迭 ȸ����Ű��
        /*
         * ==========���� ����=========
            ������ ��� �迭 numbers�� ���ڿ� direction�� �Ű������� �־����ϴ�. �迭 numbers�� ���Ҹ� direction�������� �� ĭ�� ȸ����Ų �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

           ========���ѻ���============
            3 �� numbers�� ���� �� 20
            direction�� "left" �� "right" �� �� �ϳ��Դϴ�.
         */
        public static int[] SequenceRotate(int[] nums, string dir)
        {
            int[] answer = new int[nums.Length];

            if (dir == "left")
            {
                answer[nums.Length - 1] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    answer[i - 1] = nums[i];
                }
            }
            else
            {
                answer[0] = nums[nums.Length - 1];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    answer[i + 1] = nums[i];
                }
            }

            return answer;
        }
        #endregion

        #region �ֻ����� ����
        /*
     * ���� ����
    �Ӿ��̴� ������ü ����� ���ڸ� �ϳ� ������ �ִµ� �� ���ڿ� ������ü ����� �ֻ����� �ִ��� ���� ä��� �ͽ��ϴ�. ������ ����, ����, ���̰� ����Ǿ��ִ� �迭 box�� �ֻ��� �𼭸��� ���� ���� n�� �Ű������� �־����� ��, ���ڿ� �� �� �ִ� �ֻ����� �ִ� ������ return �ϵ��� solution �Լ��� �ϼ����ּ���.

    ���ѻ���
    box�� ���̴� 3�Դϴ�.
    box[0] = ������ ���� ����
    box[1] = ������ ���� ����
    box[2] = ������ ���� ����
    1 �� box�� ���� �� 100
    1 �� n �� 50
    n �� box�� ����
    �ֻ����� ���ڿ� �����ϰ� �ֽ��ϴ�.
     */
        public static int CountOfDice(int[] box, int n)
        {
            int answer = 1;

            for (int i = 0; i < box.Length; i++)
            {
                answer *= box[i] / n;
            }

            //answer *= box[0] / n;
            //answer *= box[1] / n;
            //answer *= box[2] / n;

            return answer;
        }
        #endregion

        #region �� ������
        /*
            <���� ����>
        �Ӿ��̴� ģ����� ���׶��� ���� �� ������ ������ �ϰ� �ֽ��ϴ�. ���� 1������ ������ ���������� �� ���� �ǳʶٰ� �״��� ������Ը� ���� �� �ֽ��ϴ�. ģ������ ��ȣ�� ����ִ� ���� �迭 numbers�� ���� K�� �־��� ��, k��°�� ���� ������ ����� ��ȣ�� �������� return �ϵ��� solution �Լ��� �ϼ��غ�����.

            <���ѻ���>
        2 < numbers�� ���� < 100
        0 < k < 1,000
        numbers�� ù ��°�� ������ ��ȣ�� ������ �ٷ� ���� �ֽ��ϴ�.
        numbers�� 1���� �����ϸ� ��ȣ�� ������� �ö󰩴ϴ�.
         */

        public static int BallBounce(int[] numbers, int k)
        {
            int answer = 0;
            int idx = ((k * 2) - 1) % numbers.Length;
            if (idx == 0) answer = numbers[numbers.Length - 1];
            else
            {
                answer = numbers[idx - 1];
            }
            /*
             * =============�� ������ ���� =====================
             * answer = numbers[((k * 2) - 2) % numbers.Length]; 
             */
            return answer;
        }
        #endregion

        #region �ռ��� ã��
        /*
         * ���� ����
    ����� ������ �� �� �̻��� ���� �ռ������ �մϴ�. �ڿ��� n�� �Ű������� �־��� �� n������ �ռ����� ������ return�ϵ��� solution �Լ��� �ϼ����ּ���.

    ���ѻ���
    1 �� n �� 100
         */
        public static int FindCompositeNum(int n)
        {
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (GetDivisorCount(i) > 2) count++;
            }
            return count;

        }
        public static int GetDivisorCount(int n)
        {
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }

            return count;
        }
        #endregion

        #region ���� ����
        /*
         * ���� ����
����� a, e, i, o, u �ټ� ���� ���ĺ��� �������� �з��մϴ�. ���ڿ� my_string�� �Ű������� �־��� �� ������ ������ ���ڿ��� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
my_string�� �ҹ��ڿ� �������� �̷���� �ֽ��ϴ�.
1 �� my_string�� ���� �� 1,000
         */

        public static string VowelRemove(string my_string)
        {
            string answer = "";

            string[] str = my_string.Split('a', 'e', 'i', 'o', 'u');
            foreach (var item in str)
            {
                answer += item;
            }
            return answer;
        }
        /*Else solution
         * using System.Text.RegularExpressions;
         * 
         * Regex.Replace(my_string,"a|e|i|o|u","");
         */
        #endregion

        #region ���ڿ� �����ϱ�(1)
        /*
         * ���� ����
���ڿ� my_string�� �Ű������� �־��� ��, my_string �ȿ� �ִ� ���ڸ� ��� �������� ������ ����Ʈ�� return �ϵ��� solution �Լ��� �ۼ��غ�����.

���ѻ���
1 �� my_string�� ���� �� 100
my_string���� ���ڰ� �� �� �̻� ���ԵǾ� �ֽ��ϴ�.
my_string�� ���� �ҹ��� �Ǵ� 0���� 9������ ���ڷ� �̷���� �ֽ��ϴ�. - - -
         */

        public static int[] CharStringArrange(string my_string)
        {
            int[] answer = new int[] { };
            List<int> sortNum = new List<int>();

            foreach (var item in my_string)
            {
                if (item >= '0' && item <= '9')
                {
                    sortNum.Add(item - '0');
                }
            }
            sortNum.Sort();
            answer = new int[sortNum.Count];

            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = sortNum[i];
            }

            return answer;
        }
        #endregion

        #region  ���μ�����

        /*
         * ���� ����
���μ����ض� � ���� �Ҽ����� ������ ǥ���ϴ� ���Դϴ�. ���� ��� 12�� ���μ� �����ϸ� 2 * 2 * 3 ���� ��Ÿ�� �� �ֽ��ϴ�. ���� 12�� ���μ��� 2�� 3�Դϴ�. �ڿ��� n�� �Ű������� �־��� �� n�� ���μ��� ������������ ���� �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
2 �� n �� 10,000
         */

        public static int[] Factorization(int n)
        {
            int[] answer = new int[] { };
            List<int> arrange = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    arrange.Add(i);
                    n /= i;
                }
            }

            return arrange.Distinct().ToArray();
        }
        #endregion

        #region ��Ʈ�� ��Ʈ

        /*
         * ���� ����
���ڿ� "Z"�� �������� ���еǾ� ��� ���ڿ��� �־����ϴ�. ���ڿ��� �ִ� ���ڸ� ���ʴ�� ���Ϸ��� �մϴ�. �� �� "Z"�� ������ �ٷ� ���� ���ߴ� ���ڸ� ���ٴ� ���Դϴ�. ���ڿ� "Z"�� �̷���� ���ڿ� s�� �־��� ��, �Ӿ��̰� ���� ���� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
1 �� s�� ���� �� 200
-1,000 < s�� ���� �� ���� < 1,000
s�� ����, "Z", �������� �̷���� �ֽ��ϴ�.
s�� �ִ� ���ڿ� "Z"�� ���� �������� ���е˴ϴ�.
���ӵ� ������ �־����� �ʽ��ϴ�.
0�� �����ϰ�� 0���� �����ϴ� ���ڴ� �����ϴ�.
s�� "Z"�� �������� �ʽ��ϴ�.
s�� ���۰� ������ ������ �����ϴ�.
"Z"�� �����ؼ� ������ ���� �����ϴ�.
         */

        public static int ControlZ(string s)
        {
            int answer = 0;
            string[] str = s.Split(" ");
            for (int i = 0; i < str.Length; i++)
            {
                answer += str[i] == "Z" ? -int.Parse(str[i - 1]) : int.Parse(str[i]);
            }

            return answer;
        }

        #endregion

        #region �ߺ��� ���� ����
        /*
         * ���� ����
���ڿ� my_string�� �Ű������� �־����ϴ�. my_string���� �ߺ��� ���ڸ� �����ϰ� �ϳ��� ���ڸ� ���� ���ڿ��� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� my_string �� 110
my_string�� �빮��, �ҹ���, �������� �����Ǿ� �ֽ��ϴ�.
�빮�ڿ� �ҹ��ڸ� �����մϴ�.
����(" ")�� �ϳ��� ���ڷ� �����մϴ�.
�ߺ��� ���� �� ���� �տ� �ִ� ���ڸ� ����ϴ�.
         */

        public static string RemoveDuplicateString(string my_string)
        {
            string answer = "";
            List<string> list = new List<string>();

            foreach (var item in my_string)
            {
                list.Add(item.ToString());
            }

            foreach (var item in list.Distinct())
            {
                answer += item;
            }
            return answer;
        }
        /* Other Solution
         *  string answer = string.Concat(my_string.Distinct());
            return answer;
         */
        #endregion

        #region ����� ��
        /*
         * ���� ����
���� �迭 array�� ���� n�� �Ű������� �־��� ��, array�� ����ִ� ���� �� n�� ���� ����� ���� return �ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� array�� ���� �� 100
1 �� array�� ���� �� 100
1 �� n �� 100
���� ����� ���� ���� ���� ��� �� ���� ���� return �մϴ�.
         */

        //[10,11,12,14] , 13
        public static int NearByNumber(int[] array, int n)
        {
            int answer = 0;

            int diff = Mathf.Abs(array[0] - n);
            answer = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (diff > Mathf.Abs(array[i] - n))
                {
                    diff = Mathf.Abs(array[i] - n);
                    answer = array[i];
                }
                else if (diff == Mathf.Abs(array[i] - n) && answer > array[i])
                {
                    answer = array[i];
                }
            }

            return answer;
        }
        #endregion

        #region 369����

        /*
         * ���� ����
�Ӿ��̴� ģ����� 369������ �ϰ� �ֽ��ϴ�. 369������ 1���� ���ڸ� �ϳ��� ��� 3, 6, 9�� ���� ���ڴ� ���� ��� 3, 6, 9�� ������ŭ �ڼ��� ġ�� �����Դϴ�. �Ӿ��̰� ���ؾ��ϴ� ���� order�� �Ű������� �־��� ��, �Ӿ��̰� �ľ��� �ڼ� Ƚ���� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
1 �� order �� 1,000,000
         */

        public static int GameIs369(int order)
        {
            int answer = 0;

            string str = order.ToString();
            foreach (var item in str)
            {
                if (item == '3' || item == '6' || item == '9')
                {
                    answer++;
                }
            }

            return answer;
        }

        #endregion

        #region ��ȣ �ص�

        /*
         * ���� ����
�� ������ �Ӿ��̴� ���� �� ������ ������ ���� ��ȣ ü�踦 ����Ѵٴ� ���� �˾Ƴ½��ϴ�.

��ȣȭ�� ���ڿ� cipher�� �ְ�޽��ϴ�.
�� ���ڿ����� code�� ��� ��° ���ڸ� ��¥ ��ȣ�Դϴ�.
���ڿ� cipher�� ���� code�� �Ű������� �־��� �� �ص��� ��ȣ ���ڿ��� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� cipher�� ���� �� 1,000
1 �� code �� cipher�� ����
cipher�� �ҹ��ڿ� �������θ� �����Ǿ� �ֽ��ϴ�.
���鵵 �ϳ��� ���ڷ� ����մϴ�.
         */
        //"dfja rdst ddet ckda cccc degk"	
        public static string DecryptionAPassword(string cipher, int code)
        {
            string answer = "";

            for (int i = 0; i < cipher.Length; i++)
            {
                if ((i + 1) % code == 0)
                {
                    answer += cipher[i];
                }
            }

            return answer;
        }

        #endregion

        #region �빮�ڿ� �ҹ���

        /*
         * ���� ����
���ڿ� my_string�� �Ű������� �־��� ��, �빮�ڴ� �ҹ��ڷ� �ҹ��ڴ� �빮�ڷ� ��ȯ�� ���ڿ��� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� my_string�� ���� �� 1,000
my_string�� ���� �빮�ڿ� �ҹ��ڷθ� �����Ǿ� �ֽ��ϴ�.
         */

        public static string solution(string my_string)
        {
            string answer = "";

            foreach (var item in my_string)
            {
                answer += char.IsUpper(item) ? char.ToLower(item) : char.ToUpper(item);
                //answer += char.IsUpper(item) ? item.ToString().ToLower() : item.ToString().ToUpper();
            }
            return answer;
        }

        #endregion

        #region ��� �Ⱦ��

        /*
         * ���� ����
��� ���� �Ӿ��̴� ����� ǥ��Ǿ��ִ� ���ڸ� ���� �ٲٷ��� �մϴ�. ���ڿ� numbers�� �Ű������� �־��� ��, numbers�� ������ �ٲ� return �ϵ��� solution �Լ��� �ϼ��� �ּ���.

���ѻ���
numbers�� �ҹ��ڷθ� �����Ǿ� �ֽ��ϴ�.
numbers�� "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ���� ���� ���� ���յǾ� �ֽ��ϴ�.
1 �� numbers�� ���� �� 50
"zero"�� numbers�� �� �տ� �� �� �����ϴ�.
         */

        //z : zero
        //o : one
        //t : two , three 
        //f : four , five 
        //s : six , seven
        //e : eight
        //n : nine;

        public static long HateEnglish(string numbers)
        {
            long answer = 0;
            string[] num = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            for (int i = 0; i < 10; i++)
            {
                numbers = numbers.Replace(num[i], i.ToString());
            }
            answer = long.Parse(numbers);

            return answer;
        }

        #endregion

        #region �ε��� �ٲٱ�

        /*
         * ���� ����
���ڿ� my_string�� ���� num1, num2�� �Ű������� �־��� ��, my_string���� �ε��� num1�� �ε��� num2�� �ش��ϴ� ���ڸ� �ٲ� ���ڿ��� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
1 < my_string�� ���� < 100
0 �� num1, num2 < my_string�� ����
my_string�� �ҹ��ڷ� �̷���� �ֽ��ϴ�.
num1 �� num2
         */

        public static string ChangeIndex(string my_string, int num1, int num2)
        {
            string answer = "";

            for (int i = 0; i < my_string.Length; i++)
            {
                if (i == num1)
                {
                    answer += my_string[num2];
                }
                else if (i == num2) answer += my_string[num1];
                else answer += my_string[i];

            }
            return answer;
        }

        //char �� stringBuilder �ᵵ ��

        #endregion

        #region �� ���� ������ ����

        /*
         * ���� ����
���ڿ� s�� �Ű������� �־����ϴ�. s���� �� ���� �����ϴ� ���ڸ� ���� ������ ������ ���ڿ��� return �ϵ��� solution �Լ��� �ϼ��غ�����. �� ���� �����ϴ� ���ڰ� ���� ��� �� ���ڿ��� return �մϴ�.

���ѻ���
0 < s�� ���� < 1,000
s�� �ҹ��ڷθ� �̷���� �ֽ��ϴ�.
         */


        public static string OnetimeChar(string s)
        {
            string answer = "";
            Dictionary<char, int> dicNum = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dicNum.ContainsKey(s[i]) == false)
                {
                    dicNum.Add(s[i], 1);
                }
                else
                {
                    dicNum[s[i]]++;
                }
            }

            var list = dicNum.Keys.ToList();
            list.Sort();

            foreach (var item in list)
            {
                if (dicNum[item] == 1)
                {
                    answer += item;
                }
            }

            return answer;
        }

        //Other Solution
        // string answer = string.Concat(s.Where(x => s.Count(o => o == x) == 1).OrderBy(x => x));
        //return answer;

        //Other Solution
        // string.split.Length �� ����Ͽ��ص� ��

        #endregion

        #region ��� ���ϱ�

        /*
         * ���� ����
���� n�� �Ű������� �־��� ��, n�� ����� ������������ ���� �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� n �� 10,000
         */

        public static int[] GetDivisor(int n)
        {
            int[] answer;
            List<int> numList = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    numList.Add(i);
                }
            }
            answer = new int[numList.Count];

            for (int i = 0; i < numList.Count; i++)
            {
                answer[i] = numList[i];
            }

            return answer;
        }

        //Other Solution
        //int[] answer = Enumerable.Range(1, n).Where(x => n % x == 0).ToArray();
        //return answer;


        #endregion

        #region ���� ū �� ã��

        /*
         * ���� ����
���� �迭 array�� �Ű������� �־��� ��, ���� ū ���� �� ���� �ε����� ���� �迭�� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
1 �� array�� ���� �� 100
0 �� array ���� �� 1,000
array�� �ߺ��� ���ڴ� �����ϴ�.
         */
        public static int[] solution(int[] array)
        {
            int[] answer = new int[2];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array.Max())
                {
                    answer[0] = array[i];
                    answer[1] = i;
                }
            }
            return answer;
        }

        //Ohter Solution
        // int[] answer = new int[2] { array.Max(), Array.IndexOf(array, array.Max()) };
        //return answer;

        #endregion

        #region ���ڿ� ����ϱ�

        /*
         * ���� ����
my_string�� "3 + 5"ó�� ���ڿ��� �� �����Դϴ�. ���ڿ� my_string�� �Ű������� �־��� ��, ������ ����� ���� return �ϴ� solution �Լ��� �ϼ����ּ���.

���ѻ���
�����ڴ� +, -�� �����մϴ�.
���ڿ��� ���۰� ������ ������ �����ϴ�.
0���� �����ϴ� ���ڴ� �־����� �ʽ��ϴ�.
�߸��� ������ �־����� �ʽ��ϴ�.
5 �� my_string�� ���� �� 100
my_string�� ����� ������� 1 �̻� 100,000 �����Դϴ�.
my_string�� �߰� ��� ���� -100,000 �̻� 100,000 �����Դϴ�.
��꿡 ����ϴ� ���ڴ� 1 �̻� 20,000 ������ �ڿ����Դϴ�.
my_string���� �����ڰ� ��� �ϳ� ���ԵǾ� �ֽ��ϴ�.
return type �� �������Դϴ�.
my_string�� ���ڿ� �����ڴ� ���� �ϳ��� ���еǾ� �ֽ��ϴ�.

         */

        public static int CalcChar(string my_string)
        {
            int answer = 0;
            string[] str = my_string.Split(" ");

            bool type = true;
            foreach (var item in str)
            {
                if (item.Equals("+")) type = true;
                else if (item.Equals("-")) type = false;
                else answer += type ? int.Parse(item) : -(int.Parse(item));
            }

            return answer;
        }
        #endregion

        #region ���� ã��

        /*
         * ���� ����
���� num�� k�� �Ű������� �־��� ��, num�� �̷�� ���� �߿� k�� ������ num�� �� ���ڰ� �ִ� �ڸ� ���� return�ϰ� ������ -1�� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
0 < num < 1,000,000
0 �� k < 10
num�� k�� ���� �� ������ ���� ó�� ��Ÿ���� �ڸ��� return �մϴ�.
         */

        public static int FindNumber(int num, int k)
        {
            int answer = 0;

            for (int i = 0; i < num.ToString().Length; i++)
            {
                if (num.ToString()[i] - '0' == k)
                {
                    answer = i + 1;
                    break;
                }
            }
            if (answer == 0) answer = -1;
            return answer;
        }
        //Other Solution
        //int answer = num.ToString().IndexOf(k.ToString()) + 1;

        #endregion

        #region n�� ��� ����

        /*
         * ���� ����
���� n�� ���� �迭 numlist�� �Ű������� �־��� ��, numlist���� n�� ����� �ƴ� ������ ������ �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� n �� 10,000
1 �� numlist�� ũ�� �� 100
1 �� numlist�� ���� �� 100,000
         */

        public static int[] ChoiceMultipleOfN(int n, int[] numlist)
        {
            int[] answer = new int[] { };

            foreach (var item in numlist)
            {
                if (item % n == 0)
                {
                    Debug.Log(item);
                    answer = answer.Append(item).ToArray();
                }
            }

            return answer;
        }

        //Other Solution
        //int[] answer = numlist.Where(x => x % n == 0).ToArray();

        #endregion

        #region OX����

        /*
         * ���� ����
����, ���� ���ĵ��� 'X [������] Y = Z' ���·� ����ִ� ���ڿ� �迭 quiz�� �Ű������� �־����ϴ�. ������ �Ǵٸ� "O"�� Ʋ���ٸ� "X"�� ������� ���� �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
���� ��ȣ�� ���� ���̴� �׻� �ϳ��� ������ �����մϴ�. �� ������ ǥ���ϴ� ���̳ʽ� ��ȣ�� ���� ���̿��� ������ �������� �ʽ��ϴ�.
1 �� quiz�� ���� �� 10
X, Y, Z�� ���� 0���� 9���� ���ڷ� �̷���� ������ �ǹ��ϸ�, �� ������ �� �տ� ���̳ʽ� ��ȣ�� �ϳ� ���� �� �ְ� �̴� ������ �ǹ��մϴ�.
X, Y, Z�� 0�� �����ϰ�� 0���� �������� �ʽ��ϴ�.
-10,000 �� X, Y �� 10,000
-20,000 �� Z �� 20,000
[������]�� + �� - �� �ϳ��Դϴ�.
         */

        public static string[] QuizOX(string[] quiz)
        {
            string[] answer = new string[] { };

            bool CheckCalcNumber(string str)
            {
                string[] val = str.Split(" ");

                bool type = true;
                int calcNum = 0;
                foreach (var item in val)
                {
                    if (item.Equals("+")) type = true;
                    else if (item.Equals("-")) type = false;
                    else if (item.Equals("=")) break;
                    else calcNum += type ? int.Parse(item) : -(int.Parse(item));
                }
                return calcNum == int.Parse(val[val.Length - 1]) ? true : false;
            }

            foreach (var item in quiz)
            {
                answer = CheckCalcNumber(item) ? answer.Append("O").ToArray() : answer.Append("X").ToArray();
            }

            return answer;
        }

        #endregion

        #region ��������

        /*
         * ���� ����
� ������ 1�ð��� �ι踸ŭ �����Ѵٰ� �մϴ�. ó�� ������ ������ n�� ����� �ð� t�� �Ű������� �־��� �� t�ð� �� ������ ���� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� n �� 10
1 �� t �� 15
         */
        public static float BacterialGrowth(int n, int t)
        {
            float answer = n;

            for (int i = 1; i <= t; i++)
            {
                answer *= 2;
            }

            return answer;
        }
        //Other Solution
        // int answer = n << t;
        #endregion

        #region ���ڿ� �����ϱ�(2)

        /*
         * ���� ����
���� ��ҹ��ڷ� �̷���� ���ڿ� my_string�� �Ű������� �־��� ��, my_string�� ��� �ҹ��ڷ� �ٲٰ� ���ĺ� ������� ������ ���ڿ��� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
0 < my_string ���� < 100
         */

        public static string CharStringArrange2(string my_string)
        {
            string answer = "";
            List<char> charStr = new List<char>();

            foreach (var item in my_string)
            {
                charStr.Add(char.ToLower(item));
            }
            charStr.Sort();

            foreach (var item in charStr)
            {
                answer += item;
            }

            return answer;
        }

        //Other Solution
        //string answer = string.Concat(my_string.ToLower().OrderBy(c => c));

        #endregion

        #region 7�� ����

        /*
         * ���� ����
�Ӿ��̴� ����� ���� 7�� ���� �����մϴ�. ���� �迭 array�� �Ű������� �־��� ��, 7�� �� �� �� �ִ��� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
1 �� array�� ���� �� 100
0 �� array�� ���� �� 100,000
         */

        public static int NumberOfSeven(int[] array)
        {
            int answer = 0;

            foreach (var item in array)
            {
                for (int i = 0; i < item.ToString().Length; i++)
                {
                    if (item.ToString()[i] == '7')
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }

        //Other Solution
        //int answer = string.Join("", array).Count(x => x == '7');

        #endregion

        #region �߶� �迭�� �����ϱ�

        /*
         * ���� ����
���ڿ� my_str�� n�� �Ű������� �־��� ��, my_str�� ���� n�� �߶� ������ �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� my_str�� ���� �� 100
1 �� n �� my_str�� ����
my_str�� ���ĺ� �ҹ���, �빮��, ���ڷ� �̷���� �ֽ��ϴ�.
         */

        public static string[] ArrayCutSave(string my_str, int n)
        {
            string[] answer = new string[] { };
            List<string> listAnswer = new List<string>();

            int idx = 0;
            while (idx < my_str.Length)
            {
                if (idx + n > my_str.Length + 1)
                {
                    listAnswer.Add(my_str.Substring(idx));
                    break;
                }
                else
                {
                    listAnswer.Add(my_str.Substring(idx, n));
                    idx += n;
                }
            }

            answer = listAnswer.ToArray();

            return answer;
        }

        /*Other Solution
         *   List<string> strings = new List<string>();

        string temp = my_str;

        while(temp.Length > n)
        {
            strings.Add(temp.Substring(0, n));
            temp = temp.Remove(0, n);
        }

        strings.Add(temp);

        return strings.ToArray();
         */

        #endregion

        #region ���簢�� ���� ���ϱ�

        /*
         * ���� ����
2���� ��ǥ ��鿡 ���� ��� ������ ���簢���� �ֽ��ϴ�. ���簢�� �� �������� ��ǥ [[x1, y1], [x2, y2], [x3, y3], [x4, y4]]�� ����ִ� �迭 dots�� �Ű������� �־��� ��, ���簢���� ���̸� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
dots�� ���� = 4
dots�� ������ ���� = 2
-256 < dots[i]�� ���� < 256
�߸��� �Է��� �־����� �ʽ��ϴ�.
         */

        public static int FindRectangleArea(int[,] dots)
        {
            int answer = 1;
            int[] calc = new int[2];

            //x��ǥ�� ������ y�� ����
            if (dots[0, 0] == dots[1, 0])
            {
                calc[1] = Math.Abs(dots[0, 1] - dots[1, 1]);
                calc[0] = Math.Abs(dots[0, 0] - dots[2, 0]);
            }
            //y��ǥ�� ������ x�� ����
            else
            {
                calc[0] = Math.Abs(dots[0, 0] - dots[1, 0]);
                calc[1] = Math.Abs(dots[0, 1] - dots[2, 1]);
            }
            answer = calc[0] * calc[1];

            return answer;
        }

        //Other Solution
        /*
         *  int answer = 0;

        int[] x = new int[4];
        int[] y = new int[4];

        for(int i=0; i<4; i++)
        {
            x[i] = dots[i, 0];
            y[i] = dots[i, 1];
        }

        answer = (x.Max() - x.Min()) * (y.Max() - y.Min());

        return answer;
         */

        #endregion

        #region ĳ������ ��ǥ

        /*
         * ���� ����
�Ӿ��̴� RPG������ �ϰ� �ֽ��ϴ�. ���ӿ��� up, down, left, right ����Ű�� ������ �� Ű�� ������ ��, �Ʒ�, ����, ���������� �� ĭ�� �̵��մϴ�. ���� ��� [0,0]���� up�� �����ٸ� ĳ������ ��ǥ�� [0, 1], down�� �����ٸ� [0, -1], left�� �����ٸ� [-1, 0], right�� �����ٸ� [1, 0]�Դϴ�. �Ӿ��̰� �Է��� ����Ű�� �迭 keyinput�� ���� ũ�� board�� �Ű������� �־����ϴ�. ĳ���ʹ� �׻� [0,0]���� ������ �� Ű �Է��� ��� ���� �ڿ� ĳ������ ��ǥ [x, y]�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

[0, 0]�� board�� �� �߾ӿ� ��ġ�մϴ�. ���� ��� board�� ���� ũ�Ⱑ 9��� ĳ���ʹ� �������� �ִ� [-4, 0]���� ���������� �ִ� [4, 0]���� �̵��� �� �ֽ��ϴ�.
���ѻ���
board�� [���� ũ��, ���� ũ��] ���·� �־����ϴ�.
board�� ���� ũ��� ���� ũ��� Ȧ���Դϴ�.
board�� ũ�⸦ ��� ����Ű �Է��� �����մϴ�.
0 �� keyinput�� ���� �� 50
1 �� board[0] �� 99
1 �� board[1] �� 99
keyinput�� �׻� up, down, left, right�� �־����ϴ�.
         */

        public static int[] CoordinateOfCharacter(string[] keyinput, int[] board)
        {
            int[] answer = new int[2];

            foreach (var input in keyinput)
            {
                switch (input)
                {
                    case "up":
                        answer[1]++;
                        if (answer[1] > board[1] / 2) answer[1] = board[1] / 2;
                        break;
                    case "down":
                        answer[1]--;
                        if (answer[1] < -board[1] / 2) answer[1] = -board[1] / 2;
                        break;
                    case "left":
                        answer[0]--;
                        if (answer[0] < -board[0] / 2) answer[0] = -board[0] / 2;
                        break;
                    case "right":
                        answer[0]++;
                        if (answer[0] > board[0] / 2) answer[0] = board[0] / 2;
                        break;
                }
            }


            return answer;
        }
        #endregion

        #region �ִ� �����(2)

        /*
         * ���� ����
���� �迭 numbers�� �Ű������� �־����ϴ�. numbers�� ���� �� �� ���� ���� ���� �� �ִ� �ִ��� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
-10,000 �� numbers�� ���� �� 10,000
2 �� numbers �� ���� �� 100
         */

        public static int MakeMaxNumber2(int[] numbers)
        {
            int answer = 0;
            int max = -100000000;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (k == i) continue;
                    if (numbers[i] * numbers[k] >= max) max = numbers[i] * numbers[k];
                }
            }
            answer = max;
            return answer;
        }

        //Other Solution
        /*
         * int maxLen = numbers.Length-1;
        Array.Sort(numbers);
        return (int)MathF.Max(numbers[0]*numbers[1], numbers[maxLen]*numbers[maxLen-1]);
         */

        #endregion

        #region ���׽� ���ϱ�

        /*
         * ���� ����
�� �� �̻��� ���� ������ �̷���� ���� ���׽��̶�� �մϴ�. ���׽��� ����� ���� �����׳��� ����� �����մϴ�. �������� �̷���� ���׽� polynomial�� �Ű������� �־��� ��, �����׳��� ���� �ᱣ���� ���ڿ��� return �ϵ��� solution �Լ��� �ϼ��غ�����. ���� ���̶�� ���� ª�� ������ return �մϴ�.

���ѻ���
0 < polynomial�� �ִ� �� < 100

polynomial�� ������ 'x'�� �����մϴ�.

polynomial�� ���� ����, ����, ��x��, ��+'�� �̷���� �ֽ��ϴ�.

�װ� �����ȣ ���̿��� �׻� ������ �����մϴ�.

������ ���ӵ��� ������ �����̳� ������ ������ �����ϴ�.

�ϳ��� �׿��� ������ ���� �տ� ���� ���� �����ϴ�.

" + 3xx + + x7 + "�� ���� �߸��� �Է��� �־����� �ʽ��ϴ�.

0���� �����ϴ� ���� �����ϴ�.

���ڿ� ���� ������ ���ϱ�� �����մϴ�.

polynomial���� ���� �װ� ����׸� �����մϴ�.

��� 1�� �����մϴ�.

�ᱣ���� ������� �������� �Ӵϴ�.

0 < polynomial�� ���� < 50
         */

        public static string FindPolynomial(string polynomial)
        {
            string answer = "";
            string[] calc;
            calc = polynomial.Split(" ");

            int xNum = 0;
            int num = 0;
            bool xChk = false;
            foreach (var item in calc)
            {
                if (item.Contains("x"))
                {
                    xChk = true;
                    string[] xStr = item.Split("x");
                    if (int.TryParse(xStr[0], out int result))
                    {
                        xNum += result;
                    }
                    else xNum++;
                }
                else if (item.Contains("+"))
                {
                    continue;
                }
                else
                {
                    xChk = false;
                    num += int.Parse(item);
                }
            }
            if (xNum > 0)
            {
                answer = xNum == 1 ? "x" : xNum + "x";
                if (num > 0) answer += " + " + num;
            }
            else
            {
                if (num > 0) answer = num.ToString();
                else answer = "0";
            }
            return answer;
        }

        #endregion

        #region �����ִ� ������ ����(2)

        /*
         * ���� ����
���ڿ� my_string�� �Ű������� �־����ϴ�. my_string�� �ҹ���, �빮��, �ڿ����θ� �����Ǿ��ֽ��ϴ�. my_string���� �ڿ������� ���� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� my_string�� ���� �� 1,000
1 �� my_string ���� �ڿ��� �� 1000
���ӵ� ���� �ϳ��� ���ڷ� �����մϴ�.
000123�� ���� 0�� �����ϴ� ���� �����ϴ�.
���ڿ��� �ڿ����� ���� ��� 0�� return ���ּ���.
         */

        public static int AddHideNumber(string my_string)
        {
            my_string += "a";
            int answer = 0;
            int temp = 0;

            string[] str = Regex.Replace(my_string, @"[^0-9]", " ").Split(" ");

            foreach (var item in str)
            {
                Debug.Log(item);
                Debug.Log(" ");
            }

            foreach (var item in my_string)
            {
                if (char.IsNumber(item))
                {
                    temp = temp * 10 + int.Parse(item.ToString());
                }
                else
                {
                    answer += temp;
                    temp = 0;
                }
            }

            return answer;
        }

        //Other Solution
        // string[] str = Regex.Replace(my_string,@"[^0-9]"," ").Split(' ');
        //@"[^0-9]" : 0-9�� ������ ������
        //@"[0-9]" : 0-9��
        //^ �� ǥ�ô� �ݴ��
        //Regex.Replace(string,pattern,input)

        #endregion

        #region ��������(����ã��)

        /*
         * ���� ����
���� �׸��� ���� ���ڰ� �ִ� ������ ���ڿ� ������ ��, �Ʒ�, ��, �� �밢�� ĭ�� ��� ������������ �з��մϴ�.
image.png
���ڴ� 2���� �迭 board�� 1�� ǥ�õǾ� �ְ� board���� ���ڰ� �ż� �� ���� 1��, ���ڰ� ���� ���� 0�� �����մϴ�.
���ڰ� �ż��� ������ ���� board�� �Ű������� �־��� ��, ������ ������ ĭ ���� return�ϵ��� solution �Լ��� �ϼ����ּ���.
         */

        public static int Safezone(int[,] board)
        {
            int answer = board.Length;
            int[] x = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] y = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int len = board.GetLength(0);
            int[,] tempBoard = new int[len, len];
            int tempX, tempY;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (board[i, j] == 1)
                    {
                        tempBoard[i, j] = 1;
                        for (int k = 0; k < 8; k++)
                        {
                            tempX = i + x[k];
                            tempY = j + y[k];
                            if (tempX < len && tempX >= 0 && tempY < len && tempY >= 0)
                            {
                                tempBoard[tempX, tempY] = 1;
                            }
                        }
                    }
                }
            }

            foreach (var item in tempBoard)
            {
                if (item == 1) answer--;
            }

            return answer;
        }

        #endregion

        #region �ﰢ���� �ϼ�����(2)

        /*
         * ���� ����
���� �� ���� �ﰢ���� ����� ���ؼ��� ������ ���� ������ �����ؾ� �մϴ�.

���� �� ���� ���̴� �ٸ� �� ���� ������ �պ��� �۾ƾ� �մϴ�.
�ﰢ���� �� ���� ���̰� ��� �迭 sides�� �Ű������� �־����ϴ�. ������ �� ���� �� �� �ִ� ������ ������ return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
sides�� ���Ҵ� �ڿ����Դϴ�.
sides�� ���̴� 2�Դϴ�.
1 �� sides�� ���� �� 1,000
         */

        public static int CompletionConditionOfTriangle2(int[] sides)
        {
            int answer = 0;

            answer = (sides.Max() + sides.Min()) - (sides.Max() - (sides.Min() - 1));

            return answer;
        }

        #endregion

        #region �ܰ�� ����

        /*
         * ���� ����
PROGRAMMERS-962 �༺�� �ҽ����� ���ֺ���� �Ӿ��̴� �ܰ��༺�� �� �����Ϸ��� �մϴ�. ���ĺ��� ��� �迭 spell�� �ܰ�� ���� dic�� �Ű������� �־����ϴ�. spell�� ��� ���ĺ��� �ѹ����� ��� ����� �ܾ dic�� �����Ѵٸ� 1, �������� �ʴ´ٸ� 2�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
spell�� dic�� ���Ҵ� ���ĺ� �ҹ��ڷθ� �̷�����ֽ��ϴ�.
2 �� spell�� ũ�� �� 10
spell�� ������ ���̴� 1�Դϴ�.
1 �� dic�� ũ�� �� 10
1 �� dic�� ������ ���� �� 10
spell�� ���Ҹ� ��� ����� �ܾ ������ �մϴ�.
spell�� ���Ҹ� ��� ����� ���� �� �ִ� �ܾ�� dic�� �� �� �̻� �������� �ʽ��ϴ�.
dic�� spell ��� �ߺ��� ���Ҹ� ���� �ʽ��ϴ�.
         */

        public static int AlienDictionary(string[] spell, string[] dic)
        {
            int answer = 1;

            foreach (var item in dic)
            {
                bool chk = true;
                foreach (var ch in spell)
                {
                    if (!item.Contains(ch))
                    {
                        chk = false;
                        break;
                    }
                }

                if (chk)
                {
                    answer = 1; break;
                }
                else answer = 2;
            }

            return answer;
        }

        #endregion

        #region ������ ���� 3

        /*
         * ���� ����
3x ���� ������� 3�� ������ ���ڶ�� �����ϱ� ������ 3�� ����� ���� 3�� ������� �ʽ��ϴ�. 3x ���� ������� ���ڴ� ������ �����ϴ�.

|10����    |3x �������� ���� ����	    |10����	    |3x �������� ���� ����
|   1	   |             1	        | 6	        |            8
|   2	   |             2	        | 7	        |            10
|   3	   |             4	        | 8	        |            11
|   4	   |             5	        | 9	        |            14
|   5	   |             7	        | 10	    |            16
���� n�� �Ű������� �־��� ��, n�� 3x �������� ����ϴ� ���ڷ� �ٲ� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� n �� 100
         */

        public static int NumberThreeOfCurses(int n)
        {
            int answer = 0;

            int temp = 1;
            for (int i = 1; i <= n; i++)
            {
                if (temp < i) temp = i;
                while (true)
                {
                    if (temp % 3 != 0)
                    {
                        if (temp.ToString().Contains('3') == false) break;
                    }
                    temp++;
                }
                answer = temp;
                temp++;
            }
            return answer;
        }

        #endregion

        #region ����

        /*
         * ���� ����
�� �� ���� ��ǥ�� ���� ������ �迭  dots�� ������ ���� �Ű������� �־����ϴ�.

[[x1, y1], [x2, y2], [x3, y3], [x4, y4]]
�־��� �� ���� ���� �� ���� �̾��� ��, �� ������ ������ �Ǵ� ��찡 ������ 1�� ������ 0�� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
dots�� ���� = 4
dots�� ���Ҵ� [x, y] �����̸� x, y�� �����Դϴ�.
0 �� x, y �� 100
���� �ٸ� �ΰ� �̻��� ���� ��ġ�� ���� �����ϴ�.
�� ������ ��ġ�� ���(��ġ�ϴ� ���)���� 1�� return ���ּ���.
������ �� ���� ���� ������ x�� �Ǵ� y��� ������ ���� �־����� �ʽ��ϴ�.
         */

        public static int Parallel(int[,] dots)
        {
            double GetVec(int x1, int x2, int y1, int y2)
            {
                //0!=0.0
                // 0.0�� 0�� �ƴ϶� 0�� �ٻ�
                double x = (x2 - x1) == 0 ? 0.0 : (x2 - x1);
                double y = (y2 - y1) == 0 ? 0.0 : (y2 - y1);

                return y / x;
            }
            int answer = 0;

            if (GetVec(dots[0, 0], dots[1, 0], dots[0, 1], dots[1, 1]) == GetVec(dots[2, 0], dots[3, 0], dots[2, 1], dots[3, 1])) return 1;
            if (GetVec(dots[0, 0], dots[2, 0], dots[0, 1], dots[2, 1]) == GetVec(dots[1, 0], dots[3, 0], dots[1, 1], dots[3, 1])) return 1;
            if (GetVec(dots[0, 0], dots[3, 0], dots[0, 1], dots[3, 1]) == GetVec(dots[1, 0], dots[2, 0], dots[1, 1], dots[2, 1])) return 1;

            return answer;

        }


        #endregion

        #region ��ġ�� ������ ����

        /*
         * ���� �ϼ��غ�����.

������ �� �� �̻� ��ģ ���� [-2, -1], [0, 1]�� ���� 2��ŭ �����ֽ��ϴ�.

���ѻ���
lines�� ���� = 3
lines�� ������ ���� = 2
��� ������ ���̰� 1 �̻��Դϴ�.
lines�� ���Ҵ� [a, b] �����̸�, a, b�� ���� ������ �� ���� �Դϴ�.
-100 �� a < b �� 100
         */

        public static int LengthOfOverlapLine(int[,] lines)
        {
            int answer = 0;

            int[] arr = new int[200];

            for (int i = 0; i < 3; i++)
            {
                for (int j = lines[i, 0]; j < lines[i, 1]; j++)
                {
                    arr[j + 100]++;
                }
            }

            foreach (var item in arr)
            {
                if (item > 1) answer++;
            }


            return answer;
        }

        #endregion

        #region ���ѼҼ� �Ǻ��ϱ�

        /*
         * ���� ����
�Ҽ��� �Ʒ� ���ڰ� ��ӵ��� �ʰ� ���Ѱ��� �Ҽ��� ���ѼҼ���� �մϴ�. �м��� �Ҽ��� ��ĥ �� ���ѼҼ��� ��Ÿ�� �� �ִ� �м����� �Ǻ��Ϸ��� �մϴ�. ���ѼҼ��� �Ǳ� ���� �м��� ������ ������ �����ϴ�.

���м��� ��Ÿ������ ��, �и��� ���μ��� 2�� 5�� �����ؾ� �մϴ�.
�� ���� a�� b�� �Ű������� �־��� ��, a/b�� ���ѼҼ��̸� 1��, ���ѼҼ���� 2�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
a, b�� ����
0 < a �� 1,000
0 < b �� 1,000
         */

        public static int DetermineTheFiniteNum(int a, int b)
        {
            int answer = 0;

            while (b % 2 == 0) b /= 2;
            while (b % 5 == 0) b /= 5;

            answer = a % b == 0 ? 1 : 2;

            return answer;
        }

        #endregion

        #region Ư���� ����

        /*
         * ���� ����
���� n�� �������� n�� ����� ������ �����Ϸ��� �մϴ�. �̶� n���κ����� �Ÿ��� ���ٸ� �� ū ���� �տ� ������ ��ġ�մϴ�. ������ ��� �迭 numlist�� ���� n�� �־��� �� numlist�� ���Ҹ� n���κ��� ����� ������� ������ �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� n �� 10,000
1 �� numlist�� ���� �� 10,000
1 �� numlist�� ���� �� 100
numlist�� �ߺ��� ���Ҹ� ���� �ʽ��ϴ�.
         */

        public static int[] UniqueArray(int[] numlist, int n)
        {
            return numlist.OrderBy(x => Math.Abs(x - n)).ThenByDescending(x => x).ToArray();
        }

        #endregion

        #region ��� �ű��

        /*
         * ���� ����
���� ������ ���� ������ ��� ������ �������� �л����� ����� �ű���� �մϴ�. ���� ������ ���� ������ ���� 2���� ���� �迭 score�� �־��� ��, ���� ������ ���� ������ ����� �������� �ű� ����� ���� �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
0 �� score[0], score[1] �� 100
1 �� score�� ���� �� 10
score�� ���� ���̴� 2�Դϴ�.
score�� �ߺ��� ���Ҹ� ���� �ʽ��ϴ�.
         */

        public static int[] DetermineGrade(int[,] score)
        {
            int[] answer = new int[] { };
            List<int> ans = new List<int>();

            int[] temp = new int[score.GetLength(0)];
            for (int i = 0; i < score.GetLength(0); i++)
            {
                ans.Add(score[i, 0] + score[i, 1]);
            }

            ans = ans.Distinct().OrderByDescending(x => x).ToList();

            int idx = 1;
            int chk = 0;
            for (int i = 0; i < ans.Count; i++)
            {
                chk = 0;
                for (int j = 0; j < score.GetLength(0); j++)
                {
                    if (ans[i] == score[j, 0] + score[j, 1])
                    {
                        Debug.Log($"{j} : {i} | {ans[i]},{score[j, 0] + score[j, 1]}");
                        temp[j] = idx;

                        chk++;
                    }
                }
                idx++;
                if (chk > 1) idx += chk - 1;
            }

            answer = temp;

            //Other Solution
            /*
            List<int> ans = new List<int>();
            List<int> temp = new List<int>();
            List<int> temp2 = new List<int>();

            for (int i = 0; i < score.GetLength(0); i++)
            {
                temp.Add(score[i, 0] + score[i, 1]);
            }

           temp2 = temp.OrderByDescending(x => x).ToList();
           foreach (var item in temp2)
            {
                Debug.Log(item);
            }
            for (int i = 0; i < score.GetLength(0); i++)
            {
                ans.Add(temp2.FindIndex(x => x == temp[i]) + 1);
            }
            return answer = ans.ToArray();
             */
            return answer;
        }

        #endregion

        #region �˾���(1)

        /*
         * ���� ����
�Ӿ��̴� �¾ �� 6���� �� ��ī�� ������ �ֽ��ϴ�. ��ī�� ���� "aya", "ye", "woo", "ma" �� ���� ������ �ִ� �� ���� ����� ������(�̾� ����) �����ۿ� ���� ���մϴ�. ���ڿ� �迭 babbling�� �Ű������� �־��� ��, �Ӿ����� ��ī�� ������ �� �ִ� �ܾ��� ������ return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� babbling�� ���� �� 100
1 �� babbling[i]�� ���� �� 15
babbling�� �� ���ڿ����� "aya", "ye", "woo", "ma"�� ���� �ִ� �� ������ �����մϴ�.
��, �� ���ڿ��� ������ ��� �κ� ���ڿ� �߿��� "aya", "ye", "woo", "ma"�� �� ������ �����մϴ�.
���ڿ��� ���ĺ� �ҹ��ڷθ� �̷���� �ֽ��ϴ�.
         */

        public static int Babbling(string[] babbling)
        {
            int answer = 0;
            string[] zip = { "aya", "ye", "woo", "ma" };

            //foreach ���� elem ���� ������ �Ұ�(�б�����)
            for (int i = 0; i < babbling.Length; i++)
            {
                foreach (var str in zip)
                {
                    babbling[i] = babbling[i].Replace(str, "-");
                }

                if (babbling[i].Replace("-", "") == "") answer++;
            }


            return answer;
        }

        #endregion

        #region �α��� ����?

        /*
         * ���� ����
�Ӿ��̴� ���α׷��ӽ��� �α����Ϸ��� �մϴ�. �Ӿ��̰� �Է��� ���̵�� �н����尡 ��� �迭 id_pw�� ȸ������ ������ ��� 2���� �迭 db�� �־��� ��, ������ ���� �α��� ����, ���п� ���� �޽����� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���̵�� ��й�ȣ�� ��� ��ġ�ϴ� ȸ�������� ������ "login"�� return�մϴ�.
�α����� �������� �� ���̵� ��ġ�ϴ� ȸ���� ���ٸ� ��fail����, ���̵�� ��ġ������ ��й�ȣ�� ��ġ�ϴ� ȸ���� ���ٸ� ��wrong pw���� return �մϴ�.
���ѻ���
ȸ������ ���̵�� ���ڿ��Դϴ�.
ȸ������ ���̵�� ���ĺ� �ҹ��ڿ� ���ڷθ� �̷���� �ֽ��ϴ�.
ȸ������ �н������ ���ڷ� ������ ���ڿ��Դϴ�.
ȸ������ ��й�ȣ�� ���� �� ������ ���̵�� ���� �� �����ϴ�.
id_pw�� ���̴� 2�Դϴ�.
id_pw�� db�� ���Ҵ� [���̵�, �н�����] �����Դϴ�.
1 �� ���̵��� ���� �� 15
1 �� ��й�ȣ�� ���� �� 6
1 �� db�� ���� �� 10
db�� ������ ���̴� 2�Դϴ�.
         */

        public static string IsLoginSuccess(string[] id_pw, string[,] db)
        {
            string answer = "";

            bool idChk = false;
            bool pwChk = false;
            for (int i = 0; i < db.GetLength(0); i++)
            {
                pwChk = false;

                if (id_pw[0].Equals(db[i, 0])) idChk = true;
                if (id_pw[1].Equals(db[i, 1]) && idChk) pwChk = true;

                if (idChk & !pwChk) break;
            }

            if (idChk & pwChk) answer = "login";
            else if (idChk && !pwChk) answer = "wrong pw";
            else answer = "fail";

            return answer;

        }
        #endregion

        #region ġŲ ����

        /*
         * ���� ����
���α׷��ӽ� ġŲ�� ġŲ�� ���Ѹ����� �� ������ ������ �� �� �߱��մϴ�. ������ �� �� ������ ġŲ�� �� ���� ���񽺷� ���� �� �ְ�, ���� ġŲ���� ������ �߱޵˴ϴ�. ���Ѹ��� ġŲ�� �� chicken�� �Ű������� �־��� �� ���� �� �ִ� �ִ� ���� ġŲ�� ���� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
chicken�� �����Դϴ�.
0 �� chicken �� 1,000,000
         */

        public static int ChickenCoupon(int chicken)
        {
            int answer = 0;
            int coupon = chicken;

            int order = 0;
            while (coupon > 9)
            {
                order = 0;
                order = coupon / 10;
                coupon -= order * 10;
                coupon += order;

                answer += order;
            }

            return answer;
        }

        #endregion

        #region ������ ���ϱ�

        /*
         * ���� ����
�������� �ǹ��ϴ� �� ���� ���ڿ� bin1�� bin2�� �Ű������� �־��� ��, �� �������� ���� return�ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
return ���� �������� �ǹ��ϴ� ���ڿ��Դϴ�.
1 �� bin1, bin2�� ���� �� 10
bin1�� bin2�� 0�� 1�θ� �̷���� �ֽ��ϴ�.
bin1�� bin2�� "0"�� �����ϰ� 0���� �������� �ʽ��ϴ�.
         */

        public static string AddBinaryNumber(string bin1, string bin2)
        {
            string answer = "";

            answer = Convert.ToString(Convert.ToInt32(bin1, 2) + Convert.ToInt32(bin2, 2), 2);

            return answer;
        }

        #endregion

        #region A�� B �����

        /*
         * ���� ����
���ڿ� before�� after�� �Ű������� �־��� ��, before�� ������ �ٲپ� after�� ���� �� ������ 1��, ���� �� ������ 0�� return �ϵ��� solution �Լ��� �ϼ��غ�����.

���ѻ���
0 < before�� ���� == after�� ���� < 1,000
before�� after�� ��� �ҹ��ڷ� �̷���� �ֽ��ϴ�.
         */

        public static int MakeBWithA(string before, string after)
        {
            int answer = 0;

            answer = String.Concat(before.OrderBy(x => x)) == String.Concat(after.OrderBy(y => y)) ? 1 : 0;

            return answer;
        }
        #endregion

        #region k�� ����

        /*
         * ���� ����
1���� 13������ ������, 1�� 1, 10, 11, 12, 13 �̷��� �� 6�� �����մϴ�. ���� i, j, k�� �Ű������� �־��� ��, i���� j���� k�� �� �� �����ϴ��� return �ϵ��� solution �Լ��� �ϼ����ּ���.

���ѻ���
1 �� i < j �� 100,000
0 �� k �� 9
         */

        public static int NumberOfK(int i, int j, int k)
        {
            int answer = 0;
            char chk = Convert.ToChar(k.ToString());

            for (int start = i; start <= j; start++)
            {
                string str = start.ToString();
                answer += str.Count(x => (x == chk));

            }
            return answer;

        }
        #endregion
    }
}
