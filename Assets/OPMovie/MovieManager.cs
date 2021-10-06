using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieManager : MonoBehaviour
{
    public GameObject panelParent;
    public Image fadePanel00;
    public Image endPanel00;
    public Text startText;
    public Text creditText;
    public AudioSource audioSource;
    public Fade fade;


    private void Start()
    {
        StartCoroutine(StartMovie());

    }

    IEnumerator StartMovie()
    {
        yield return new WaitForSeconds(3);
        audioSource.Play();
        yield return new WaitForSeconds(3);
        startText.text = ("タニス谷山\nasahi\nくわぽん\npresents");
        yield return new WaitForSeconds(3);
        startText.DOFade(0f, 2f);
        fadePanel00.DOFade(0f, 5f);
        yield return new WaitForSeconds(8);
        StartCoroutine(MovePatarn01(0.05f));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(MovePatarn01(0.1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(MovePatarn01(0.2f));
        yield return new WaitForSeconds(4f);
        panelParent.transform.localPosition = new Vector2(0, 1200);
        yield return new WaitForSeconds(1.5f);
        panelParent.transform.localPosition = new Vector2(0, 3000);
        yield return new WaitForSeconds(2);
        panelParent.transform.localPosition = new Vector2(-1000, 1800);
        yield return new WaitForSeconds(3);
        StartCoroutine(MovePatarn01(0.02f));
        yield return new WaitForSeconds(0.16f);
        panelParent.transform.localPosition = new Vector2(0, 600);
        yield return new WaitForSeconds(1.5f);
        panelParent.transform.localPosition = new Vector2(-1000, 600);
        yield return new WaitForSeconds(1.5f);
        panelParent.transform.localPosition = new Vector2(-1000, 2400);
        yield return new WaitForSeconds(3);
        panelParent.transform.localPosition = new Vector2(-1000, 0);
        creditText.text = ("SpecialThanks\nスタジオしまづ");
        creditText.DOFade(0f, 6f);
        yield return new WaitForSeconds(3);
        panelParent.transform.localPosition = new Vector2(0, 600);
        endPanel00.DOFade(1, 10f);
        yield return new WaitForSeconds(11);
        





    }

    IEnumerator MovePatarn01(float flashTime)
    {
        
            panelParent.transform.localPosition = new Vector2(0, 600);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(0, 1200);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(0, 1800);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(0, 2400);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(0, 3000);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(0, 3600);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(-1000, 0);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(-1000, 600);
            yield return new WaitForSeconds(flashTime);
            panelParent.transform.localPosition = new Vector2(-1000, 1200);
    
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fade.FadeIn(1f, () => SceneManager.LoadScene("Office"));
            
        }
    }
}
