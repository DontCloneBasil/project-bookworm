using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayImage : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private RawImage displayImage; //currently static path to the page raw image reference 
    [SerializeField] private string imagePath = "Assets/OutputImages/page_1.png"; //temporary static path to png/jpg(up to you)

    void Start()
    {
        LoadImage();
    }

    void LoadImage()
    {
        //checks if the path of the image is valid
        if (File.Exists(imagePath))
        {
            byte[] imageData = File.ReadAllBytes(imagePath); //reads the entire file and turns it to turn it into a texture
            Texture2D PageTexture = new Texture2D(2, 2); //makes a 2d texture to display
            //gets the texture ready as a loaded version of an image
            PageTexture.LoadImage(imageData);
            PageTexture.Apply(); //applies the image to the texture
            //displays the texture
            displayImage.texture = PageTexture;

        }
    }
}
