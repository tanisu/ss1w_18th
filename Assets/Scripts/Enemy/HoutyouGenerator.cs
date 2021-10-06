using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoutyouGenerator : MonoBehaviour
{
    [SerializeField] GameObject houtyouPrefab;
    void Start()
    {
        // InvokeRepeating("Spawn", 2f, 0.5f);
        StartCoroutine(_spawn());
    }

    IEnumerator _spawn()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(3.5f);
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(-11f, -15.5f), transform.position.z);
            Instantiate(houtyouPrefab, spawnPos, transform.rotation);
            
        }
        
    }


}
