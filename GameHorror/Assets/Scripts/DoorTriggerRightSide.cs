using UnityEngine;
using System.Collections;

public class DoorTriggerRightSide : MonoBehaviour {

    public Door door;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.front = false;
            door.back = true;
        }
    }
}
