using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private float newValue;
    [SerializeField] private float valueLvl1;
    [SerializeField] private float valueLvl2;
    [SerializeField] private float valueLvl3;

    [SerializeField] private float effectTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Damage dam = other.GetComponent<Damage>();
            StartCoroutine(dam.CallEffectTimeSword(gameObject, 10, 50));
        }
    }
}
