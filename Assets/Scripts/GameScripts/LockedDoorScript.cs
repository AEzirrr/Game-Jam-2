using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LockedDoorScript : MonoBehaviour
{
    [Header("Components")]
    public Animator doorAnimation;
    public GameObject openText;
    public GameObject keyInv;
    //public AudioSource doorSound;
    //public AudioSource lockedSound;
    public bool isLockedDoor = false;

    private bool inReach;
    private bool locked;
    private bool isOpen;

    void Start()
    {
        inReach = false;
        isOpen = false;
        if (isLockedDoor)
        {
            locked = true; 
        }
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
        if (keyInv.activeInHierarchy)
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
