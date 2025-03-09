using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using UnityEngine;
using PdfiumViewer;

public class PdfToImageConverter : MonoBehaviour
{
    // path to your pdf file (currently non static)
    public string pdfPath = "Assets/sample.pdf";

    //output path, where we want to store the images
    public string outputPath = "Assets/OutputImages/";

    void Start()
    {
        //starts the conversion method
        ConvertPdfToImages(pdfPath, outputPath);
    }


    void ConvertPdfToImages(string pdfFilePath, string outputFolder)
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
                //renders the document page into the image vaariable
                using (var image = document.Render(i, 3840, 2160, true))
                {
                    //combines the path and sets the name *name can be anything but avoid making it messy
                    string outputPath = Path.Combine(outputFolder, $"page_{i + 1}.Jpeg");
                    //saves the image in the outputpath in whatever image format you want
                    image.Save(outputPath, ImageFormat.Jpeg);
                    Debug.Log($"Saved: {outputPath}");
                }
            }
        }
    }
}