using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTitle : MonoBehaviour
{
    [SerializeField] Fade fade;
    public float fadeTime = 1f;
    public void OnNextScene()
    {
        fade.FadeIn(fadeTime, () => SceneManager.LoadScene("Office"));
    }
}
