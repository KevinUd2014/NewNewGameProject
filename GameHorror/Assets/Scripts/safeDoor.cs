using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class safeDoor : MonoBehaviour
{
    public Canvas safeUI;
    public GameObject playerObject;
    public GameObject playerHeadBobing;

    private int number01;
    private int number02;
    private int number03;
    private int number04;

    public Text textNumber01;
    public Text textNumber02;
    public Text textNumber03;
    public Text textNumber04;

    public bool opened;
    public float doorOpenAngle = 90f;
    public float smooth = 2f;

    // Use this for initialization
    void Start()
    {
        opened = false;
        safeUI.enabled = false;
    }

    public void ShowSafeCanvas()
    {
        safeUI.enabled = true;
        //disables the player = no movement
        LockCharacter();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            UnlockCharacter();
        }
        //checks for right combination
        if (number01 == 1 && number02 == 2 && number03 == 4 && number04 == 10)
        {
            opened = true;
        }
        if(opened == true)
        {
            UnlockCharacter();

            gameObject.layer = 0; // layer 0 is Default

            UnlockSafeDoor();
        }
    }

    public void LockCharacter()
    {
        playerObject.GetComponent<Character>().enabled = false;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnlockCharacter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerObject.GetComponent<Character>().enabled = true;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = true;
        safeUI.enabled = false;
    }

    void UnlockSafeDoor()
    {
        Quaternion targetRotationOpen = Quaternion.Euler(0, 0, doorOpenAngle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
    }

    public void IncreaseNumber(int _number)//If there is time make this function smaller
    {
        if (_number == 1)
        {
            number01++;
            textNumber01.text = number01.ToString();

            if (number01 > 10)
            {
                number01 = 1;
                textNumber01.text = number01.ToString();
            }
            if (number01 == 10)
            {
                textNumber01.text = "Death";
            }
        }
        else if (_number == 2)
        {
            number02++;
            textNumber02.text = number02.ToString();

            if (number02 > 10)
            {
                number02 = 1;
                textNumber02.text = number02.ToString();
            }
            if (number02 == 10)
            {
                textNumber02.text = "Will";
            }

        }
        else if (_number == 3)
        {
            number03++;
            textNumber03.text = number03.ToString();

            if (number03 > 10)
            {
                number03 = 1;
                textNumber03.text = number03.ToString();
            }
            if (number03 == 10)
            {
                textNumber03.text = "Come";
            }
        }
        else if (_number == 4)
        {
            number04++;
            textNumber04.text = number04.ToString();

            if (number04 > 10)
            {
                number04 = 1;
                textNumber04.text = number04.ToString();
            }
            if (number04 == 10)
            {
                textNumber04.text = "Soon";
            }
        }
    }
    public void DecreaseNumber(int _number)//If there is time make this function smaller
    {
        if (_number == 1)
        {
            number01--;
            textNumber01.text = number01.ToString();

            if (number01 < 1)
            {
                number01 = 9;
                textNumber01.text = number01.ToString();
            }
            if (number01 == 10)
            {
                textNumber01.text = "Death";
            }
        }
        else if (_number == 2)
        {
            number02--;
            textNumber02.text = number02.ToString();

            if (number02 < 1)
            {
                number02 = 9;
                textNumber02.text = number02.ToString();
            }
            if (number02 == 10)
            {
                textNumber02.text = "Will";
            }

        }
        else if (_number == 3)
        {
            number03--;
            textNumber03.text = number03.ToString();

            if (number03 < 1)
            {
                number03 = 9;
                textNumber03.text = number03.ToString();
            }
            if (number03 == 10)
            {
                textNumber03.text = "Come";
            }
        }
        else if (_number == 4)
        {
            number04--;
            textNumber04.text = number04.ToString();

            if (number04 < 1)
            {
                number04 = 9;
                textNumber04.text = number04.ToString();
            }
            if (number04 == 10)
            {
                textNumber04.text = "Soon";
            }
        }
    }
}
