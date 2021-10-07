using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoopManager : MonoBehaviour
{
    private int loopCount = 0;
    [SerializeField] int loopMax,loopMin,changeLoopCount;
    [SerializeField] Tilemap mapSprite;
    [SerializeField] GameObject itemTiles, keyItem, houtyouGenerator, trap, enemiyWrapper, globalLight, pointLight, nextConfiner;
    [SerializeField] WrapPoint[] wrapPoints;
    [SerializeField] Vector2 nextPos;
    [SerializeField] Color[] colors;
    GameObject startPoint;
    GameObject player;
    Enemy[] enemies;
    
    void Start()
    {
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = enemiyWrapper.GetComponentsInChildren<Enemy>();
        
    }

    
    void Update()
    {
        
    }

    public void Loop()
    {
        
        
        loopCount++;
        player.transform.position = startPoint.transform.position;
        player.GetComponent<player>().RepeatDream();
        if (houtyouGenerator)
        {
            houtyouGenerator.SetActive(false);
        }
        _changeWithLoop();
        startPoint.GetComponent<StartPoint>().Restart();


    }

    public void AddLoop()
    {
        loopCount++;
       
        _changeWithLoop();

    }


    private void _changeWithLoop()
    {
        if (enemies.Length > 0)
        {
            foreach (Enemy enemy in enemies)
            {
                
                enemy.SetBaseColor();
                enemy.StopMove();
                //enemy.SetStartPos();
            }
        }
        if (loopCount == loopMin)
        {
            if (trap)
            {
                trap.SetActive(true);
            }
            if (wrapPoints.Length > 0)
            {
                foreach (WrapPoint wrapPoint in wrapPoints)
                {
                    wrapPoint.ChangeConfiner(nextConfiner);
                    wrapPoint.ChangeNextPos(nextPos);
                }
            }
            
        }

        if (loopCount == changeLoopCount)
        {
            SoundManager.instance.StopBGM();
            SoundManager.instance.PlayBGM(SoundManager.BGM.Danger);
            if (itemTiles)
            {
                itemTiles.SetActive(true);
            }
            if (keyItem)
            {
                keyItem.SetActive(true);
            }
            

            //if (houtyouGenerator)
            //{
            //    houtyouGenerator.SetActive(true);
            //}
            if (enemies.Length > 0)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    
                    enemies[i].ChangeChase();
                }
            }
            globalLight.SetActive(false);
            pointLight.SetActive(true);


        }
        if(mapSprite && loopCount >= loopMin)
        {
            int idx = loopCount -1;
            if (loopCount >= colors.Length)
            {
                idx = colors.Length - 1;
            }

            mapSprite.color = colors[idx];
        }
        
    }
}
