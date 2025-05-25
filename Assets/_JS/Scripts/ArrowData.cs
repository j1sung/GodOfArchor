using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowName", menuName = "ScriptableObjects/ArrowData", order = 0)]

public class ArrowData : ScriptableObject
{
    public string arrowName = "Default Arrow";
    public float baseDamage = 10f;
    public float knockback = 0f;
    public Sprite icon;
    public GameObject prefab; // 화살 프리팹 (옵션)
    public AudioClip hitSound; // 피격 사운드 (옵션)
    // 추후 추가: 속도 보정, 이펙트, 상태이상 등
}
