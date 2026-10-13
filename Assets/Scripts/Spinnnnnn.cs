using UnityEngine;

public class Spinnnnnn : MonoBehaviour
{

    public float rotationSpeed;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * rotationSpeed);
    }
}
