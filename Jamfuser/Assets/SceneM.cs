﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MainMenu()
    {
        Debug.Log("Main Menu Pressed");
        //SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Debug.Log("Restart pressed");
        //SceneManager.LoadScene("MainScene");
    }
}
