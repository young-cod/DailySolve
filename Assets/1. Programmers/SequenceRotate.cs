using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceRotate : MonoBehaviour
{
    #region �迭 ȸ����Ű��
    /*
     * ==========���� ����=========
        ������ ��� �迭 numbers�� ���ڿ� direction�� �Ű������� �־����ϴ�. �迭 numbers�� ���Ҹ� direction�������� �� ĭ�� ȸ����Ų �迭�� return�ϵ��� solution �Լ��� �ϼ����ּ���.

       ========���ѻ���============
        3 �� numbers�� ���� �� 20
        direction�� "left" �� "right" �� �� �ϳ��Դϴ�.
     */
    #endregion
    public int[] numbers;
    public string direction;

    void Start()
    {
        foreach (var item in Solution(numbers, direction))
        {
            Debug.Log(item);
        }
    }

    int[] Solution(int[] nums, string dir)
    {
        int[] answer = new int[nums.Length];

        if (dir == "left")
        {
            answer[nums.Length-1] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                answer[i-1] = nums[i];
            }
        }
        else
        {
            answer[0] = nums[nums.Length - 1];
            for (int i = 0; i < nums.Length-1; i++)
            {
                answer[i+1] = nums[i];
            }
        }

        return answer;
    }
}
