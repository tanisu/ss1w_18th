using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckPointManager : MonoBehaviour
{

    public static CheckPointManager I;
    public Vector3 restartPos;
    public string currentConfinerName;
    private GameObject cam,currentConfiner;
    
    
    

    private void Awake()
    {
        if(I == null)
        {
            I = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRestartPos(float x,string confinerName)
    {
        restartPos = new Vector3(x, 0, 0);
        currentConfinerName = confinerName;
    }

    public void RestartPos()
    {
        cam = GameObject.FindWithTag("vcam");
        currentConfiner = GameObject.Find(currentConfinerName);
        cam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = currentConfiner.GetComponent<Collider2D>();
        
    }
}
