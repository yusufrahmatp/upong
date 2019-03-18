using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ReturnMainMenu : MonoBehaviour
{

    public Text flashingText;
    public string textToFlash = "I AM FLASHING";
    string blankText = "";
    //flag to determine if you want the blinking to happen
    bool isBlinking = true;

    void Start()
    {
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    private void Update()
    {
        if (Input.GetKey("enter") || Input.GetKey("return"))
        {
            Destroy(GameObject.Find("Menu UI"));
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    //function to blink the text 
    public IEnumerator BlinkText()
    {
        while (isBlinking)
        {
            //set the Text's text to blank
            flashingText.text = blankText;
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display text for the next 0.5 seconds
            flashingText.text = textToFlash;
            yield return new WaitForSeconds(.5f);
        }
    }
}