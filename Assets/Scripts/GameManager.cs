using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text findText;
    [SerializeField] private Light spotlight;
    [SerializeField] private GameObject ghost;
    [SerializeField] private Animator ghostAnimator;
    [SerializeField] private AudioSource jumpScare;

    private float timer;
    private bool gameLost;
    private bool isFlickering;
    private bool ghostActivated;

    void Start()
    {
        timer = 0f;
        gameLost = false;
        isFlickering = false;
        ghostActivated = false;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameLost)
        {
            timer += Time.deltaTime;

            if (timer >= 175f && !isFlickering) // 175 seconds = 5 seconds left
            {
                StartCoroutine(FlickerLight());
            }

            if (timer >= 179.5f && !ghostActivated) // 179 seconds = 1 second left
            {
                ActivateGhost();
                jumpScare.Play();
            }

            if (timer >= 180f) // 180 seconds = 3 minutes
            {
                LoseGame();
            }
            else
            {
                UpdateTimerText();
            }
        }
    }

    private void UpdateTimerText()
    {
        float timeRemaining = 181f - timer;
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void LoseGame()
    {
        gameLost = true;
        timerText.text = "00:00";
        findText.text = "You Lose!";
        spotlight.enabled = false;
        // Implement further loss logic here, e.g., show a loss screen, restart the level, etc.
    }

    private IEnumerator FlickerLight()
    {
        isFlickering = true;
        while (timer < 180f)
        {
            spotlight.enabled = !spotlight.enabled;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
        spotlight.enabled = true;
    }

    private void ActivateGhost()
    {
        ghost.SetActive(true);
        ghostAnimator.SetBool("IsJumpscare", true);
        ghostActivated = true;
        StartCoroutine(DeactivateGhost(1.2f));
    }

    private IEnumerator DeactivateGhost(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        ghostAnimator.SetBool("IsJumpscare", false);
        ghost.SetActive(false);
    }
}
