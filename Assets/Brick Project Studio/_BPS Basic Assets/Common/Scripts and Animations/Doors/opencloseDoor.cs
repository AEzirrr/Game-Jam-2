using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
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
                if(openText != null)
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
            Debug.Log("You are opening the door");
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator Closing()
        {
            Debug.Log("You are closing the door");
            openandclose.Play("Closing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
