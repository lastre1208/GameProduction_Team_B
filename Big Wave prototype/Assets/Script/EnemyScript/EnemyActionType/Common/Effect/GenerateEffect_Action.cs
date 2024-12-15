using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//行動時にエフェクトを出す
public class GenerateEffect_Action : MonoBehaviour
{
    [Header("エフェクトの設定")]
    [SerializeField] Effects_GenerateEffect_Action[] _effects;//エフェクトの設定
    float _currentDelayTime;//現在の遅延時間

    public void OnEnter()//行動開始時に呼ぶ
    {
        _currentDelayTime = 0;//現在の遅延時間をリセット

        for(int i=0; i<_effects.Length;i++)
        {
            _effects[i].Effected = false;//全てのエフェクトの設定をエフェクトを出してない状態にする
        }
    }

    public void OnUpdate()//行動中舞フレーム呼ぶ
    {
        _currentDelayTime += Time.deltaTime;

        for(int i=0; i<_effects.Length;i++)//全てのエフェクトの設定から今エフェクトを生成するか判断
        {
            Effects_GenerateEffect_Action effect = _effects[i];

            if(_currentDelayTime >= effect.DelayTime && !effect.Effected)
            {
                GenerateEffect(effect);
            }
        }
    }

    void GenerateEffect(Effects_GenerateEffect_Action effect)
    {
        effect.Effected = true;

        //エフェクトを生成する位置と角度を取得
        Vector3 effectPos = effect.EffectPos.transform.position;//位置
        Quaternion effectRot = effect.EffectPos.transform.rotation;//角度

        Instantiate(effect.Effect, effectPos, effectRot, effect.EffectPos);//エフェクトの生成
    }

}
