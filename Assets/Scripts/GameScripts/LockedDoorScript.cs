using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LockedDoorScript : MonoBehaviour
{
    [Header("Components")]
    public Animator doorAnimation;
    public GameObject openText;
    private GameObject keyInv;
    public bool isLockedDoor = false;

    private bool inReach;
    private bool locked;
    private bool isOpen;

    public bool keyPickedUp;

    void Start()
    {
        keyPickedUp = false;
        inReach = false;
        isOpen = false;
        if (isLockedDoor)
        {
            locked = true; 
        }
    }

    public void KeyPickedUp()
    {
        keyPickedUp = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if (keyPickedUp == true)
        {
            locked = false;

        }

        if (!locked && inReach && Input.GetButtonDown("Interact"))
        {
            if (!isOpen)
            {
                StartCoroutine(OpenDoor());
            }
            else
            {
                StartCoroutine(CloseDoor());
            }
        }

        if (locked && inReach && Input.GetButtonDown("Interact"))
        {
            Debug.Log("Door is Locked");
            //lockedSound.Play();
        }

    }
    IEnumerator OpenDoor()
    {
        Debug.Log("you are opening the door");
        doorAnimation.Play("Opening");
        isOpen = true;
        yield return new WaitForSeconds(.5f);

    }

    IEnumerator CloseDoor()
    {
        Debug.Log("you are closing the door");
        doorAnimation.Play("Closing");
        isOpen = false;
        yield return new WaitForSeconds(.5f);

    }

}
