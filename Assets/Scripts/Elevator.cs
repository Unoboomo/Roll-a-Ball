using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Elevator : MonoBehaviour
{

    public float elevateSpeed;
    public float topFloor;
    private bool elevating;
    private float startY;

    // Update is called once per frame

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevating = true;
        }

    }
    void Start()
    {
        elevating = false;
        startY = transform.position.y;
    }
    void FixedUpdate()
    {
        if (elevating)
        {
            transform.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime * elevateSpeed);
            if (transform.position.y >= topFloor)
            {
                elevating = false;
            }
        }
    }
}
