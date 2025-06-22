using UnityEngine;
using System.Diagnostics;
using System.IO;

public class AutoPythonStarter : MonoBehaviour
{
    private Process process;

    void Awake()
    {
        RunPythonOnPlay();
    }

    void OnDisable()
    {
        StopPythonProcess();
    }

    void RunPythonOnPlay()
    {
        string pythonExe = @"C:\\Users\\santhosh\\AppData\\Local\\Programs\\Python\\Python313\\python.exe";
        string scriptPath = @"C:\\GOG Games\\April Tag Detection\\Assets\\auto_detect_apriltag.py";

        if (!File.Exists(pythonExe))
        {
            UnityEngine.Debug.LogError("❌ Python executable not found at: " + pythonExe);
            return;
        }

        if (!File.Exists(scriptPath))
        {
            UnityEngine.Debug.LogError("❌ Python script not found at: " + scriptPath);
            return;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = pythonExe,
            Arguments = $"\"{scriptPath}\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        try
        {
            process = new Process();
            process.StartInfo = startInfo;
            process.OutputDataReceived += (s, e) => UnityEngine.Debug.Log("[PYTHON]: " + e.Data);
            process.ErrorDataReceived += (s, e) => UnityEngine.Debug.LogError("[PYTHON ERROR]: " + e.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            UnityEngine.Debug.Log("✅ Python script launched in background.");
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError("❌ Failed to start Python: " + ex.Message);
        }
    }

    void StopPythonProcess()
    {
        if (process != null && !process.HasExited)
        {
            process.Kill();
            process.Dispose();
            UnityEngine.Debug.Log("🛑 Python process killed.");
        }
    }
}
