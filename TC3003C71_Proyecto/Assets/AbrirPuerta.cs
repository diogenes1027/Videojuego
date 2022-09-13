using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public string nombreAliado;
    public bool abierta = false;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(nombreAliado) && abierta == false)
        {
            anim.SetBool("Open", true);
            abierta = true;
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator CloseDoor(){
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("Open", false);
        abierta = false;
    }
}
