using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using UnityEngine;
using PdfiumViewer;

public class PdfToImageConverter : MonoBehaviour
{
    // path to your pdf file (currently static)
    public string pdfPath = "Assets/sample.pdf";

    //folder, where we want to store the images
    public string storeFolder = "OutputImages";
    private string outputPath; // where you want to store the the images
    public int pagecounter;

    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, storeFolder); // sets a place in local temp data to store the images between sessions

        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path); // creates the folder if it does not already exist
            Debug.Log($"created path at {path}");
        }
        else
        {
            Debug.Log("'output' folder already exists at: " + path);
        }
        outputPath = path;
    }
    public string FindPdfPath(string i)
    {
        i = outputPath;
        return i;
    }

    public void FormatConverter(string pdfFilePath, string outputFolder, string fileName)
    {
        //checks if the path to the outputfolder exist
        if (!Directory.Exists(outputFolder))
            //creates a directory to the folder
            Directory.CreateDirectory(outputFolder);


        using (var document = PdfDocument.Load(pdfFilePath))
        {
            //a loop for if the pdf has multiple pages;
            for (int i = 0; i < document.PageCount; i++)
            {
                //renders the document page into the image variable
                using (var image = document.Render(i, 3840, 2160, true))
                {
                    //combines the path and sets the name *name can be anything but avoid making it messy
                    string outputPath = Path.Combine(outputFolder, $"{fileName}page_{i + 1}.Png");
                    //saves the image in the outputpath in whatever image format you want
                    image.Save(outputPath, ImageFormat.Png);

                    //to test if the saving worked
                    Debug.Log($"Saved: {outputPath}");
                }
                pagecounter = i;
            }
        }
    }
}