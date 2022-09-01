using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int life = 100;
    public int damage = 55;
    
    // Update is called once per frame
    void Update()
    {
        if (life <= 10)
        {
            Death();
        }
    }

    public void getDamage(int damage) {

        life-=damage;

    }

    // Editar la funcion para analizar que le pego
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Weapon")
        {
            getDamage(damage);
        }
    }

    void Death()
    {
        
        UnityEngine.Color c = new UnityEngine.Color(1f, 0, 0);


        // EDITAR ESTO PARA QUE SE MUERA EL PERSONAJE
        // Renderer rend = gameObject.GetComponent<Renderer>();
        // rend.material.SetColor("_Color", c);
        

    }
}