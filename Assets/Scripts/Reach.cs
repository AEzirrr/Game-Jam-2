using UnityEngine;

public class Reach : MonoBehaviour
{
    [SerializeField]
    private LockedDoorScript lockedDoorScript;

    public AudioSource keyPickUp;

    private bool isInTriggerZone = false;
    private GameObject keyObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            isInTriggerZone = true;
            keyObject = other.gameObject;
            Debug.Log("Key In Range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            isInTriggerZone = false;
            keyObject = null;
            Debug.Log("Key Out of Range");
        }
    }

    private void Update()
    {
        if (isInTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("KEY PICKED UPPPPP");

            if (keyObject != null)
            {
                keyPickUp.Play();
                Destroy(keyObject);
                lockedDoorScript.KeyPickedUp();
            }
        }
    }
}
