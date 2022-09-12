using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] WeaponController wc;
    [SerializeField] Transform score;
    

    void OnTriggerEnter(Collider other)
    {
        /*if(other.CompareTag( "Enemy") && wc.isAttacking)
        {
            StartCoroutine(wc.AttackCooldown());
            other.GetComponent<Animator>().SetTrigger("Attacked");
        }
        else if(other.CompareTag("Tree") && wc.isAttacking)
        {
            StartCoroutine(wc.AttackCooldown());
            other.GetComponent<Animator>().SetTrigger("Attacked");
        }*/
        
            Debug.Log("hit");
        if (other.CompareTag("HitObject") && wc.GetHit_())
        {
            Time.timeScale = 1;

            Debug.Log("hit2");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(score.position.normalized*50 +(Vector3.up*15f), ForceMode.VelocityChange);
            wc.SetHit_(false);
            }
        

    }
    
}
