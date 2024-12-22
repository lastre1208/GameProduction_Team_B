using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動時に効果音を出す
public class PlayAudio_Action : MonoBehaviour
{
    [Header("効果音の設定")]
    [SerializeField] Audios_PlayAudio_Action[] _audios;//効果音の設定
    float _currentDelayTime;//現在の遅延時間

    public void OnEnter()//行動開始時に呼ぶ(初期化処理)
    {
        _currentDelayTime = 0;//現在の遅延時間をリセット

        for (int i = 0; i < _audios.Length; i++)
        {
            _audios[i].Played = false;//全てのエフェクトの設定をエフェクトを出してない状態にする
        }
    }

    public void OnUpdate()//行動中舞フレーム呼ぶ(更新処理)
    {
        _currentDelayTime += Time.deltaTime;

        for (int i = 0; i < _audios.Length; i++)//全てのエフェクトの設定から今エフェクトを生成するか判断
        {
            Audios_PlayAudio_Action audio = _audios[i];

            if (_currentDelayTime >= audio.DelayTime && !audio.Played)
            {
                PlayAudio(audio);
            }
        }
    }

    void PlayAudio(Audios_PlayAudio_Action audio)//効果音を出す
    {
        audio.Played = true;
        audio.Play();
    }
}
