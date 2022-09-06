using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject espada;
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 1.0f;
    public bool isAttacking = false;
    private StarterAssets.StarterAssetsInputs _input;


    // Update is called once per frame

    private void Start()
    {
        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
    }
    void Update()
    {
        if(_input.attack && canAttack) 
        {
            SwordAttack();
        }
        
    }

    public void SwordAttack(){
        isAttacking = true;
        canAttack = false;
        Animator _animator = espada.GetComponent<Animator>();
        _animator.SetTrigger("Attack");
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown(){
        StartCoroutine(ResetAttack());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttack(){
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
