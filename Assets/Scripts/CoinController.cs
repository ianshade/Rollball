using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.CoinPickedUp();
        }
    }

}
