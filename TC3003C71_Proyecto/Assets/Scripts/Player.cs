using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 100;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            getDamage(damage);
        }
    }

    void Death()
    {
        
        UnityEngine.Color c = new UnityEngine.Color(1f, 0, 0);

        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.SetColor("_Color", c);
        

    }
}
