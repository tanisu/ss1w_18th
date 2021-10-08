using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGenerator : MonoBehaviour
{
    [SerializeField] GameObject houtyouPrefab;
    [SerializeField] float minPosX, maxPosX, span;


    private void Start()
    {
        StartCoroutine(_spawn());

    }

    IEnumerator _spawn()
    {

        while (true)
        {
            yield return new WaitForSeconds(span);
            Vector3 spawnPos = new Vector3( Random.Range(minPosX, maxPosX), transform.position.y, transform.position.z);
            Instantiate(houtyouPrefab, spawnPos,transform.rotation , transform);

        }
    }

    public void StartHoutyou()
    {
        StartCoroutine(_spawn());
    }

}
