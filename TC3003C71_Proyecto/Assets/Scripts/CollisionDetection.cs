using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] WeaponController wc;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            StartCoroutine(wc.AttackCooldown());
            other.GetComponent<Animator>().SetTrigger("Attacked");
        }
        else if(other.tag == "Tree" && wc.isAttacking)
        {
            StartCoroutine(wc.AttackCooldown());
            other.GetComponent<Animator>().SetTrigger("Attacked");
        }
    }
}
