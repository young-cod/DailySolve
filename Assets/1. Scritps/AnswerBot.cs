using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        int[] array = { 10,2 };
        int[] array2 = { 10000, 20, 36, 47, 40, 6, 10, 7000 };
        int[] array3 = { 6, 10, 20, 36, 40, 47, 7000, 10000 };
        Solution.UniqueArray(array2, 30);

        //foreach (var item in Solution.UniqueArray(array2, 30))
        //{
        //    Debug.Log(item);
        //}
    }
}
