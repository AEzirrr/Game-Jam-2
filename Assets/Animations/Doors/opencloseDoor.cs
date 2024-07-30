using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor : MonoBehaviour
{
    public Animator openandclose;
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
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Closing()
    {
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
