using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine.InputSystem;

public class TagInfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI tagText;
    public InputActionProperty triggerDetection; 

    [System.Serializable]
    public class TagResult
    {
        public int tag_id;
    }

    [System.Serializable]
    public class TagInfoWrapper
    {
        public List<string> keys;
        public List<string> values;

        public Dictionary<string, string> ToDict()
        {
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict[keys[i]] = values[i];
            }
            return dict;
        }
    }

    void OnEnable()
    {
        triggerDetection.action.Enable();
        triggerDetection.action.performed += OnTriggerDetection;
    }

    void OnDisable()
    {
        triggerDetection.action.performed -= OnTriggerDetection;
        triggerDetection.action.Disable();
    }

    void OnTriggerDetection(InputAction.CallbackContext context)
    {
        RunPythonScriptAndDisplay();
    }

    void RunPythonScriptAndDisplay()
    {
        string pythonPath = @"C:\Users\santhosh\AppData\Local\Programs\Python\Python313\python.exe";
        string scriptPath = @"C:\GOG Games\April Tag Detection\Assets\detect_apriltag.py";

        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = pythonPath,
            Arguments = $"\"{scriptPath}\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        try
        {
            using (Process process = Process.Start(start))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                UnityEngine.Debug.Log("Python Output:\n" + output);
                if (!string.IsNullOrEmpty(error))
                {
                    UnityEngine.Debug.LogError("Python Error:\n" + error);
                }
            }

           
            Thread.Sleep(500);

            string path = Application.dataPath + "/tagdata.json";
            string dbPath = Application.dataPath + "/taginfo.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                TagResult result = JsonUtility.FromJson<TagResult>(json);

                if (File.Exists(dbPath))
                {
                    string dbJson = File.ReadAllText(dbPath);
                    TagInfoWrapper wrapper = JsonUtility.FromJson<TagInfoWrapper>(dbJson);
                    Dictionary<string, string> tagInfo = wrapper.ToDict();

                    string tagIdStr = result.tag_id.ToString();
                    if (tagInfo.ContainsKey(tagIdStr))
                    {
                        tagText.text = tagInfo[tagIdStr];
                    }
                    else
                    {
                        tagText.text = "Unknown tag ID: " + tagIdStr;
                    }
                }
                else
                {
                    tagText.text = "taginfo.json not found!";
                }
            }
            else
            {
                tagText.text = "tagdata.json not found!";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError("Error running script or reading file: " + e.Message);
        }
    }
}
