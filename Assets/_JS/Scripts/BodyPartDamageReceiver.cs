using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartDamageReceiver : MonoBehaviour
{
    [SerializeField] private float damageMultiplier = 1.0f; // ������ ��� ���� (��: �Ӹ� 2.0, �� 0.5 ��)
    private Status playerStat;

    void Awake()
    {
        playerStat = GetComponent<Status>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Arrow arrow = other.GetComponent<Arrow>();
            float hitVelocity = other.attachedRigidbody != null ? other.attachedRigidbody.velocity.magnitude : 1.0f;
            
            float totalDamage = arrow.BaseDamage * hitVelocity * damageMultiplier;
            Debug.Log(totalDamage + "�¾Ҵ�!");
            playerStat.ReduceHp(totalDamage);
        }
        
    }
}
