using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    public void ChangeTimeScale(bool stopTime)//ゲーム時間の早さを変更、stopTimeがtrueなら時間を止める、falseなら時間を1倍速に戻す
    {
        Time.timeScale = stopTime ? 0 : 1;// ゲームの時間経過を制御する
    }
}
