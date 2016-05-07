using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public Door myDoor;

	public void UnlockDoor()
    {
        myDoor.isLocked = false;
        Destroy(gameObject);
    }
}
