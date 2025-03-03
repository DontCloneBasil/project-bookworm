using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PDFToPNGConverter : MonoBehaviour
{
    public string pdfFilePath;  // Path to the PDF file
    public int pageNumber = 0;   // Page to render
    public Renderer targetRenderer; // The GameObject Renderer to apply the material

    void Start()
    {
        LoadPDFPage();
    }

    void LoadPDFPage()
    {
        string imagePath = ConvertPDFToImage(pdfFilePath, pageNumber);
        if (!string.IsNullOrEmpty(imagePath))
        {
            ApplyImageToMaterial(imagePath);
        }
    }

    string ConvertPDFToImage(string pdfPath, int page)
    {
        string outputImagePath = Path.Combine(Application.persistentDataPath, "pdf_page.png");

        // This assumes you have an external tool like `pdftoppm` or a custom .NET/Python service converting the PDF to PNG
        string args = $" -f {page + 1} -l {page + 1} -png \"{pdfPath}\" \"{outputImagePath}\"";
        System.Diagnostics.Process.Start("pdftoppm", args);

        return File.Exists(outputImagePath) ? outputImagePath : null;
    }

    void ApplyImageToMaterial(string imagePath)
    {
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageBytes);
        texture.Apply();

        if (targetRenderer != null)
        {
            targetRenderer.material.mainTexture = texture;
        }
    }
}