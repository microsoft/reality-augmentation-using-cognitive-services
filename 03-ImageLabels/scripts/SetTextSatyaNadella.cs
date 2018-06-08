using UnityEngine;

public class SetTextSatyaNadella : MonoBehaviour {
    const string IMAGE_PATH = "satya-nadella.jpg";
    const string TEXT_COMPONENT = "SatyaNadellaText";

    // Use this for initialization
    void Start() {
        StartCoroutine(VisionAPIUtils.MakeAnalysisRequest(IMAGE_PATH, TEXT_COMPONENT, typeof(TextMesh)));
    }

    // Update is called once per frame
    void Update() {
    }
}

