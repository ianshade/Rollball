using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager.instance.ObstacleHit();
        }
    }

}
