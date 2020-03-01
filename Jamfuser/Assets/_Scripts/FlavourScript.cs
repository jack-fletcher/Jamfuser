using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FlavourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    public void ShowText(string text)
    {
        //Do animatoin

        //Show text
        gameObject.SetActive(true);
        this.GetComponent<TextMeshProUGUI>().text = text;
        Invoke("Dissapear", 1f);
    }


    private void Dissapear()
    {
        Debug.Log("smasd");
        this.GetComponent<TextMeshProUGUI>().text = "";
        gameObject.SetActive(false);
    }
}
