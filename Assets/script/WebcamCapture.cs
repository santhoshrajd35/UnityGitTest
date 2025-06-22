using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class WebcamCapture : MonoBehaviour
{
    public WebCamTexture webcamTexture;
    public InputAction captureAction; 

    void OnEnable()
    {
        captureAction.Enable();
    }

    void OnDisable()
    {
        captureAction.Disable();
    }

    void Start()
    {
        webcamTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    void Update()
    {
        
        if (captureAction.triggered)
        {
            CaptureFrame();
        }
    }

    void CaptureFrame()
    {
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();

        byte[] bytes = snap.EncodeToPNG();
        string path = Application.dataPath + "/CapturedFrame.png";
        File.WriteAllBytes(path, bytes);

        Debug.Log("Image captured: " + path);
    }
}
