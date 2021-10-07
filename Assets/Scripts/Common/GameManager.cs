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
    private string[] mess_2 = new string[] { "あれ、外でねちゃったのか","酒、呑みすぎたかな？","ママ、ママはどこ！え、夢？" };
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
        SoundManager.instance.PlayBGM(SoundManager.BGM.Normal);
        if (GameObject.Find("FadeCanvas"))
        {
            fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
            if (fade)
            {
                if(SceneManager.GetActiveScene().name == "Office")
                {
                    mess.text = "やべ、また会社で寝ちゃった！";
                }
                else
                {
                    string m = mess_2[Random.Range(0, mess_2.Length )];
                    mess.text = m;
                }
                
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
        fade.FadeIn(1f, () => { 
            if(SceneManager.GetActiveScene().name == "Office")
            {
                loopManager.Loop();
            }
            else if(SceneManager.GetActiveScene().name == "Town")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        });
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
