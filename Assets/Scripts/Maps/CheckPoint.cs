using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject currentConfiner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {

            CheckPointManager.I.SetRestartPos(transform.position.x,currentConfiner.name);
            
        }
    }
}
