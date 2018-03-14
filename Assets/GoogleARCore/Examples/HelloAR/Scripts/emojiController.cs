using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.HelloAR;

public class emojiController : MonoBehaviour {
    public HelloARController helloCTRL;
    public ButtonScript buttonScriptConnection;

    public bool isSelected = false;
    public GameObject cubeEmoji;
    public GameObject sphereEmoji;
    public GameObject cylinderEmoji;
    public GameObject buttonObject;
    public GameObject openingObject;
    public GameObject instructionsObject;

    // Use this for initialization
    void Start () {
        helloCTRL = transform.GetComponent<HelloARController>();
        buttonObject.SetActive(false);
        instructionsObject.SetActive(false);
        openingObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
 
    }


    public void OpeningClick()
    {
        instructionsObject.SetActive(true);
        openingObject.SetActive(false);
    }

    public void InstructionsClick()
    {
        buttonObject.SetActive(true);
        instructionsObject.SetActive(false);
    }

    public void SelectionClicked(string clickedName)
    {
        Debug.Log("SelectionClicked invoked " + clickedName);

        if (clickedName == "Sphere")
        {
            SwitchEmoji(sphereEmoji);
        }

        else if (clickedName == "Cube")
        {
            SwitchEmoji(cubeEmoji);
        }

       else if (clickedName == "Cylinder")
        {
            SwitchEmoji(cylinderEmoji);
        }


    }


    void SwitchEmoji(GameObject newEmoji)
    {
        helloCTRL.AndyAndroidPrefab = newEmoji;

     }
}
