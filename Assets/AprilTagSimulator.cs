using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AprilTagSimulator : MonoBehaviour
{
    public Text resultText;
    private Dictionary<string, string> tagData;

    void Start()
    {
        LoadTagData();
    }

    void LoadTagData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("tagdata");

        if (jsonFile == null)
        {
            Debug.LogError("Tag JSON file not found!");
            return;
        }

        Wrapper wrapper = JsonUtility.FromJson<Wrapper>(jsonFile.text);
        tagData = wrapper.ToDictionary();
    }

    public void OnDetectButtonPressed()
    {
        if (tagData == null)
        {
            Debug.LogError("Tag data not loaded!");
            return;
        }

        string detectedID = "1"; // Simulated

        if (tagData.ContainsKey(detectedID))
        {
            resultText.text = "Detected ID: " + detectedID + "\nInfo: " + tagData[detectedID];
        }
        else
        {
            resultText.text = "Tag not found.";
        }
    }

    [System.Serializable]
    public class TagEntry
    {
        public string key;
        public string value;
    }

    [System.Serializable]
    public class Wrapper
    {
        public List<TagEntry> items;

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var item in items)
            {
                dict[item.key] = item.value;
            }
            return dict;
        }
    }
}
