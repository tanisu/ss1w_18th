using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] dogs;
    [SerializeField] BoxCollider2D area;
    void Start()
    {
        StartCoroutine(_spawn());
    }

    IEnumerator _spawn()
    {
        for(int i = 0;i < 50; i++)
        {
            int idx = Random.Range(0, 2);
            yield return new WaitForSeconds(0.2f);
            
            Vector3 spawnPos = new Vector3(0, Random.Range(area.bounds.min.y,area.bounds.max.y), transform.position.z);
            Debug.Log(spawnPos);
            GameObject dog = Instantiate(dogs[idx], spawnPos, transform.rotation);
            dog.GetComponent<Dog>().area = area;

        }
            
        
    }
}
