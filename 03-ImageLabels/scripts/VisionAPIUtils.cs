using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class VisionAPIUtils
{
    const string subscriptionKey = "YOUR-SUBSCRIPTION-KEY";
    const string uriBase = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze";

    public static IEnumerator MakeAnalysisRequest(string imageFilePath, string textComponent, Type type)
    {
        byte[] bytes = GetImageAsByteArray(imageFilePath);
        return MakeAnalysisRequest(bytes, textComponent, type);
    }

    public static IEnumerator MakeAnalysisRequest(byte[] bytes, string textComponent, Type type)
    {
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", subscriptionKey },
            {"Content-Type","application/octet-stream"}
        };
        string requestParameters = "visualFeatures=Description&language=en";
        string uri = uriBase + "?" + requestParameters;
        WWW www = new WWW(uri, bytes, headers);
        yield return www;

        if (www.error != null)
        {
            setText(www.error, textComponent, type);
        }
        else
        {
            string json = www.text;
            VisionAPIResults results = JsonUtility.FromJson<VisionAPIResults>(json);
            string text = results.description.captions[0].text;
            string confidence = results.description.captions[0].confidence.ToString("0.00");
            string labelText = text + " (" + confidence + ")";
            setText(labelText, textComponent, type);
        }
    }

    private static void setText(string labelText, string textComponent, Type type)
    {
        Component component = GameObject.Find(textComponent).GetComponent(type);
        Type componentType = component.GetType();
        if (componentType == typeof(TextMesh))
        {
            ((TextMesh)component).text = labelText;
        }
        if (componentType == typeof(Text))
        {
            ((Text)component).text = labelText;
        }
    }

    private static byte[] GetImageAsByteArray(string imageFilePath)
    {
        string fileName = Path.Combine(Application.streamingAssetsPath, imageFilePath);
        return System.IO.File.ReadAllBytes(fileName);
    }
}