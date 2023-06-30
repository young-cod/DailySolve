using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    int n = 3600000;
    void Start()
    {
        //Debug.Log(Solution.Factorial(n));    
        Solution.Factorial(n);    
    }
}
