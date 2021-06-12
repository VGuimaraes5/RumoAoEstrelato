using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    [SerializeField]
    private Fungus.Flowchart flowchart;

    void Start()
    {
        flowchart.SetIntegerVariable("Choise", (int)ResultStorage.lastChoise);
        flowchart.SetBooleanVariable("Result", ResultStorage.lastResult);
    }

}
