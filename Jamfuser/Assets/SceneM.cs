using System.Collections;
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
        //Loads main menu
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Restart()
    {
        Debug.Log("Restart pressed");
        ///Loads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
