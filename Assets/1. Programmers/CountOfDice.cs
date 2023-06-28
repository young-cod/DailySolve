using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountOfDice : MonoBehaviour
{
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

    public int[] boxInfo;
    public int diceInfo;

    void Start()
    {
        Debug.Log(Solution(boxInfo, diceInfo));
    }

    public int Solution(int[] box, int n)
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
}
