using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int life = 100;
    public int damage = 25;
    public bool canGetDamage = true;
    private Transform childDetach;
    private StarterAssets.ThirdPersonController tpc;
    private StarterAssets.StarterAssetsInputs sai;

    Animator animator;
    public Vector3 position_ = new Vector3(44.83648f, 0.4447613f, -3.45f);



    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();

        if (transform.CompareTag("Player"))
        {
            childDetach = transform.GetChild(3);
            tpc = GetComponent<StarterAssets.ThirdPersonController>();
            sai = GetComponent<StarterAssets.StarterAssetsInputs>();
        }
        
    }
   
    // Update is called once per frame
    void Update()
    {

        if (life <= 0)
        {
            Death();
            childDetach.DetachChildren();
        }
        else if (life > 0 && gameObject.CompareTag("Door")) {
            animator.SetBool("Open", false);
        } 
    }

    public void getDamage(int damage) {

        life-=damage;
        

    }

    // Editar la funcion para analizar que le pego
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Weapon" && gameObject.tag != "Player")
        {
            getDamage(damage);
        }
    }

    void OnTriggerStay(Collider other){
        if (other.tag == "Tower" && canGetDamage)
        {
            canGetDamage = false;
            getDamage(damage);
            StartCoroutine(ResetDamage());
        }
    }

    void Death()
    {
        
        UnityEngine.Color c = new UnityEngine.Color(1f, 0, 0);

        if (gameObject.CompareTag("Player"))
        {

            //animacion de muerte

            StartCoroutine(Respawn());
        }
        else if (gameObject.CompareTag("Door") && life <= 0)
        {

            if (life <= 0)
            {
                animator.SetBool("Open", true);
            }


        }
        // EDITAR ESTO PARA QUE SE MUERA EL PERSONAJE
        // Renderer rend = gameObject.GetComponent<Renderer>();
        // rend.material.SetColor("_Color", c);


    }
    
    IEnumerator ResetDamage(){
        yield return new WaitForSeconds(5.0f);
        canGetDamage = true;
    }
    public IEnumerator CallEffectTimeSword(GameObject gameO, float time, int newValue)
    {
        if (sai.Item)
        {
            tpc.ItemB(false);
            gameO.GetComponent<MeshRenderer>().enabled = false;
            gameO.GetComponent<BoxCollider>().enabled = false;
            damage = newValue;

            yield return new WaitForSeconds(time);
            Destroy(gameO);

            damage = 25;
            tpc.ItemB(true);
        }
        
    }

    IEnumerator Respawn()
    {
        life = 100;
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(3.0f);

        gameObject.transform.position = position_;
    }

}