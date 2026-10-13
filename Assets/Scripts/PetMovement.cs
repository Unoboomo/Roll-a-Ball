using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PetMovement : MonoBehaviour
{
    Transform target;
    public float moveSpeed;
    public float rotationSpeed;
    public float followDistance;
    public float y_wiggle_room;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 self_position_y_ignore;
        Vector3 target_position_y_ignore;
        float y_delta;
        self_position_y_ignore = transform.position;
        target_position_y_ignore = target.position;
        self_position_y_ignore.y = 0;
        target_position_y_ignore.y = 0;
        if (Vector3.Distance(self_position_y_ignore, target_position_y_ignore) > followDistance)
        {
            //rotate to look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(target_position_y_ignore - self_position_y_ignore), rotationSpeed * Time.deltaTime);
        }
        
        //move towards the player
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        y_delta = (target.position.y + 5) - transform.position.y;
        if (Mathf.Abs(y_delta) > y_wiggle_room)
        {
            
            transform.position += transform.up * moveSpeed *Time.deltaTime * (y_delta > 0 ? 1 : -1);
        }
    }
}
