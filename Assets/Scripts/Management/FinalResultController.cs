using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalResultController : MonoBehaviour
{
    [SerializeField]
    private Fungus.Flowchart flowchart;

    void Start()
    {
        flowchart.SetBooleanVariable("resultCozinha", ResultStorage.resultCozinha);
        flowchart.SetIntegerVariable("escolhaCozinha", (int)ResultStorage.escolhaCozinha);

        flowchart.SetBooleanVariable("resultCarregamento", ResultStorage.resultCarregamento);
        flowchart.SetIntegerVariable("escolhaCarregamento", (int)ResultStorage.escolhaCarregamento);

        flowchart.SetBooleanVariable("resultAtendimento", ResultStorage.resultAtendimento);
        flowchart.SetIntegerVariable("escolhaAtendimento", (int)ResultStorage.escolhaAtendimento);
    }

}
