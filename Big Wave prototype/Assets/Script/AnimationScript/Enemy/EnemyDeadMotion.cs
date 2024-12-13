using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//作成者:杉山
//敵の死亡モーション
//数秒モーションさせた後、爆発させてモデルの方を非表示にする
public class EnemyDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _enemy_animator;
    [SerializeField] string _deadTriggerName;
    [Header("撃破時に生成するエフェクト")]
    [SerializeField] DefeatEffect _defeatEffect;
    [Header("表示状態を切り替えるオブジェクト")]
    [SerializeField] ChangeActiveObject[] _changeObjects;
    bool _startMotion = false;

    public void Trigger()
    {
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;  
    }

    void Update()
    { 
        UpdateEffect();
    }

    void UpdateEffect()
    {
        if (!_startMotion) return;

        //撃破時に生成するエフェクト
        _defeatEffect.GenerateDefeatEffect();

        //表示状態を切り替えるオブジェクト
        for (int i = 0; i < _changeObjects.Length; i++)
        {
            _changeObjects[i].UpdateActive();
        }
    }

   
}