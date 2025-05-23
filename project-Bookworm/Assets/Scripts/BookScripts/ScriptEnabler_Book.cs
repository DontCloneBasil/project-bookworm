using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptEnabler_Book : MonoBehaviour
{
    [SerializeField] private GameObject cover;
    [SerializeField] private GameObject book;
    public DisplayImage displayImage;
    [SerializeField] private PlayerInput inputHandler;
    [SerializeField] private StoreBooks storeBooks;
    // Start is called before the first frame update

    void Start()
    {
        storeBooks = transform.parent.GetComponent<StoreBooks>(); 
    }
    private void OnEnable()
    {
        Debug.Log("turned on");
        //turns the cover and open book portion off and on
        cover.SetActive(false);
        book.SetActive(true);
        displayImage.enabled = true; // turns the pages on
        transform.localRotation = Quaternion.Euler(-90f, 0f, 0f); // sets to upright rotations
        inputHandler.enabled = true; // turns on book controls
    }
    private void OnDisable()
    {
        Debug.Log("turned off");
        //turns the cover and open book portion off and on
        cover.SetActive(true);
        book.SetActive(false);
        displayImage.enabled = false;
        transform.parent = null;
        inputHandler.enabled = false;
        storeBooks.RestoreBooks(this.gameObject); // sends object back to the assigned shelf
    }
}
