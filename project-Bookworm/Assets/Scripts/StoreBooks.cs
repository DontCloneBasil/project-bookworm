using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StoreBooks : MonoBehaviour
{
    public List<GameObject> books; // list of all the book this shelf will store
    public int maxAmount; // maximum amount of books that fit in the shelf
    [SerializeField] Transform storeLocation;
    [SerializeField] private float distanceBetweenBooks; // the difference between books
    public void RestoreBooks(GameObject ObjectToStore)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i] == ObjectToStore)
            {
                Debug.Log("found ya");
                ObjectToStore.transform.rotation = Quaternion.Euler(-90f, 90f, 0f); // sets the roation
                ObjectToStore.transform.SetParent(storeLocation); // sets the parent of the book to the shelf
                ObjectToStore.transform.localPosition = new Vector3(0f + distanceBetweenBooks * i, 0f, 0f); // sets the local position depending on the count in the list
                break; // breaks the loop
            }
            Debug.Log(i);
        }
    }
}
