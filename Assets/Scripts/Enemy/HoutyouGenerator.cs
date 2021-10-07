using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoutyouGenerator : MonoBehaviour
{
    [SerializeField] GameObject houtyouPrefab;
    [SerializeField] float minPos,maxPos;

    IEnumerator _spawn()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(3.5f);
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z);
            Instantiate(houtyouPrefab, spawnPos, transform.rotation);
            
        }
    }

    public void StartHoutyou()
    {
        StartCoroutine(_spawn());
    }


}
