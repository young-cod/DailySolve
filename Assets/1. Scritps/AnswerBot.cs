using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        string[] asdf = { "3 - 4 = -3", "5 + 6 = 11" };

        foreach (var item in Solution.QuizOX(asdf))
        {
            Debug.Log(item);
        }
    }
}
