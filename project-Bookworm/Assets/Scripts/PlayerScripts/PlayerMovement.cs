using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("references")]
    private Rigidbody rb;
    public float moveSpeed;
    [SerializeField] private Transform orientation; 

    [Header("variables")]
    private Vector3 moveInput;
    private Vector3 moveDirection;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //assigns the rigidbody
        //rb.freezeRotation = true; // freezes player rotation
    }

    void OnMove(InputValue inputValue)
    {
        //Debug.Log($"{inputValue.Get<Vector3>().y} is y movement. {inputValue.Get<Vector3>().x} is x movement. {inputValue.Get<Vector3>().z} is z mouse. ");
        moveInput = inputValue.Get<Vector3>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        //makes a new vector2 value from moveInput's x value (which is the only value we'll user for now)
        moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;
        //applies the movement in the direction you want
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

}
