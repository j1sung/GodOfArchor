using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartDamageReceiver : MonoBehaviour
{
    [SerializeField] private float damageMultiplier = 1.0f; // 부위별 계수 설정 (예: 머리 2.0, 팔 0.5 등)
    private PlayerStatus playerStat;

    void Awake()
    {
        playerStat = GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Arrow arrow = other.GetComponent<Arrow>();
            float hitVelocity = other.attachedRigidbody != null ? other.attachedRigidbody.velocity.magnitude : 1.0f;
            
            float totalDamage = arrow.BaseDamage * hitVelocity * damageMultiplier;
            Debug.Log(totalDamage + "맞았다!");
            //playerStat.ReduceHp(totalDamage);
        }
        
    }
}
