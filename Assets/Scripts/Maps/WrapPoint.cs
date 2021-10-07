using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WrapPoint : MonoBehaviour
{
    [SerializeField] Vector2 nextPos;
    //[SerializeField] Fade fade;
    [SerializeField] GameObject nextConfiner;
    [SerializeField] GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySE(SoundManager.SE.Transition);
            collision.gameObject.transform.position = nextPos;
            cam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = nextConfiner.GetComponent<Collider2D>();
            
            
            
        }
    }
    public void ChangeNextPos(Vector2 pos) {
            nextPos = pos;
        } 

    public void ChangeConfiner(GameObject confiner)
    {
        nextConfiner = confiner;
    }
}
