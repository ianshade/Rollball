using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Camera playerCamera;
    public float distToGround;
    public float speedLimit;

    Rigidbody body;

    float rotation = 0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var forward = playerCamera.transform.forward;
        forward.y = 0;
        var left = Vector3.Cross(forward.normalized, Vector3.up);
        body.AddForce((forward*vertical-left*horizontal) * speed *(IsGrounded()? 1f: 0.3f));
        if(body.velocity.magnitude > speedLimit)
        {
            body.velocity *= speedLimit / body.velocity.magnitude;
        }
    }
    
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
