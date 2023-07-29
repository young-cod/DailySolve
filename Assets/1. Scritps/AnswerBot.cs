using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        int[,] abc = {{1, 5}, {1, 4}, {2, 6}, {2, 9} };
        Debug.Log(Solution.Parallel(abc));

    }
}
