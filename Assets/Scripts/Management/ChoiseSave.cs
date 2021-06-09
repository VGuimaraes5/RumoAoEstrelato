using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiseSave : MonoBehaviour
{
    [SerializeField]
    private string choiseName;

    [SerializeField]
    private Fungus.Flowchart flowchart;


    void Update()
    {
        if (flowchart.GetIntegerVariable("Choise") != 0)
        {
            switch (choiseName)
            {
                case "escolhaCozinha":
                    ResultStorage.escolhaCozinha = (Choises)flowchart.GetIntegerVariable("Choise");
                    ResultStorage.lastChoise = (Choises)flowchart.GetIntegerVariable("Choise");
                    break;
                case "escolhaCarregamento":
                    ResultStorage.escolhaCozinha = (Choises)flowchart.GetIntegerVariable("Choise");
                    ResultStorage.lastChoise = (Choises)flowchart.GetIntegerVariable("Choise");
                    break;
                case "escolhaAtendimento":
                    ResultStorage.escolhaCozinha = (Choises)flowchart.GetIntegerVariable("Choise");
                    ResultStorage.lastChoise = (Choises)flowchart.GetIntegerVariable("Choise");
                    break;
            }
        }
    }

}
