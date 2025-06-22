using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AprilTagImageDisplay : MonoBehaviour
{
    public RawImage imageDisplay;

    public void ShowDetectedImage()
    {
        string imagePath = Application.dataPath + "/DetectedImage.png";

        if (File.Exists(imagePath))
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);
            imageDisplay.texture = texture;
            imageDisplay.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning(" DetectedImage.png not found at: " + imagePath);
        }
    }
}
