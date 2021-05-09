using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transitionAnimator;

    public void Transition(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitionAnimator.SetTrigger("out");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
