using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    int n = 3600000;
    void Start()
    {
        Debug.Log(Solution.ControlZ("1 2 Z 3"));
    }
}
