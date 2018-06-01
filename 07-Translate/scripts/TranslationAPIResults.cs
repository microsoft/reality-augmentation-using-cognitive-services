using System.Collections.Generic;

/*
  Example:
  "[{\"detectedLanguage\":{\"language\":\"en\",\"score\":1.0},\"translations\":[{\"text\":\"hellc\",\"to\":\"de\"}]}]"
 
"[
  {
    \"detectedLanguage\": {
      \"language\": \"en\",
      \"score\": 1.0
    },
    \"translations\": [
      {
        \"text\": \"hellc\",
        \"to\": \"de\"
      }
    ]
  }
]"
    
 */

[System.Serializable]
public class TranslationAPIResults
{
    public DetectedLanguage detectedLanguage;
    public List<Translation> translations;

    override
    public string ToString()
    {
        string words = "";
        foreach (Translation translation in translations)
        {
            if (words.Length > 0)
            {
                words += " ";
            }
            words += translation.text;
        }
        return words;
    }
}

[System.Serializable]
public class DetectedLanguage
{
    public string language;
    public float score;
}

[System.Serializable]
public class Translation
{
    public string text;
    public string to;
}