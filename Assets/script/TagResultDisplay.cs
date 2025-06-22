using UnityEngine;
using TMPro;
using System.IO;

public class TagResultDisplay : MonoBehaviour
{
    public TextMeshProUGUI tagText;

    [System.Serializable]
    public class TagResult
    {
        public int tag_id;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  // Run Python detection
        {
            PythonRunner.RunPythonScript();
        }

        if (Input.GetKeyDown(KeyCode.R))  // Read JSON and update UI
        {
            string path = Application.dataPath + "/tagdata.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                TagResult result = JsonUtility.FromJson<TagResult>(json);

                if (result.tag_id == -1)
                {
                    tagText.text = "No AprilTag detected.";
                }
                else
                {
                    tagText.text = "Detected Tag ID: " + result.tag_id;
                }
            }
            else
            {
                tagText.text = "No tagdata.json found!";
            }
        }
    }
}
