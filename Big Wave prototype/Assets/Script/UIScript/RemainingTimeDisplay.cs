using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山

public class RemainingTimeDisplay : MonoBehaviour
{
    [Header("▼表示させるテキスト")]
    [SerializeField] TMP_Text Time_UI;//表示させるテキスト
    [Header("時間")]
    [SerializeField] TimeLimit timeLimit;
    private int minutes;//残り時間(単位が分)
    private float seconds;//残り時間(単位が秒)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(timeLimit.RemainingTime/60);//分の更新
        seconds= timeLimit.RemainingTime%60;//秒の更新
        Time_UI.text = "TIME:" + minutes.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
    }
}
