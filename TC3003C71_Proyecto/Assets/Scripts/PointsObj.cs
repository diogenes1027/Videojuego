using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObj : MonoBehaviour
{
    // Obtener collider
    Collider _Collider;
    // Conseguir limites de la zona
    Vector3 _Min, _Max, _Center;

    // Objeto a instanciar
    public GameObject objectToInstantiate;
    // Cantidad de objetos a iterar
    public int numObj;

    // Start is called before the first frame update
    void Start()
    {
        _Collider = GetComponent<Collider>();
        _Min = _Collider.bounds.min;
        _Max = _Collider.bounds.max;
        _Center = _Collider.bounds.center;

        SummonObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SummonObjects()
    {
        for(int i = 0; i < numObj; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(_Min.x, _Max.x), _Center.y , Random.Range(_Min.z, _Max.z));
            Instantiate(objectToInstantiate, _Collider.ClosestPoint(randPos), objectToInstantiate.transform.rotation);
        }

    }
}
