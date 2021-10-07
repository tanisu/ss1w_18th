using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameState gameState;
    [SerializeField] LoopManager loopManager;
    [SerializeField] GameObject messageText;
    private Text mess;
    private Fade fade;
    private bool hasMoney;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mess = messageText.GetComponent<Text>();
        gameState = GameState.PLAY;
        if (GameObject.Find("FadeCanvas"))
        {
            fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
            if (fade)
            {
                mess.text = "やべ、また会社で寝ちゃった！";
                StartCoroutine("_startFade");
                //fade.FadeOut(1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsCatch(){


        StartCoroutine(_doFade());
    }

    private IEnumerator _startFade()
    {
        
        messageText.SetActive(true);
        yield return new WaitForSeconds(1f);
        messageText.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fade.FadeOut(1f);
    }

    private IEnumerator _doFade()
    {
        fade.FadeIn(1f, () => { loopManager.Loop(); });
        yield return new WaitForSeconds(1.1f);
        mess.text = "なんだ、、、夢か、、";
        StartCoroutine("_startFade");
        //fade.FadeOut(1f);
    }

    public void StageClear(string nextSecne)
    {
        fade.FadeIn(1f, () => SceneManager.LoadScene(nextSecne));
    }

  


}
