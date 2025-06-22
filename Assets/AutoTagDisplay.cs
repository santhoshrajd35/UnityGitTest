using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

public class AutoTagDisplay : MonoBehaviour
{
    public RawImage rawImage;
    public Text tagText;
    public bool isActive = true; // Toggle to control Python execution

    string imagePath;
    string jsonPath;
    string pythonScriptPath;

    void Start()
    {
        imagePath = Path.Combine(Application.streamingAssetsPath, "tag_frame.png");
        jsonPath = Path.Combine(Application.streamingAssetsPath, "tag_data.json");
        pythonScriptPath = Path.Combine(Application.streamingAssetsPath, "detect_tags.py");

        StartCoroutine(UpdateLoop());
    }

    IEnumerator UpdateLoop()
    {
        while (true)
        {
            if (isActive)
            {
                // Run the Python script
                RunPythonScript();

                // Load and display image
                if (File.Exists(imagePath))
                {
                    byte[] imageData = File.ReadAllBytes(imagePath);
                    Texture2D tex = new Texture2D(2, 2);
                    tex.LoadImage(imageData);
                    rawImage.texture = tex;
                }

                // Load and display tag data
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    JArray tagArray = JArray.Parse(json);
                    if (tagArray.Count > 0)
                    {
                        tagText.text = "Detected ID: " + tagArray[0]["id"];
                        rawImage.gameObject.SetActive(true);
                    }
                    else
                    {
                        tagText.text = "";
                        rawImage.gameObject.SetActive(false);
                    }
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void RunPythonScript()
    {
        try
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python"; // or "python3" on Linux/macOS
            start.Arguments = $"\"{pythonScriptPath}\"";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;

            using (Process process = Process.Start(start))
            {
                string result = process.StandardOutput.ReadToEnd();
                UnityEngine.Debug.Log("Python Output: " + result);
            }
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError("Python script failed: " + ex.Message);
        }
    }
}
