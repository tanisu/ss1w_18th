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
        
        for(int i = 0;i < 5; i++)
        {
            yield return new WaitForSeconds(5f);
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(-1f, -4f), transform.position.z);
            Instantiate(houtyouPrefab, spawnPos, transform.rotation);
            
        }
        
    }


}
