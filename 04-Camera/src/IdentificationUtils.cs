using UnityEngine;
using UnityEngine.UI;

class IdentificationUtils
{
    public static void Identify()
    {
        //Text myText = GameObject.Find("test").GetComponent<Text>();
        //byte[] image = CameraUtils.TakePicture();
        //new CameraUtils().Identify(myText);
        new CameraUtils().Identify();
        //string imageLabel = VisionAPI.GetImageLabel(image);
        //setText(imageLabel);
    }

    //private static void setText(string labelText)
    //{
    //    Text myText = GameObject.Find("test").GetComponent<Text>();
    //    myText.text = labelText;
    //}
}
