using UnityEngine;
using System.Diagnostics;

public class PythonRunner : MonoBehaviour
{
    // Call this method from a Unity UI Button or event
    public static void RunPythonScript()
    {
        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = @"C:\Users\santhosh\AppData\Local\Programs\Python\Python313\python.exe",  // ✅ Python executable path
            Arguments = $"\"C:\\GOG Games\\April Tag Detection\\Assets\\detect_apriltag.py\"",    // ✅ Full script path with quotes
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

                UnityEngine.Debug.Log("✅ Python output:\n" + output);

                if (!string.IsNullOrEmpty(error))
                {
                    UnityEngine.Debug.LogError("❌ Python error:\n" + error);
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError("💥 Failed to run Python script: " + e.Message);
        }
    }
}
