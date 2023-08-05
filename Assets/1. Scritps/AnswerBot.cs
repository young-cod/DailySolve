using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        int[,] abc = {{1, 4}, {1, 4}, {1, 4} };
        Debug.Log(Solution.DetermineTheFiniteNum(1,1));
        Debug.Log(Solution.DetermineTheFiniteNum(3,7));
        Debug.Log(Solution.DetermineTheFiniteNum(7,20));
        Debug.Log(Solution.DetermineTheFiniteNum(11,22));
        Debug.Log(Solution.DetermineTheFiniteNum(12,21));

    }
}
