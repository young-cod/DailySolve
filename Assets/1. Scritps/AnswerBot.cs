using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        int[,] abc = {{1, 4}, {1, 4}, {1, 4} };
        Debug.Log(Solution.LengthOfOverlapLine(abc));

    }
}
