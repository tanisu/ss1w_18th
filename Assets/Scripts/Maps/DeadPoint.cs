using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    private bool isClear;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isClear)
        {
            collision.GetComponent<player>().FallBillding();
        }
    }

    public void IsClear()
    {
        isClear = true;
    }

}
