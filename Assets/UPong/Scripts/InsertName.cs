using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsertName : MonoBehaviour
{
    private string name = "";
    public StartOptions startOptions;

    // Start is called before the first frame update
    public void UpdateName(string newName)
    {
        name = newName;
        Debug.Log(name);
    }

    // Update is called once per frame
    public void ButtonClicked()
    {
        if (name.Length > 0)
        {
            PlayerPrefs.SetString("name", name);
            PlayerPrefs.Save();
            startOptions.StartButtonClicked();
        }
    }
}
