using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

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

    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }

    public void TriggerShoot() 
    {
        animator.SetTrigger("Shoot");
    }
    public void Play(string stateName, int layer, float normalizedTime)
    {
        animator.Play(stateName, layer, normalizedTime);
    }
}
