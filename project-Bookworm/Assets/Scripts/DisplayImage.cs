using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.InputSystem;

public class DisplayImage : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private string FolderPath; //path to the folder 
    [SerializeField] private string Name; // unique name accociated with the 'book'
    [SerializeField] private RawImage[] pages; //currently static path to the page raw image reference 
    [SerializeField] private float pageNumber = 1;
    
    private float minPages = 1;
    [SerializeField] private float maxPages; // max amount of pages
    

    void Start()
    {
        LoadImage();
    }

    private void OnFlip(InputValue inputValue)
    {
        float flip = pageNumber;
        flip += inputValue.Get<Vector2>().x * pages.Length;
        if (flip >= minPages && flip <= maxPages)
        {
            pageNumber = flip;
            LoadImage();
        }
    }
    void LoadImage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            string picPath = FolderPath + Name + $"page_{pageNumber + i}.jpeg";
            //checks if the path of the image is valid
            if (File.Exists(picPath))
            {
                byte[] imageData = File.ReadAllBytes(picPath); //reads the entire file and turns it to turn it into a texture
                Texture2D PageTexture = new Texture2D(2, 2); //makes a 2d texture to display
                PageTexture.LoadImage(imageData); //gets the texture ready as a loaded version of an image
                PageTexture.Apply(); //applies the image to the texture
                pages[i].texture = PageTexture; //displays the texture
            }
            else 
            {
                pages[i].texture = null; // turns the page blank for books with uneven amount of pages;
            }
        }
    }
}
