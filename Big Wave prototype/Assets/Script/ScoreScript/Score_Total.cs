using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Total : Score
{
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score += Score_TrickCount;//合計スコアにトリック成功スコアを加算
        score += Score_CriticalTrickCount;//合計スコアにトリックボタン指定成功ボーナスを加算
        score += Score_TrickCombo;//合計スコアにトリックコンボボーナスを加算
        score += Score_GameClear;//合計スコアにゲームクリアボーナスを加算
        score += Score_TimeLimit;//合計スコアに制限時間ボーナスを加算
        score += Score_HP;//合計スコアに残りHPボーナスを加算
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
