using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager.instance.DeathHit();
        }
    }

}
