using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsTools;
using System.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ProgrammersScript
{
    public static class Solution
    {
        #region Factorial
        /*
         * 문제 설명
        i팩토리얼 (i!)은 1부터 i까지 정수의 곱을 의미합니다. 예를들어 5! = 5 * 4 * 3 * 2 * 1 = 120 입니다. 정수 n이 주어질 때 다음 조건을 만족하는 가장 큰 정수 i를 return 하도록 solution 함수를 완성해주세요.

        i! ≤ n
        제한사항
        0 < n ≤ 3,628,800
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

        #region 배열 회전시키기
        /*
         * ==========문제 설명=========
            정수가 담긴 배열 numbers와 문자열 direction가 매개변수로 주어집니다. 배열 numbers의 원소를 direction방향으로 한 칸씩 회전시킨 배열을 return하도록 solution 함수를 완성해주세요.

           ========제한사항============
            3 ≤ numbers의 길이 ≤ 20
            direction은 "left" 와 "right" 둘 중 하나입니다.
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

        #region 주사위의 개수
        /*
     * 문제 설명
    머쓱이는 직육면체 모양의 상자를 하나 가지고 있는데 이 상자에 정육면체 모양의 주사위를 최대한 많이 채우고 싶습니다. 상자의 가로, 세로, 높이가 저장되어있는 배열 box와 주사위 모서리의 길이 정수 n이 매개변수로 주어졌을 때, 상자에 들어갈 수 있는 주사위의 최대 개수를 return 하도록 solution 함수를 완성해주세요.

    제한사항
    box의 길이는 3입니다.
    box[0] = 상자의 가로 길이
    box[1] = 상자의 세로 길이
    box[2] = 상자의 높이 길이
    1 ≤ box의 원소 ≤ 100
    1 ≤ n ≤ 50
    n ≤ box의 원소
    주사위는 상자와 평행하게 넣습니다.
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

        #region 공 던지기
        /*
            <문제 설명>
        머쓱이는 친구들과 동그랗게 서서 공 던지기 게임을 하고 있습니다. 공은 1번부터 던지며 오른쪽으로 한 명을 건너뛰고 그다음 사람에게만 던질 수 있습니다. 친구들의 번호가 들어있는 정수 배열 numbers와 정수 K가 주어질 때, k번째로 공을 던지는 사람의 번호는 무엇인지 return 하도록 solution 함수를 완성해보세요.

            <제한사항>
        2 < numbers의 길이 < 100
        0 < k < 1,000
        numbers의 첫 번째와 마지막 번호는 실제로 바로 옆에 있습니다.
        numbers는 1부터 시작하며 번호는 순서대로 올라갑니다.
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
             * =============더 간단한 정답 =====================
             * answer = numbers[((k * 2) - 2) % numbers.Length]; 
             */
            return answer;
        }
        #endregion

        #region 합성수 찾기
        /*
         * 문제 설명
    약수의 개수가 세 개 이상인 수를 합성수라고 합니다. 자연수 n이 매개변수로 주어질 때 n이하의 합성수의 개수를 return하도록 solution 함수를 완성해주세요.

    제한사항
    1 ≤ n ≤ 100
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

        #region 모음 제거
        /*
         * 문제 설명
영어에선 a, e, i, o, u 다섯 가지 알파벳을 모음으로 분류합니다. 문자열 my_string이 매개변수로 주어질 때 모음을 제거한 문자열을 return하도록 solution 함수를 완성해주세요.

제한사항
my_string은 소문자와 공백으로 이루어져 있습니다.
1 ≤ my_string의 길이 ≤ 1,000
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

        #region 문자열 정렬하기(1)
        /*
         * 문제 설명
문자열 my_string이 매개변수로 주어질 때, my_string 안에 있는 숫자만 골라 오름차순 정렬한 리스트를 return 하도록 solution 함수를 작성해보세요.

제한사항
1 ≤ my_string의 길이 ≤ 100
my_string에는 숫자가 한 개 이상 포함되어 있습니다.
my_string은 영어 소문자 또는 0부터 9까지의 숫자로 이루어져 있습니다. - - -
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

        #region  소인수분해

        /*
         * 문제 설명
소인수분해란 어떤 수를 소수들의 곱으로 표현하는 것입니다. 예를 들어 12를 소인수 분해하면 2 * 2 * 3 으로 나타낼 수 있습니다. 따라서 12의 소인수는 2와 3입니다. 자연수 n이 매개변수로 주어질 때 n의 소인수를 오름차순으로 담은 배열을 return하도록 solution 함수를 완성해주세요.

제한사항
2 ≤ n ≤ 10,000
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

        #region 컨트롤 제트

        /*
         * 문제 설명
숫자와 "Z"가 공백으로 구분되어 담긴 문자열이 주어집니다. 문자열에 있는 숫자를 차례대로 더하려고 합니다. 이 때 "Z"가 나오면 바로 전에 더했던 숫자를 뺀다는 뜻입니다. 숫자와 "Z"로 이루어진 문자열 s가 주어질 때, 머쓱이가 구한 값을 return 하도록 solution 함수를 완성해보세요.

제한사항
1 ≤ s의 길이 ≤ 200
-1,000 < s의 원소 중 숫자 < 1,000
s는 숫자, "Z", 공백으로 이루어져 있습니다.
s에 있는 숫자와 "Z"는 서로 공백으로 구분됩니다.
연속된 공백은 주어지지 않습니다.
0을 제외하고는 0으로 시작하는 숫자는 없습니다.
s는 "Z"로 시작하지 않습니다.
s의 시작과 끝에는 공백이 없습니다.
"Z"가 연속해서 나오는 경우는 없습니다.
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

        #region 중복된 문자 제거
        /*
         * 문제 설명
문자열 my_string이 매개변수로 주어집니다. my_string에서 중복된 문자를 제거하고 하나의 문자만 남긴 문자열을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ my_string ≤ 110
my_string은 대문자, 소문자, 공백으로 구성되어 있습니다.
대문자와 소문자를 구분합니다.
공백(" ")도 하나의 문자로 구분합니다.
중복된 문자 중 가장 앞에 있는 문자를 남깁니다.
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

        #region 가까운 수
        /*
         * 문제 설명
정수 배열 array와 정수 n이 매개변수로 주어질 때, array에 들어있는 정수 중 n과 가장 가까운 수를 return 하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ array의 길이 ≤ 100
1 ≤ array의 원소 ≤ 100
1 ≤ n ≤ 100
가장 가까운 수가 여러 개일 경우 더 작은 수를 return 합니다.
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

        #region 369게임

        /*
         * 문제 설명
머쓱이는 친구들과 369게임을 하고 있습니다. 369게임은 1부터 숫자를 하나씩 대며 3, 6, 9가 들어가는 숫자는 숫자 대신 3, 6, 9의 개수만큼 박수를 치는 게임입니다. 머쓱이가 말해야하는 숫자 order가 매개변수로 주어질 때, 머쓱이가 쳐야할 박수 횟수를 return 하도록 solution 함수를 완성해보세요.

제한사항
1 ≤ order ≤ 1,000,000
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

        #region 암호 해독

        /*
         * 문제 설명
군 전략가 머쓱이는 전쟁 중 적군이 다음과 같은 암호 체계를 사용한다는 것을 알아냈습니다.

암호화된 문자열 cipher를 주고받습니다.
그 문자열에서 code의 배수 번째 글자만 진짜 암호입니다.
문자열 cipher와 정수 code가 매개변수로 주어질 때 해독된 암호 문자열을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ cipher의 길이 ≤ 1,000
1 ≤ code ≤ cipher의 길이
cipher는 소문자와 공백으로만 구성되어 있습니다.
공백도 하나의 문자로 취급합니다.
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

        #region 대문자와 소문자

        /*
         * 문제 설명
문자열 my_string이 매개변수로 주어질 때, 대문자는 소문자로 소문자는 대문자로 변환한 문자열을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ my_string의 길이 ≤ 1,000
my_string은 영어 대문자와 소문자로만 구성되어 있습니다.
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

        #region 영어가 싫어요

        /*
         * 문제 설명
영어가 싫은 머쓱이는 영어로 표기되어있는 숫자를 수로 바꾸려고 합니다. 문자열 numbers가 매개변수로 주어질 때, numbers를 정수로 바꿔 return 하도록 solution 함수를 완성해 주세요.

제한사항
numbers는 소문자로만 구성되어 있습니다.
numbers는 "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" 들이 공백 없이 조합되어 있습니다.
1 ≤ numbers의 길이 ≤ 50
"zero"는 numbers의 맨 앞에 올 수 없습니다.
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

        #region 인덱스 바꾸기

        /*
         * 문제 설명
문자열 my_string과 정수 num1, num2가 매개변수로 주어질 때, my_string에서 인덱스 num1과 인덱스 num2에 해당하는 문자를 바꾼 문자열을 return 하도록 solution 함수를 완성해보세요.

제한사항
1 < my_string의 길이 < 100
0 ≤ num1, num2 < my_string의 길이
my_string은 소문자로 이루어져 있습니다.
num1 ≠ num2
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

        //char 나 stringBuilder 써도 됨

        #endregion

        #region 한 번만 등장한 문자

        /*
         * 문제 설명
문자열 s가 매개변수로 주어집니다. s에서 한 번만 등장하는 문자를 사전 순으로 정렬한 문자열을 return 하도록 solution 함수를 완성해보세요. 한 번만 등장하는 문자가 없을 경우 빈 문자열을 return 합니다.

제한사항
0 < s의 길이 < 1,000
s는 소문자로만 이루어져 있습니다.
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
        // string.split.Length 를 사용하여해도 됨

        #endregion

        #region 약수 구하기

        /*
         * 문제 설명
정수 n이 매개변수로 주어질 때, n의 약수를 오름차순으로 담은 배열을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ n ≤ 10,000
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

        #region 가장 큰 수 찾기

        /*
         * 문제 설명
정수 배열 array가 매개변수로 주어질 때, 가장 큰 수와 그 수의 인덱스를 담은 배열을 return 하도록 solution 함수를 완성해보세요.

제한사항
1 ≤ array의 길이 ≤ 100
0 ≤ array 원소 ≤ 1,000
array에 중복된 숫자는 없습니다.
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

        #region 문자열 계산하기

        /*
         * 문제 설명
my_string은 "3 + 5"처럼 문자열로 된 수식입니다. 문자열 my_string이 매개변수로 주어질 때, 수식을 계산한 값을 return 하는 solution 함수를 완성해주세요.

제한사항
연산자는 +, -만 존재합니다.
문자열의 시작과 끝에는 공백이 없습니다.
0으로 시작하는 숫자는 주어지지 않습니다.
잘못된 수식은 주어지지 않습니다.
5 ≤ my_string의 길이 ≤ 100
my_string을 계산한 결과값은 1 이상 100,000 이하입니다.
my_string의 중간 계산 값은 -100,000 이상 100,000 이하입니다.
계산에 사용하는 숫자는 1 이상 20,000 이하인 자연수입니다.
my_string에는 연산자가 적어도 하나 포함되어 있습니다.
return type 은 정수형입니다.
my_string의 숫자와 연산자는 공백 하나로 구분되어 있습니다.

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

        #region 숫자 찾기

        /*
         * 문제 설명
정수 num과 k가 매개변수로 주어질 때, num을 이루는 숫자 중에 k가 있으면 num의 그 숫자가 있는 자리 수를 return하고 없으면 -1을 return 하도록 solution 함수를 완성해보세요.

제한사항
0 < num < 1,000,000
0 ≤ k < 10
num에 k가 여러 개 있으면 가장 처음 나타나는 자리를 return 합니다.
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

        #region n의 배수 고르기

        /*
         * 문제 설명
정수 n과 정수 배열 numlist가 매개변수로 주어질 때, numlist에서 n의 배수가 아닌 수들을 제거한 배열을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ n ≤ 10,000
1 ≤ numlist의 크기 ≤ 100
1 ≤ numlist의 원소 ≤ 100,000
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

        #region OX퀴즈

        /*
         * 문제 설명
덧셈, 뺄셈 수식들이 'X [연산자] Y = Z' 형태로 들어있는 문자열 배열 quiz가 매개변수로 주어집니다. 수식이 옳다면 "O"를 틀리다면 "X"를 순서대로 담은 배열을 return하도록 solution 함수를 완성해주세요.

제한사항
연산 기호와 숫자 사이는 항상 하나의 공백이 존재합니다. 단 음수를 표시하는 마이너스 기호와 숫자 사이에는 공백이 존재하지 않습니다.
1 ≤ quiz의 길이 ≤ 10
X, Y, Z는 각각 0부터 9까지 숫자로 이루어진 정수를 의미하며, 각 숫자의 맨 앞에 마이너스 기호가 하나 있을 수 있고 이는 음수를 의미합니다.
X, Y, Z는 0을 제외하고는 0으로 시작하지 않습니다.
-10,000 ≤ X, Y ≤ 10,000
-20,000 ≤ Z ≤ 20,000
[연산자]는 + 와 - 중 하나입니다.
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

        #region 세균증식

        /*
         * 문제 설명
어떤 세균은 1시간에 두배만큼 증식한다고 합니다. 처음 세균의 마리수 n과 경과한 시간 t가 매개변수로 주어질 때 t시간 후 세균의 수를 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ n ≤ 10
1 ≤ t ≤ 15
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

        #region 문자열 정렬하기(2)

        /*
         * 문제 설명
영어 대소문자로 이루어진 문자열 my_string이 매개변수로 주어질 때, my_string을 모두 소문자로 바꾸고 알파벳 순서대로 정렬한 문자열을 return 하도록 solution 함수를 완성해보세요.

제한사항
0 < my_string 길이 < 100
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

        #region 7의 개수

        /*
         * 문제 설명
머쓱이는 행운의 숫자 7을 가장 좋아합니다. 정수 배열 array가 매개변수로 주어질 때, 7이 총 몇 개 있는지 return 하도록 solution 함수를 완성해보세요.

제한사항
1 ≤ array의 길이 ≤ 100
0 ≤ array의 원소 ≤ 100,000
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

        #region 잘라서 배열로 저장하기

        /*
         * 문제 설명
문자열 my_str과 n이 매개변수로 주어질 때, my_str을 길이 n씩 잘라서 저장한 배열을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ my_str의 길이 ≤ 100
1 ≤ n ≤ my_str의 길이
my_str은 알파벳 소문자, 대문자, 숫자로 이루어져 있습니다.
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

        #region 직사각형 넓이 구하기

        /*
         * 문제 설명
2차원 좌표 평면에 변이 축과 평행한 직사각형이 있습니다. 직사각형 네 꼭짓점의 좌표 [[x1, y1], [x2, y2], [x3, y3], [x4, y4]]가 담겨있는 배열 dots가 매개변수로 주어질 때, 직사각형의 넓이를 return 하도록 solution 함수를 완성해보세요.

제한사항
dots의 길이 = 4
dots의 원소의 길이 = 2
-256 < dots[i]의 원소 < 256
잘못된 입력은 주어지지 않습니다.
         */

        public static int FindRectangleArea(int[,] dots)
        {
            int answer = 1;
            int[] calc = new int[2];

            //x좌표가 같으면 y의 길이
            if (dots[0, 0] == dots[1, 0])
            {
                calc[1] = Math.Abs(dots[0, 1] - dots[1, 1]);
                calc[0] = Math.Abs(dots[0, 0] - dots[2, 0]);
            }
            //y좌표가 같으면 x의 길이
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

        #region 캐릭터의 좌표

        /*
         * 문제 설명
머쓱이는 RPG게임을 하고 있습니다. 게임에는 up, down, left, right 방향키가 있으며 각 키를 누르면 위, 아래, 왼쪽, 오른쪽으로 한 칸씩 이동합니다. 예를 들어 [0,0]에서 up을 누른다면 캐릭터의 좌표는 [0, 1], down을 누른다면 [0, -1], left를 누른다면 [-1, 0], right를 누른다면 [1, 0]입니다. 머쓱이가 입력한 방향키의 배열 keyinput와 맵의 크기 board이 매개변수로 주어집니다. 캐릭터는 항상 [0,0]에서 시작할 때 키 입력이 모두 끝난 뒤에 캐릭터의 좌표 [x, y]를 return하도록 solution 함수를 완성해주세요.

[0, 0]은 board의 정 중앙에 위치합니다. 예를 들어 board의 가로 크기가 9라면 캐릭터는 왼쪽으로 최대 [-4, 0]까지 오른쪽으로 최대 [4, 0]까지 이동할 수 있습니다.
제한사항
board은 [가로 크기, 세로 크기] 형태로 주어집니다.
board의 가로 크기와 세로 크기는 홀수입니다.
board의 크기를 벗어난 방향키 입력은 무시합니다.
0 ≤ keyinput의 길이 ≤ 50
1 ≤ board[0] ≤ 99
1 ≤ board[1] ≤ 99
keyinput은 항상 up, down, left, right만 주어집니다.
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

        #region 최댓값 만들기(2)

        /*
         * 문제 설명
정수 배열 numbers가 매개변수로 주어집니다. numbers의 원소 중 두 개를 곱해 만들 수 있는 최댓값을 return하도록 solution 함수를 완성해주세요.

제한사항
-10,000 ≤ numbers의 원소 ≤ 10,000
2 ≤ numbers 의 길이 ≤ 100
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

        #region 다항식 더하기

        /*
         * 문제 설명
한 개 이상의 항의 합으로 이루어진 식을 다항식이라고 합니다. 다항식을 계산할 때는 동류항끼리 계산해 정리합니다. 덧셈으로 이루어진 다항식 polynomial이 매개변수로 주어질 때, 동류항끼리 더한 결괏값을 문자열로 return 하도록 solution 함수를 완성해보세요. 같은 식이라면 가장 짧은 수식을 return 합니다.

제한사항
0 < polynomial에 있는 수 < 100

polynomial에 변수는 'x'만 존재합니다.

polynomial은 양의 정수, 공백, ‘x’, ‘+'로 이루어져 있습니다.

항과 연산기호 사이에는 항상 공백이 존재합니다.

공백은 연속되지 않으며 시작이나 끝에는 공백이 없습니다.

하나의 항에서 변수가 숫자 앞에 오는 경우는 없습니다.

" + 3xx + + x7 + "와 같은 잘못된 입력은 주어지지 않습니다.

0으로 시작하는 수는 없습니다.

문자와 숫자 사이의 곱하기는 생략합니다.

polynomial에는 일차 항과 상수항만 존재합니다.

계수 1은 생략합니다.

결괏값에 상수항은 마지막에 둡니다.

0 < polynomial의 길이 < 50
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

        #region 숨어있는 숫자의 덧셈(2)

        /*
         * 문제 설명
문자열 my_string이 매개변수로 주어집니다. my_string은 소문자, 대문자, 자연수로만 구성되어있습니다. my_string안의 자연수들의 합을 return하도록 solution 함수를 완성해주세요.

제한사항
1 ≤ my_string의 길이 ≤ 1,000
1 ≤ my_string 안의 자연수 ≤ 1000
연속된 수는 하나의 숫자로 간주합니다.
000123과 같이 0이 선행하는 경우는 없습니다.
문자열에 자연수가 없는 경우 0을 return 해주세요.
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
        //@"[^0-9]" : 0-9를 제외한 나머지
        //@"[0-9]" : 0-9만
        //^ 이 표시는 반대로
        //Regex.Replace(string,pattern,input)

        #endregion

        #region 안전지대(지뢰찾기)

        /*
         * 문제 설명
다음 그림과 같이 지뢰가 있는 지역과 지뢰에 인접한 위, 아래, 좌, 우 대각선 칸을 모두 위험지역으로 분류합니다.
image.png
지뢰는 2차원 배열 board에 1로 표시되어 있고 board에는 지뢰가 매설 된 지역 1과, 지뢰가 없는 지역 0만 존재합니다.
지뢰가 매설된 지역의 지도 board가 매개변수로 주어질 때, 안전한 지역의 칸 수를 return하도록 solution 함수를 완성해주세요.
         */

        public static int Safezone(int[,] board)
        {
            int answer = board.Length ;
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

        #region 삼각형의 완성조건(2)

        /*
         * 문제 설명
선분 세 개로 삼각형을 만들기 위해서는 다음과 같은 조건을 만족해야 합니다.

가장 긴 변의 길이는 다른 두 변의 길이의 합보다 작아야 합니다.
삼각형의 두 변의 길이가 담긴 배열 sides이 매개변수로 주어집니다. 나머지 한 변이 될 수 있는 정수의 개수를 return하도록 solution 함수를 완성해주세요.

제한사항
sides의 원소는 자연수입니다.
sides의 길이는 2입니다.
1 ≤ sides의 원소 ≤ 1,000
         */

        public static int CompletionConditionOfTriangle2(int[] sides)
        {
            int answer = 0;

            answer = (sides.Max() + sides.Min()) - (sides.Max() - (sides.Min() - 1));

            return answer;
        }

        #endregion

    }
}
