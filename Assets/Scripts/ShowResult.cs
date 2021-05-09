using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    [SerializeField]
    private Text resultText;

    void Start()
    {
        resultText.text = ResultStorage.lastResult ? "Acertô miseravi!" : "Verrgonha da profissôm!";
    }

}
