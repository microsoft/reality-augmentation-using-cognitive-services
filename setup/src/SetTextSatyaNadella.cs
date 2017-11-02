using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public class SetTextSatyaNadella : MonoBehaviour {

    const string subscriptionKey = "YOUR-SUBSCRIPTION-KEY";
    const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze";
    const string imageFilePath = "satya-nadella.jpg";

    // Use this for initialization
    void Start () {
        StartCoroutine(MakeAnalysisRequest(imageFilePath));
    }
	
	// Update is called once per frame
	void Update () {
	}

    static IEnumerator MakeAnalysisRequest(string imageFilePath) {
        byte[] bytes = GetImageAsByteArray(imageFilePath);
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", subscriptionKey },
            {"Content-Type","application/octet-stream"}
        };
        string requestParameters = "visualFeatures=Description&language=en";
        string uri = uriBase + "?" + requestParameters;
        WWW www = new WWW(uri, bytes, headers);

        yield return www;
        string responseData = www.text;

        // If network unavailable
        if (www.error != null) {
            responseData = "{\"description\":{\"tags\":[\"person\",\"man\",\"suit\",\"clothing\",\"wearing\",\"glasses\",\"posing\",\"standing\",\"photo\",\"jacket\",\"holding\",\"front\",\"looking\",\"camera\",\"business\",\"dressed\",\"smiling\",\"black\",\"old\",\"sign\",\"young\",\"white\"],\"captions\":[{\"text\":\"Satya Nadella wearing a suit and tie smiling at the camera\",\"confidence\":0.99060609432346514}]},\"requestId\":\"c83d3943-14dc-4b69-b9da-3b6eeb2acf2c\",\"metadata\":{\"width\":400,\"height\":400,\"format\":\"Jpeg\"}}";
        }
        string s = responseData.Split('"')[53];
        s = s.Insert(32, "\n");
        setText(s);
    }

    private static void setText(string labelText) {
        TextMesh textObject = GameObject.Find("SatyaNadellaText").GetComponent<TextMesh>();
        textObject.text = labelText;
    }

    static byte[] GetImageAsByteArray(string imageFilePath) {
        string fileName = Path.Combine(Application.streamingAssetsPath, imageFilePath);
        return System.IO.File.ReadAllBytes(fileName);
    }
}
