using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 1.0f;
    public bool isAttacking = false;
    private StarterAssets.StarterAssetsInputs _input;
    public Vector2 moveOld;
    Animator _animator;
    public Damage dmg;
    public bool alive = true;



    // Update is called once per frame

    private void Start()
    {
        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
        _animator = gameObject.GetComponent<Animator>();
        moveOld = _input.move;
        dmg = gameObject.GetComponent<Damage>();
    }
    void Update()
    {
        if(alive){
            if(_input.attack && canAttack) 
            {
                SwordAttack();
            }
            else if(moveOld != _input.move)
            {
                _animator.SetBool("Move", true);
            }
            else if(_input.jump){
                _animator.SetTrigger("Jump");
            }
            else
            {
                _animator.SetBool("Move", false);
            }

            if(dmg.life <= 0){
                alive = false;
                _animator.SetTrigger("Dead");
            }
        }
        
    }

    public void SwordAttack(){
        isAttacking = true;
        canAttack = false;
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
