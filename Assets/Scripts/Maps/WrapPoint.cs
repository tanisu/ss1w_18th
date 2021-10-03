using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WrapPoint : MonoBehaviour
{
    [SerializeField] Vector2 nextPos;
    [SerializeField] GameObject nextConfiner;
    [SerializeField] GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DummyPlayer"))
        {
            collision.gameObject.transform.position = nextPos;
            cam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = nextConfiner.GetComponent<Collider2D>();
        }
    }
}
