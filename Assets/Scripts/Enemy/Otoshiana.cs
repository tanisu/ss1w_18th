using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoshiana : MonoBehaviour
{
    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sp.enabled = true;
        }
    }
}
