using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    //public Button yourButton;

    void Start()
    {
        //Button btn = yourButton.GetComponent<Button>();
        Button btnIdentify = GameObject.Find("btnIdentify").GetComponent<Button>();
        btnIdentify.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        IdentificationUtils.Identify();
        //byte[] image = CameraUtils.GetSnapshot();
        //string imageLabel = VisionAPI.GetImageLabel(image);
        //setText(imageLabel);
    }

    /*
    public Texture tex;
    void OnGUI()
    {
        if (!tex)
            setText("No texture found, please assign a texture on the inspector");

        if (GUILayout.Button(tex))
            setText("Clicked the image");

        if (GUILayout.Button("I am a regular Automatic Layout Button"))
            setText("Clicked Button");

    }
    */

    /*
    private static void setText(string labelText)
    {
        Text myText = GameObject.Find("txtImageInfo").GetComponent<Text>();
        myText.text = labelText;
    }
    */
}