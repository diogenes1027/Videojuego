using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTrigger : MonoBehaviour
{
    private StarterAssets.ThirdPersonController tPC;
    private WeaponController weaponC;
    private bool flag_ = true;
    
  

    private void Awake()
    {
        Transform tr;
        tr = transform.parent;
        tPC = tr.GetComponent<StarterAssets.ThirdPersonController>();
        weaponC = tr.GetComponent<WeaponController>();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("HitObject") && !weaponC.GetHit_() && flag_)
        {
            flag_ = false;
            Debug.Log("skyHit");
            
            Rigidbody rb = other.GetComponent<Rigidbody>();
            AnimMovement animMovement = other.GetComponent<AnimMovement>();
            animMovement.DisableHitObject(true,false);
            
            
            Time.timeScale = .3f ;
            tPC.SetJumpHeight(5);
            weaponC.SetHit_(true);

            StartCoroutine(SlowEnd(animMovement));
        }
    }
    private IEnumerator SlowEnd(AnimMovement animMovement)
    {
        Debug.Log("slow Auto");
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        if (animMovement)
        {
            animMovement.DisableHitObject(false,true);
        }
        weaponC.SetHit_(false);
        tPC.SetJumpHeight(1.2f);

    }


}
