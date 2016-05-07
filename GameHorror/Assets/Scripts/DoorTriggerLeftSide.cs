using UnityEngine;
using System.Collections;

public class DoorTriggerLeftSide : MonoBehaviour {

    public Door door;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.front = true;
            door.back = false;
        }
    }
}
