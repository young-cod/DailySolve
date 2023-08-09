using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        int[] array = { 10, 2 };
        int[,] array2 = { { 80, 70 }, { 90, 50 }, { 40, 70 }, { 50, 80 } };
        int[,] array3 = { {80, 70}, {70, 80}, {30, 50}, {90, 100}, {100, 90}, {100, 100}, {10, 30} };
        
        foreach (var item in Solution.DetermineGrade(array3))
        {
            Debug.Log(item);
        }

        //foreach (var item in Solution.UniqueArray(array2, 30))
        //{
        //    Debug.Log(item);
        //}
    }
}
