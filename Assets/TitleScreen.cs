using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public Texture imageToDisplay;
    public int nextLevelToLoad;

    // Update is called once per frame
    void Update ()
    {
        if (Input.anyKey)
        {
            Application.LoadLevel(nextLevelToLoad);
        }
    }

    public void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);
    }
}
