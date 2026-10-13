using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject player;
    private float distance;
    private float rotationSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        rotationSpeed = - distance / 30.0f + 2;
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * rotationSpeed);
    }
}
