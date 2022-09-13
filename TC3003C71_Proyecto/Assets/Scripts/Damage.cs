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
    Animator animator;


    private void Awake()
    {
        //transform.localPosition = new Vector3(10, 10, 10);
        //transform.parent.gameObject.transform.localPosition = new Vector3(10, 10, 10);

        animator = gameObject.GetComponent<Animator>();

        if (transform.CompareTag("Player"))
        {
            childDetach = transform.GetChild(3);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Death();
            //childDetach.DetachChildren();

        }
        else animator.SetBool("Open", false);
    }

    public void getDamage(int damage)
    {

        life -= damage;


    }

    // Editar la funcion para analizar que le pego
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Weapon" && gameObject.tag != "Player")
        {
            getDamage(damage);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower" && canGetDamage)
        {
            canGetDamage = false;
            getDamage(damage);
            StartCoroutine(ResetDamage());
        }
    }

    void Death()
    {

        //UnityEngine.Color c = new UnityEngine.Color(1f, 0, 0);


        // EDITAR ESTO PARA QUE SE MUERA EL PERSONAJE
        // Renderer rend = gameObject.GetComponent<Renderer>();
        // rend.material.SetColor("_Color", c);

        if (gameObject.CompareTag("Player"))
        {

            //animacion de muerte
            //Vector3 position = new Vector3(200f, 200f, 200f);
            //life = 100;
            //gameObject.transform.parent.gameObject.transform.localPosition = position;
            
            //animator.SetTrigger("Dead");
            Respawn();
        }
        else if (gameObject.CompareTag("Door") && life<= 0)
        {
            
            if (life <= 0)
            {
                animator.SetBool("Open", true);
            }
            
            
        }
        

    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(5.0f);
        canGetDamage = true;
    }

    void Respawn()
    {
        Debug.Log("Hola");
;        life = 100;
        transform.parent.gameObject.transform.localPosition = new Vector3(200, 200, 200);
        //transform.parent.gameObject.transform.localPosition = new Vector3(200f, 200f, 200f); ;
        //gameObject.transform.parent.gameObject.transform.localPosition = position;
        //transform.localPosition = position;
    }
}