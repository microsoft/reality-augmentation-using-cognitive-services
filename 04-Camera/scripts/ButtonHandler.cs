using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    void Start()
    {
        Button btnGo = GameObject.Find("btnGo").GetComponent<Button>();
        btnGo.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        CameraUtils.Identify();
    }
}