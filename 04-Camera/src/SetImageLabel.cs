using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/*
 * no try-catch: https://jacksondunstan.com/articles/3718
 * https://answers.unity.com/questions/889765/how-to-create-sprite-programmatically.html
 * https://forum.unity.com/threads/unity-ui-on-the-hololens.394629/
 * http://heliosinteractive.com/scaling-ui-hololens/
 */

public class SetImageLabel : MonoBehaviour
{
    //const bool isBackupResponseEnabled = true;

    //const string SUBSCRIPTION_KEY = "YOUR-SUBSCRIPTION-KEY";
    const string SUBSCRIPTION_KEY = "9f644a608d074bcf9858e4662012b9ab";
    //const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze";
    //https://[location].api.cognitive.microsoft.com/vision/v1.0/analyze[?visualFeatures][&details][&language]
    const string uriBase = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze";
    //public string imageFilePath = null;
    //public string imageFilePath = "satya-nadella.jpg";
    public byte[] image = null;

    // OCR
    // https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/#text
    //const string ocrUriBase = "https://westus.api.cognitive.microsoft.com/vision/v2.0/ocr";
    const string ocrUriBase = "https://eastus.api.cognitive.microsoft.com/vision/v2.0/ocr";

    // Translate
    // https://azure.microsoft.com/en-us/services/cognitive-services/translator-text-api/
    // https://docs.microsoft.com/en-us/azure/cognitive-services/translator/translator-info-overview
    // https://www.microsoft.com/en-us/translator
    // https://github.com/MicrosoftTranslator/Text-Translation-API-V3-C-Sharp/blob/master/Translate.cs
    const string TRANSLATE_KEY = "9b693d960bfd455f949d3bba2fe6978c";
    const string TRANSLATE_HOST = "https://api.cognitive.microsofttranslator.com";
    const string TRANSLATE_PATH = "/translate?api-version=3.0";
    const string TRANSLATE_PARAMS = "&to=de"; // Translate to German

    // Handwriting

    // Use this for initialization
    void Start()
    {
        //byte[] bytes = GetImageAsByteArray("satya-nadella.jpg");
        //StartCoroutine(MakeAnalysisRequest(imageFilePath));
        //StartCoroutine(MakeAnalysisRequest(bytes));
    }

    // Update is called once per frame
    void Update()
    {
        //if (imageFilePath != null)
        if (image != null)
        {
            byte[] bytes = image;
            //imageFilePath = null;
            image = null;
            //StartCoroutine(MakeAnalysisRequest(bytes));
            //StartCoroutine(MakeOCRRequest(bytes));
            StartCoroutine(MakeOCRAndTranslateRequest(bytes));
        }
    }

    //static IEnumerator MakeAnalysisRequest(string imageFilePath)
    //public IEnumerator MakeAnalysisRequest(string imageFilePath)
    public IEnumerator MakeAnalysisRequest(byte[] bytes)
    {
        //byte[] bytes = GetImageAsByteArray(imageFilePath);
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY },
            {"Content-Type","application/octet-stream"}
        };
        string requestParameters = "visualFeatures=Description&language=en";
        string uri = uriBase + "?" + requestParameters;
        WWW www = new WWW(uri, bytes, headers);
        yield return www;

        //if ((www.error != null) && !isBackupResponseEnabled) {
        if (www.error != null)
        {
            setText(www.error);
        }
        else
        {
            //string json;
            string json = www.text;
            //if ((www.error != null) && isBackupResponseEnabled)
            //{
            //    json = "{\"description\":{\"tags\":[\"person\",\"man\",\"suit\",\"clothing\",\"wearing\",\"glasses\",\"posing\",\"standing\",\"photo\",\"jacket\",\"holding\",\"front\",\"looking\",\"camera\",\"business\",\"dressed\",\"smiling\",\"black\",\"old\",\"sign\",\"young\",\"white\"],\"captions\":[{\"text\":\"Satya Nadella wearing a suit and tie smiling at the camera\",\"confidence\":0.99060609432346514}]},\"requestId\":\"c83d3943-14dc-4b69-b9da-3b6eeb2acf2c\",\"metadata\":{\"width\":400,\"height\":400,\"format\":\"Jpeg\"}}";
            //}
            //else
           // {
            //    json = www.text;
            //}
            VisionAPIResults results = JsonUtility.FromJson<VisionAPIResults>(json);
            string text = results.description.captions[0].text;
            string confidence = results.description.captions[0].confidence.ToString("0.00");
            setText(text + " (" + confidence + ")");
        }
    }

    public IEnumerator MakeOCRRequest(byte[] bytes)
    {
        //byte[] bytes = GetImageAsByteArray(imageFilePath);
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY },
            {"Content-Type","application/octet-stream"}
        };
        string requestParameters = "visualFeatures=Description&language=en";
        string uri = ocrUriBase + "?" + requestParameters;
        WWW www = new WWW(uri, bytes, headers);
        yield return www;

        //if ((www.error != null) && !isBackupResponseEnabled) {
        if (www.error != null)
        {
            setText(www.error);
        }
        else
        {
            string json = www.text;
            setText(json);
        }
    }

    public IEnumerator MakeOCRAndTranslateRequest(byte[] bytes)
    {
        
        
        string uri = TRANSLATE_HOST + TRANSLATE_PATH + TRANSLATE_PARAMS;
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(uri);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");




        string text = "Hello! I hope everyone is having a great time.";
        System.Object[] body = new System.Object[] { new { Text = text } };
        var requestBody = JsonConvert.SerializeObject(body);
        //byte[] textBytes = Encoding.ASCII.GetBytes(text);
        //byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        string uri = TRANSLATE_HOST + TRANSLATE_PATH + TRANSLATE_PARAMS;
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", TRANSLATE_KEY },
            //{"Content-Type","application/json"}
            {"Content-Type","application/octet-stream"}
        };
        WWW www = new WWW(uri, textBytes, headers);
        yield return www;

        string token = www.text;
        int i = 0;
    }

    private static void setText(string labelText)
    {
        Text myText = GameObject.Find("txtImageInfo").GetComponent<Text>();
        myText.text = labelText;
    }

    /*
    static byte[] GetImageAsByteArray(string imageFilePath)
    {
        string fileName = Path.Combine(Application.streamingAssetsPath, imageFilePath);
        return System.IO.File.ReadAllBytes(fileName);
    }
    */

    /*
    public static string Translate(string textToTranslate, string targetLanguage)
    {
        var accessToken = GetAuthenticationToken(API_KEY_TRANSLATION).Result;
        var translatedText = Translate(textToTranslate, targetLanguage, accessToken).Result;
        return translatedText;
    }
    */

    /*
    private static async Task<string> Translate(string textToTranslate, string language, string accessToken)
    {
        string url = "http://api.microsofttranslator.com/v2/Http.svc/Translate";
        string query = $"?text={System.Net.WebUtility.UrlEncode(textToTranslate)}&to={language}&contentType=text/plain";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.GetAsync(url + query);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return "ERROR: " + result;
            }

            var translatedText = XElement.Parse(result).Value;
            return translatedText;
        }
    }
    */

    /*
    private static async Task<string> GetAuthenticationToken(string key)
    {
        string endpoint = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = await client.PostAsync(endpoint, null);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
    */
}

