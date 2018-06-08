using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    void Start()
    {
        Button btnIdentify = GameObject.Find("btnIdentify").GetComponent<Button>();
        btnIdentify.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        CameraUtils.Identify();
    }
}