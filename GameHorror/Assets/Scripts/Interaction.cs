using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

    public string interactButton;

    public float interactDistance = 3f;

    public LayerMask interactLayer; // Makes objects that are interactive possible.

    public Image interactIcon;  // "hand" showing interaction.

    public bool isInteracting;
	// Use this for initialization
	void Start () {

        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }
	}
	// Update is called once per frame
	void Update () {
        // transform.position = middle of camera
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInformer;
        //shoots a ray
        if (Physics.Raycast(ray, out hitInformer, interactDistance, interactLayer))
        {
            //checks so that we aren't interacting
            if (!isInteracting)
            {
                if (interactIcon != null)
                {
                    interactIcon.enabled = true;
                }
                //interactIcon.enabled = true;
                //if we press the intereact button
                if (Input.GetButtonDown(interactButton))
                {
                    //opens the door or closes it!
                    if (hitInformer.collider.CompareTag("Door"))
                    {
                        hitInformer.collider.GetComponent<Door>().ChangeDoorState();
                    }
                    else if (hitInformer.collider.CompareTag("Key"))
                    {
                        hitInformer.collider.GetComponent<Key>().UnlockDoor();
                    }
                    else if (hitInformer.collider.CompareTag("safedoor"))
                    {
                        //shows the UI for the safe
                        hitInformer.collider.GetComponent<safeDoor>().ShowSafeCanvas();
                    }
                }
            }
        }
        else
        {
            interactIcon.enabled = false;
        }
	}
}
