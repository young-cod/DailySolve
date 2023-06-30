using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YsTools
{
    public class EasyTool
    {
        public static int Factorial(int n)
        {
            int answer = 1;

            for (int i = 1; i <= n; i++)
            {
                answer *= i;
            }

            return answer;
        }
        
        //public static List<int> GetDivisorNumList(int n)
        //{
        //    List<int> list = new List<int>();

        //    return list;
        //}

        //public static bool isDivisorNum(int n)
        //{
            
        //    return false;
        //}

        //public static int GetDivisorNumCount(int n)
        //{
        //    int count = 0;

        //    for (int i = 1; i <= n; i++)
        //    {
        //        for (int j = 1; j <= i; j++)
        //        {
        //            if (i % j == 0) count++;    
        //        }
                
        //    }

        //    return count;
        //}
    }

}
