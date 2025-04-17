using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Drawing;
using UnityEngine.UI;
using SFB;
using Unity.VisualScripting;

public class BookUpdate : MonoBehaviour
{
    [SerializeField] private string path; // the path where the document is
    
    //[SerializeField] private string savepath; // the path you potentionally want to save it
    
    [SerializeField] private string fileName; // the name for the file if you want to title it

    
    public void OpenFileExplorer()
    {
        // using the SFB package it opens the file browser
        var paths = StandaloneFileBrowser.OpenFilePanel("pdf Explorerer", "", new[] { new ExtensionFilter("Text Files", "pdf") /* add filters for file types */ }, false /* turns multiselect off */); 
        path = paths[0]; // saves the first selscted file path as a string
        fileName = Path.GetFileName(path); // fetches the file name
        //savepath = Application.dataPath + "/pdfs/" + fileName;
        
        //Debug.Log($"{path} and the name is {fileName} and there is also {savepath} for some reason");
         
    }
}
