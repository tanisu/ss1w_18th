using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satutaba : MonoBehaviour
{
    [SerializeField] GameObject[] wrapPoints;
    [SerializeField] GameObject nextConfiner;
    [SerializeField] Vector2 nextPos;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(wrapPoints.Length > 0)
            {
                foreach(GameObject wrapPoint in wrapPoints)
                {
                    wrapPoint.GetComponent<WrapPoint>().ChangeConfiner(nextConfiner);
                    wrapPoint.GetComponent<WrapPoint>().ChangeNextPos(nextPos);
                    wrapPoint.GetComponent<DeadPoint>().IsClear();
                }
            }
            Destroy(gameObject);
        }
    }
}
