using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceRotate : MonoBehaviour
{
    #region 배열 회전시키기
    /*
     * ==========문제 설명=========
        정수가 담긴 배열 numbers와 문자열 direction가 매개변수로 주어집니다. 배열 numbers의 원소를 direction방향으로 한 칸씩 회전시킨 배열을 return하도록 solution 함수를 완성해주세요.

       ========제한사항============
        3 ≤ numbers의 길이 ≤ 20
        direction은 "left" 와 "right" 둘 중 하나입니다.
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
