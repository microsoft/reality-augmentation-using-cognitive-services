using System.Collections.Generic;

[System.Serializable]
public class VisionAPIResults
{
    public Description description;
    public string requestId;
    public MetaData metadata;

    override
    public string ToString()
    {
        string words = "";
        foreach (Caption caption in description.captions)
        {
            if (words.Length > 0)
            {
                words += " ";
            }
            words += caption.text;
            words += " [" + caption.confidence.ToString("0.00") + ")";
        }
        return words;
    }
}

[System.Serializable]
public class Description
{
    public List<string> tags;
    public List<Caption> captions;
}

[System.Serializable]
public class Caption
{
    public string text;
    public float confidence;
}

[System.Serializable]
public class MetaData
{
    public int height;
    public int width;
    public string format;
}