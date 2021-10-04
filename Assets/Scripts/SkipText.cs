using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipText : MonoBehaviour
{
    public GameObject skipText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlashText());
    }

    IEnumerator FlashText()
    {
        while(true)
        {
            skipText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            skipText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
