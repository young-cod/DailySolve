using UnityEngine;

public class BallBounce : MonoBehaviour
{
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
    #endregion

    public int[] members;
    public int throwCount;
    void Start()
    {
        Debug.Log(Solution(members, throwCount));
    }
    int Solution(int[] numbers, int k)
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
}
