using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int count = 0;

    public GameObject chicken;

    // Obtener collider
    Collider _Collider;
    SphereCollider _Collider2;
    // Conseguir limites de la zona
    Vector3 _Min, _Max;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetColliders());
    }

    // Update is called once per frame
    void Update()
    {
        if (_Collider2 != null){
            GetObjectsIn(_Collider2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChickenMark") && other.transform.parent.gameObject.CompareTag("Player")){
            
            Destroy(other.gameObject);
            

            Vector3 randPos = new Vector3(Random.Range(_Min.x, _Max.x), Random.Range(_Min.y, _Max.y), Random.Range(_Min.z, _Max.z));
            Instantiate(chicken, _Collider.ClosestPoint(randPos), Quaternion.identity);
            
        }
    }

    private void GetObjectsIn(SphereCollider collider)
    {
        //Debug.Log(collider.transform.position);
        //Debug.Log(collider.radius);
        Collider[] colliders = Physics.OverlapSphere(collider.transform.position, 12);
        List<GameObject> objectsInSphere = new List<GameObject>();
        foreach (var c in colliders){
            if (c.gameObject.CompareTag("Chicken") && !objectsInSphere.Contains(c.gameObject)){
                objectsInSphere.Add(c.gameObject);
            }
        }
        count = objectsInSphere.Count;
    }

    IEnumerator GetColliders(){
        yield return new WaitForSeconds(2.0f);
        _Collider = GetComponent<BoxCollider>();
        _Min = _Collider.bounds.min;
        _Max = _Collider.bounds.max;
        _Collider2 = GetComponent<SphereCollider>();
    }
}
