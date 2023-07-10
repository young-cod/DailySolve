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

    }
}
