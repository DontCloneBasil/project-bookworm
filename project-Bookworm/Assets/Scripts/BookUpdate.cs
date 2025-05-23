using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Drawing;
using UnityEngine.UI;
using SFB;
using Unity.VisualScripting;
using Unity.Mathematics;

public class BookUpdate : MonoBehaviour
{
    [SerializeField] private string path; // the path where the document is
    
    [SerializeField] private string savepath; // the path to where you want to save the output
    
    [SerializeField] private string fileName; // the name for the file if you want to title it
    private int maxPages;

    public GameObject BookPrefab;
    [SerializeField] private PdfToImageConverter pdfConverter;
    [SerializeField] private Transform shelf;
    
    public void OpenFileExplorer()
    {
        // using the SFB package it opens the file browser
        var paths = StandaloneFileBrowser.OpenFilePanel("pdf Explorerer", "", new[] { new ExtensionFilter("Text Files", "pdf") /* add filters for file types */ }, false /* turns multiselect off */); 
        path = paths[0]; // saves the first selscted file path as a string
        fileName = Path.GetFileNameWithoutExtension(path); // fetches the file name
        
        if (path != null)
        {
            SpawnBook();
        }    
    }

    private void SpawnBook()
    {
        savepath = pdfConverter.FindPdfPath(savepath); // sends the disired path over to 
        pdfConverter.FormatConverter(path, savepath,fileName); // starts the pdf to img conversion
        GameObject book = Instantiate(BookPrefab, new Vector3(0f, 0f, 0f), quaternion.identity, shelf); //creates a version of the book prefab
        book.name = fileName; // sets the name of the object to the name of the file for simplicity

        DisplayImage DisplayScript = book.GetComponent<DisplayImage>(); // sets a reference of the display image script
        DisplayScript.maxPages = pdfConverter.pagecounter; // sets the max amount of pages the book had by the amount of pages made during the pdf to image conversion
        DisplayScript.SetNameAndPath(savepath,fileName); // sends the name and path of the Display image script for easy display
    }
}
