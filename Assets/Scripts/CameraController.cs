using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    Vector3 offset;
    PlayerController playerController;

    float rotation = 0f;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.LookRotation(-offset);
        rotation += Input.GetAxis("Mouse X");
        transform.RotateAround(player.transform.position, Vector3.up, rotation);
    }
}
