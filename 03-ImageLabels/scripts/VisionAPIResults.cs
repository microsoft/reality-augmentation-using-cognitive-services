using System.Collections.Generic;

[System.Serializable]
public class VisionAPIResults
{
    public Description description;
    public string requestId;
    public MetaData metadata;
}

[System.Serializable]
public class Description
{
    public List<string> tags;
    public List<Captions> captions;
}

[System.Serializable]
public class Captions
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