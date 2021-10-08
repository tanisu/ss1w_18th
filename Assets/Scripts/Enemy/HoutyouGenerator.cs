using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoutyouGenerator : MonoBehaviour
{
    [SerializeField] GameObject houtyouPrefab;
    [SerializeField] float minPos,maxPos,span;

    IEnumerator _spawn()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(span);
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z);
            Instantiate(houtyouPrefab, spawnPos, transform.rotation,transform);
            
        }
    }

    public void StartHoutyou()
    {
        StartCoroutine(_spawn());
    }


}
