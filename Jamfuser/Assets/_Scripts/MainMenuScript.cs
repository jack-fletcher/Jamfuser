using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButton()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsButton()
    {
        Debug.Log("Options");
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        Debug.Log("Quit");
#endif
        Application.Quit();
    }
}
