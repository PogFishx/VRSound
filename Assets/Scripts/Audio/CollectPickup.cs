using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.pickupCollected, this.transform.position);

            Destroy(gameObject);
		}
    }
}
