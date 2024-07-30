using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class Drawer_Pull_Zopp : MonoBehaviour
    {
        [Header("Components")]
        public Animator pull;
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
            Debug.Log("You are opening the drawer");
            pull.Play("openpullopp");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator Closing()
        {
            Debug.Log("You are closing the drawer");
            pull.Play("closepushopp");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
