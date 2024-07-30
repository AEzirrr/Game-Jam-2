using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor1 : MonoBehaviour
{
    public Animator openandclose1;
    public bool open;
    public GameObject openText;

    private bool inReach;

    void Start()
    {
        open = false;
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = true;

            if (openText != null)
            {
                openText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false;
            if (openText != null)
            {
                openText.SetActive(false);
            }
            //openText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            if (!open)
            {
                StartCoroutine(Opening());
            }
            else
            {
                StartCoroutine(Closing());
            }
        }
    }

    IEnumerator Opening()
    {
        Debug.Log("You are opening the door");
        openandclose1.Play("Opening 1");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Closing()
    {
        Debug.Log("You are closing the door");
        openandclose1.Play("Closing 1");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
