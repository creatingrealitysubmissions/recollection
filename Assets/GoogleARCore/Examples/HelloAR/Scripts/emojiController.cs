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

    // Use this for initialization
    void Start () {
        helloCTRL = transform.GetComponent<HelloARController>();

    }
	
	// Update is called once per frame
	void Update () {
    /*
     * Create an array of gameobjects
     *     Eventually, how do i populate those gameobjects in the array?
     * 
     * Create a bool to track whether an emoji has been selected
     * Create a temporary gameobject to hold the SelectedGameObject
     * 
     * Does canvas allow for onselect events?
     * Create a string to hold the SelectedGameObjectName
     * OnSelect, what is the name of what you selected
     * SelectedGameObjectName = that name
     * 
     * Use the SelectedGameObjectName to assign a specific prefab to the SelectedGameObjectName
     * 
    */
    //if (isSelected)
       // {
           /* // i need to pull in the return from ButtonScript clickMe function (its a string)
            ButtonScript.Script
            
                // how do i use the string to call a specific game object?
                selectedEmoji.GetComponent. = 
                */
        //    SwitchEmoji(selectedEmoji);

        //}
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
