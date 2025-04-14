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
    // Start is called before the first frame update

    private void OnEnable()
    {
        Debug.Log("turned on");
        cover.SetActive(false);
        book.SetActive(true);
        displayImage.enabled = true;
        transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        inputHandler.enabled = true;
    }
    private void OnDisable()
    {
        Debug.Log("turned off");
        cover.SetActive(true);
        book.SetActive(false);
        displayImage.enabled = false;
        transform.parent = null;
        inputHandler.enabled = false;
    }
}
