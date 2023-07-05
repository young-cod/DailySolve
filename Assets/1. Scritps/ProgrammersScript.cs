using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsTools;
using System.Linq;
using System.Text.RegularExpressions;

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
                while(n % i == 0)
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
    }
}
