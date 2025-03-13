using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class DisplayImage : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private RawImage[] pages; //currently static path to the page raw image reference 
    public int pageNumber = 1;
    //[SerializeField] private string picturePath = $"Assets/OutputImages/page_1.png"; //temporary static path to png/jpg(up to you)

    void Start()
    {
        LoadImage();
    }

    void LoadImage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            string picPath = $"Assets/OutputImages/page_{pageNumber + i}.png";
            //checks if the path of the image is valid
            if (File.Exists(picPath))
            {
                byte[] imageData = File.ReadAllBytes(picPath); //reads the entire file and turns it to turn it into a texture
                Texture2D PageTexture = new Texture2D(2, 2); //makes a 2d texture to display
                PageTexture.LoadImage(imageData); //gets the texture ready as a loaded version of an image
                PageTexture.Apply(); //applies the image to the texture
                pages[i].texture = PageTexture; //displays the texture


            }
        }
    }
}
