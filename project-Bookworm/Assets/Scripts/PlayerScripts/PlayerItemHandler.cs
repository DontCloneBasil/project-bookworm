using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
[Header("references")]
    public Transform player, gunContainer, itemContainer, fpsCam;
    public LayerMask WhatIsItem;
    private GameObject Object;
    [SerializeField] private MonoBehaviour scriptEnabler;

    [Header("detecttion")]
    public float pickUpRange;
    public float sphereCastRadius;
    private RaycastHit itemFrontHit;
    private bool itemFront;
    private bool HandsfullCheck;

    // Update is called once per frame
    void Update()
    {
        if (!HandsfullCheck) ItemCheck();
        if (HandsfullCheck) MoveObject();
    }

    private void ItemCheck()
    {
        itemFront = Physics.Raycast(fpsCam.position, fpsCam.forward, out itemFrontHit, pickUpRange, WhatIsItem);
        if (itemFront)
        {
            // logger that only shows the gameobject as long as the object changes
            if (Object != itemFrontHit.collider.gameObject)
            {
                Debug.Log(itemFrontHit.collider.name);
            }

            Object = itemFrontHit.collider.gameObject;
            //Debug.Log(Object);
        }
        else
        {
            Object = null;
        }
    }
    private void MoveObject()
    {
        Object.transform.localPosition = Vector3.Lerp(Vector3.zero, Object.transform.localPosition, 5 * Time.deltaTime);
        //Object.transform.localPosition = new Vector3(0,0,0);
    }
    private void OnPickUp()
    {
        if (Object != null && !HandsfullCheck) // checks if you are already holding an object
        {
            // Get all MonoBehaviour components attached to the Object
            MonoBehaviour[] scripts = Object.GetComponentsInChildren<MonoBehaviour>();

            // Check if only one script was found
            if (scripts.Length >= 1 && Object.tag != "") // Length is 2 because the GameObject itself is also counted
            {
                for (int i = 0; i <= (scripts.Length - 1); i++)
                {
                    // Check if the script starts with 'S'
                    if (scripts[i].GetType().Name.StartsWith("S"))
                    {
                        scriptEnabler = scripts[i];                        
                        Object.transform.SetParent(gunContainer); // sets the parent of the object to the player holder
                        HandsfullCheck = true;
                        scriptEnabler.enabled = true; // turns on the script enabler
                        
                        //Debug.Log("Script enabled on " + Object.name);
                    }
                }

            }
        }
    }
    private void OnDrop()
    {
        // if holding object, turn off the scripts and remove the object from user's hand
        if (HandsfullCheck)
        {
            scriptEnabler.enabled = false;
            scriptEnabler = null;
            HandsfullCheck = false;
        }
    }    
}
