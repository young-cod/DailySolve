using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Solution.FindPolynomial("x + 3x + 5 + 6"));

    }
}
