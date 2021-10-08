using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrigger : MonoBehaviour
{
    [SerializeField] GameObject trap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(_dobBites());

            trap.SetActive(true);
        }
    }

    IEnumerator _dobBites()
    {
        for(int i = 0;i < 5; i++)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.DogBite);
            yield return new WaitForSeconds(0.12f);
            SoundManager.instance.PlaySE(SoundManager.SE.DogBite);
        }
    }
}
