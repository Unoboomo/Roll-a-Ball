using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // The rigedbody of the player
    private Rigidbody playerRigedBody;

    //stores the x and y movement values
    private float movementX;
    private float movementY;

    //the speed at which the player moves
    public float speed = 0.0f;

    public GameObject winTextObject;

    //Start is called before the first frame, and never again
    void Start()
    {
        //get and store the rigedbody component attatched to the player
        playerRigedBody = GetComponent<Rigidbody>();
    }

    //This function is called when a move input is detected
    void OnMove(InputValue movementValue)
    {
        //convert the input into a 2d vector
        Vector2 movementVector = movementValue.Get<Vector2>();

        //store the x and y components of the movement
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //Fixed Update is called once per fixed frame-rate frame
    void FixedUpdate()
    {
        //creates a 3d movement vector using the x and y input components
        Vector3 movementVector = new Vector3 (movementX, 0.0f, movementY);
        // Apply force to the rigedbody to move the player
        playerRigedBody.AddForce(movementVector * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            PickupParentSystem.count++;
            PickupParentSystem.check_count = true;
        }
    }
}
