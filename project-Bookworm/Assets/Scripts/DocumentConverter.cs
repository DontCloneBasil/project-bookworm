using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PdfiumViewer;

public class DocumentConverter : MonoBehaviour
{
    public string inputPath = "Assets/sample.pdf"; // Change to your file
    public string outputDir = "Assets/OutputImages/";
    
    void Start()
    {
        Directory.CreateDirectory(outputDir);
        ConvertPdfToImages(inputPath, outputDir);
    }


    // Converts PDF to images using PdfiumViewer
    static void ConvertPdfToImages(string pdfPath, string outputDir)
    {
        using (var document = PdfDocument.Load(pdfPath))
        {
            for (int i = 0; i < document.PageCount; i++)
            {
                using (var image = document.Render(i, 300, 300, true))
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");
                    image.Save(outputPath, ImageFormat.Jpeg);
                    Debug.Log($"Saved: {outputPath}");
                }
            }
        }
    }
}
