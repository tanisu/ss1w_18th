using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satutaba : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("get Money");
            Destroy(gameObject);
        }
    }
}
