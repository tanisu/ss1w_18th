using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameState gameState;
    [SerializeField]
    private LoopManager loopManager;
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
        gameState = GameState.PLAY;
        if (GameObject.Find("FadeCanvas"))
        {
            fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
            if (fade)
            {
                fade.FadeOut(1f);
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

    private IEnumerator _doFade()
    {
        fade.FadeIn(1f, () => { loopManager.Loop(); });
        yield return new WaitForSeconds(1.1f);
        fade.FadeOut(1f);
    }

    public void GetMoney()
    {
        //to nextScene
        hasMoney = true;
    }

    public void ChangeGameState(GameState g)
    {
        gameState = g;
    }

    public void GameOver()
    {
        gameState = GameState.GAMEOVER;
        fade.FadeIn(1f, () => SceneManager.LoadScene("GameOver"));

        // to GameOverScene
    }
}
