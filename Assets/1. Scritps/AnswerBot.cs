using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        string[] str = { "aya", "yee", "u", "maa", "wyeoo" };

        Debug.Log(Solution.Babbling(str));

        //foreach (var item in Solution.UniqueArray(array2, 30))
        //{
        //    Debug.Log(item);
        //}
    }
}
