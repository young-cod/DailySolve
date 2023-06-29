using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIndCompositeNum : MonoBehaviour
{
    public int cnt;
    void Start()
    {
        Debug.Log(Solution(cnt));
    }

    public int Solution(int n)
    {
        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            if (GetDivisorCount(i) > 2) count++;
        }
        return count;
    }

    int GetDivisorCount(int n)
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
}
