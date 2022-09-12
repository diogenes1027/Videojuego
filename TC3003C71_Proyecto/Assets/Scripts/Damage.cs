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


    private void Awake()
    {
        if (transform.CompareTag("Player"))
        {
            childDetach = transform.GetChild(3);
        }
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (life <= 10)
        {
            Death();
            childDetach.DetachChildren();
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


        // EDITAR ESTO PARA QUE SE MUERA EL PERSONAJE
        // Renderer rend = gameObject.GetComponent<Renderer>();
        // rend.material.SetColor("_Color", c);
        

    }
    
    IEnumerator ResetDamage(){
        yield return new WaitForSeconds(5.0f);
        canGetDamage = true;
    }
}