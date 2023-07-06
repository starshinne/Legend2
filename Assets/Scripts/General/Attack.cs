using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Basic Data")]
    public int Damage;

    public float attackFreq;

    public float attackRange;
    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<CharacterData>()?.TakeDamage(this);
    }

}
