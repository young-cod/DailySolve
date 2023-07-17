using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgrammersScript;

public class AnswerBot : MonoBehaviour
{
    void Start()
    {
        int[] asdf = { 4, 5, 6, 7, 8, 9 };
        Solution.ChoiceMultipleOfN(3,asdf);
    }
}
