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
    
    private float minPages = 1; // base minimum amount of pages
    [SerializeField] private float maxPages; // max amount of pages
    


    //called when the buttons related to flipping are pressed
    private void OnFlip(InputValue inputValue)
    {
        float flip = pageNumber; //temporary page number indicator
        flip += inputValue.Get<Vector2>().x * pages.Length; // flip gets the input directions (-1 or 1) multiplide by the amount of pages
        if (flip >= minPages && flip <= maxPages) // checks if the temporary value is possible by if it's higher than the minimum and lower than the maximum
        {
            pageNumber = flip; // sets pagenumber value to be flip as it has been varified
            LoadImage(); // loads the pages with the new value
        }
    }
    void LoadImage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            //sets the path by combining: folder path, Png name, and  pagenumber + the amount of times it loops for the least amount og repetition
            string picPath = FolderPath + Name + $"page_{pageNumber + i}.Png";
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

    // called every time the script is turned on
    void OnEnable()
    {
        LoadImage();
    }
}
