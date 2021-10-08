using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTextChanger : MonoBehaviour
{
    public Text endingText;
    public Fade fade;

    public void Start()
    {
        endingText.text = ("");
    }

    public void Text00()
    {
        endingText.text = ("昨日、変な夢を見たんだ");
    }
    public void TextOff()
    {
            endingText.text = ("");
    }
    public void Text01()
    {
        endingText.text = ("ナイフが飛んできたり、、、");
    }
    public void Text02()
    {
        endingText.text = ("おっ！見えてきた");
    }
    public void Text03()
    {
        endingText.text = ("念願のマイホーム！！");
    }
    public void Text04()
    {
        endingText.text = ("これから君と犬と幸せに、、、");
        
    }

    public void OnButton()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Click);
        fade.FadeIn(1f, () => SceneManager.LoadScene("Office"));
    }

}
