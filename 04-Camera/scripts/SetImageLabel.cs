using UnityEngine;
using UnityEngine.UI;

public class SetImageLabel : MonoBehaviour
{
    public byte[] image = null;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (image != null)
        {
            byte[] bytes = image;
            image = null;

            Dropdown ddAction = GameObject.Find("ddAction").GetComponent<Dropdown>();
            int selectedAction = ddAction.value;
            switch (selectedAction)
            {
                case 0: // identify
                    StartCoroutine(VisionAPIUtils.MakeAnalysisRequest(bytes, "txtImageInfo", typeof(Text)));
                    break;
            }
        }
    }
}