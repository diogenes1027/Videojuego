using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTrigger : MonoBehaviour
{
    private StarterAssets.ThirdPersonController tPC;
    private WeaponController weaponC;
    private bool flag = true;
    
  

    private void Awake()
    {
        Transform tr;
        tr = transform.parent;
        tPC = tr.GetComponent<StarterAssets.ThirdPersonController>();
        weaponC = tr.GetComponent<WeaponController>();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("HitObject") && !weaponC.GetHit_() && flag)
        {
            flag = false;
            Debug.Log("skyHit");
            
            Rigidbody rb = other.GetComponent<Rigidbody>();
            AnimMovement animMovement = other.GetComponent<AnimMovement>();
            animMovement.DisableHitObject(true);
            
            
            Time.timeScale = .3f ;
            tPC.SetJumpHeight(5);
            weaponC.SetHit_(true);

            StartCoroutine(SlowEnd(rb));
        }
    }
    private IEnumerator SlowEnd(Rigidbody rb)
    {
        Debug.Log("slow Auto");
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1;
        if (rb)
        {
            rb.isKinematic = false;
        }
        weaponC.SetHit_(false);
        tPC.SetJumpHeight(1.2f);

    }


}
