using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Animator animator;

    public string enemigo;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if (other.CompareTag(enemigo) && canAttack){
            canAttack = false;
            animator.SetTrigger("Spikes");
            StartCoroutine(ResetAttack());
        }
    }

    IEnumerator ResetAttack(){
        yield return new WaitForSeconds(5.0f);
        canAttack = true;
    }
}
