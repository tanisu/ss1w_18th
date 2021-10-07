using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] bgmClips;
    public AudioClip[] seClips;
    public AudioSource bgmAudioSource;
    public AudioSource seAudioSource;

    public static SoundManager instance;

    //シーン移動でも音が途切れない
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum BGM
    {
        Opening,//0オープニング
        Normal,//1平常時
        Danger,//2異常時
        Ending,//3エンディング
    }

    public enum SE
    {
        Click,//0オープニングムービーでSpaceキー押下
        Transition,//1フロア移動
        Warp,//2スタート地点へ戻る（死に戻り音）
        Screaming,//3プレイヤーの断末魔（穴、エネミー接触、ナイフ接触等）
        ItemGet,//4札束ゲット
        StageClea,//5ステージクリア音
        Fall,//6穴やビルから落下
        KnifeDamage,//7ナイフ接触
        DogBite,//8ワンちゃんの鳴き声
        RunSingle,//9ダッシュ単音
        RunContinue,//10ダッシュ連続音

    }

    //BGM停止の関数
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    //BGM再生関数（引数にenumのBGM名を入れてください）※例SoundManager.instance.PlayBGM(SoundManager.BGM.Danger);
    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        bgmAudioSource.clip = bgmClips[index];
        bgmAudioSource.Play();
    }

    //SE再生関数（引数にenumのSE名を入れてください）※例SoundManager.instance.PlaySE(SoundManager.SE.Screaming);
    public void PlaySE(SE se)
    {
        int index = (int)se;
        seAudioSource.PlayOneShot(seClips[index]);
    }
}
