using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBack : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;

    public void BackMenu()
    {
        sceneLoader.Transition("Menu");
    }
}
