using System.Collections;
using System.Collections.Generic;
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
    }
}
