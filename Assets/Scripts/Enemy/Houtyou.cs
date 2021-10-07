using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houtyou : MonoBehaviour
{

    [SerializeField] float speed;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player>().PlayerDead();
            SoundManager.instance.PlaySE(SoundManager.SE.KnifeDamage);
            SoundManager.instance.PlaySE(SoundManager.SE.Screaming);
            GameManager.I.IsCatch();
            Destroy(gameObject);
        }
    }
}
