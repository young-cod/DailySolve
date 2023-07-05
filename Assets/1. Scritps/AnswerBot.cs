using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    int n = 3600000;
    void Start()
    {    
     foreach (var item in Solution.Factorization(420))
        {
            Debug.Log(item);
        }
    }
}
