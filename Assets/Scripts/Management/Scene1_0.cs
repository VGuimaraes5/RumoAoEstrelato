using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_0 : MonoBehaviour
{

    [SerializeField]
    private string nextScene;
    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private Fungus.Flowchart flowchart;

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("SceneEnd"))
        {
            StartCoroutine(FinishLevel());
        }
    }

    IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(2f);
        sceneLoader.Transition(nextScene);
    }
}
