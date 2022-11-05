using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject help;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Help(bool activity)
    {
        help.active = activity;
    }    

    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
