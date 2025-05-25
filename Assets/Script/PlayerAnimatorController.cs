using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public float MoveSpeed
    {
        set => animator.SetFloat("movementSpeed", value);
        get => animator.GetFloat("movementSpeed");
    }

    public float BowState
    {
        set => animator.SetFloat("BowState", value);
        get => animator.GetFloat("BowState");
    }

    public void triggerRelease()
    {
        animator.SetTrigger("Release");
    }

    public void triggerShoot() 
    {
        animator.SetTrigger("Shoot");
    }
    public void Play(string stateName, int layer, float normalizedTime)
    {
        animator.Play(stateName, layer, normalizedTime);
    }
}
