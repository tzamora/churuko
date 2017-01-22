using UnityEngine;
using System.Collections;

//This script goes on the camera object
public class FadeInOut : MonoBehaviour
{

    //The fade direction, -1 means from texture to no texture, 1 means the opposite
    public float fadeDirection = -1;
    //The speed which the fading process will be performed
    public float fadeSpeed = 0.3f;
    //The initial alpha for the texture
    public float alpha = 1.0f;
    //The texture we are going to use
    public Texture2D fadeOutTexture;


    // Use this for initialization
    void Start()
    {
        //TODO change this so we can control it from the editor ONLY
        //alpha=1.0f;
        //fadeIn(); //Perhaps this should not be here
        // fadeOutTexture = Resources.Load("UI/white") as Texture2D;

        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Magic
    void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;// Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        UnityEngine.Color temp = GUI.color;
        temp.a = alpha;
        GUI.color = temp;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

    }

    //This 2 methods change the direction of the fade
    public void fadeIn()
    {
        fadeDirection = -1;
    }


    public void fadeOut()
    {
        fadeDirection = 1;
    }

    public bool AreWeDone()
    {
        if (fadeDirection == -1 && alpha == 0)
        {
            return true;
        }
        else if (fadeDirection == 1 && alpha == 1)
        {
            return true;
        }
        return false;
    }

}
