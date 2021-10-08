using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject trap,beforeTrap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            trap.SetActive(true);
            if (beforeTrap)
            {
                beforeTrap.SetActive(false);
            }
        }
    }

}
