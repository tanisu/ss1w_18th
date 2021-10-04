using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class StartPoint : MonoBehaviour
{
    
    [SerializeField] GameObject startConfiner;
    [SerializeField] GameObject cam;

    public void Restart()
    {
        cam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = startConfiner.GetComponent<Collider2D>();
    }
}
