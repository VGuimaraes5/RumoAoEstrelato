using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene); //FUN��O VINICIUS
    }

    public void QuitGame()
    {
        //Editor Unity
        UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        //Application.Quit();
    }
}
