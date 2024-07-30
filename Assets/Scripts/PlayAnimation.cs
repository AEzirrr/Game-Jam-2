using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private string animationName;

    void Start()
    {
        if (animator != null && !string.IsNullOrEmpty(animationName))
        {
            animator.Play(animationName);
        }
        else
        {
            Debug.LogError("Animator component or animation name not set.");
        }
    }
}
