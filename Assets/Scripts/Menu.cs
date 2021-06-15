using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;

    public void StartGame()
    {
        StartCoroutine(StartAto1("Ato1_0"));
    }

    public void ShowCredits()
    {
        sceneLoader.Transition("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartAto1(string scene)
    {
        yield return new WaitForSeconds(2f);
        sceneLoader.Transition(scene);
    }
}
