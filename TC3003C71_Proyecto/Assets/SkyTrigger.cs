using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTrigger : MonoBehaviour
{
    private StarterAssets.ThirdPersonController tPC;
    private WeaponController weaponC;
    [SerializeField]private bool flag;
  

    private void Awake()
    {
        Transform tr;
        tr = transform.parent;
        tPC = tr.GetComponent<StarterAssets.ThirdPersonController>();
        weaponC = tr.GetComponent<WeaponController>();
        flag = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("HitObject") && flag)
        {
            Debug.Log("skyHit");
            flag = false;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            
            Time.timeScale = .3f ;
            tPC.SetJumpHeight(5);
            weaponC.SetHit_(true);
            StartCoroutine(SlowEnd(rb));
        }
    }
    private IEnumerator SlowEnd(Rigidbody rb)
    {
        Debug.Log("slow Auto");
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        rb.isKinematic = false;
        weaponC.SetHit_(false);
        tPC.SetJumpHeight(1.2f);

    }


}
