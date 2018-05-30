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
            StartCoroutine(VisionAPIUtils.MakeAnalysisRequest(bytes, "txtImageInfo", typeof(Text)));
        }
    }
}