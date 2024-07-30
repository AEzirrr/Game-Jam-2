using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerX : MonoBehaviour
{
    public Animator pull_01;
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
        pull_01.Play("openpull_01");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Closing()
    {
        pull_01.Play("closepush_01");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
