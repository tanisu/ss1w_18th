using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoShake());
    }

    IEnumerator DoShake()
    {
        while(true)
        {
            transform.DOShakePosition(1f, 5f, 200, 3, false, false);
            yield return new WaitForSeconds(1);
        }
        
    }
}
