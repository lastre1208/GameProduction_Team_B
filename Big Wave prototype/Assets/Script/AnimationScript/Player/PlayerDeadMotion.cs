using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [Header("表示状態を切り替えるオブジェクト")]
    [SerializeField] ChangeActiveObject[] _changeObjects;
    bool _startMotion = false;

    public void Trigger()
    {
        //_player_animator.SetTrigger(_deadTriggerName);
        Debug.Log("うああぁぁぁっっっ！！！(断末魔)");//モーションが入るまでは代わりにデバッグログでサーフ君の断末魔でも書いておきます
        _startMotion = true;
    }

    void Update()
    {
        UpdateChangeActive();
    }

    void UpdateChangeActive()
    {
        if (!_startMotion) return;

        for (int i = 0; i < _changeObjects.Length; i++)
        {
            _changeObjects[i].UpdateActive();
        }
    }
}
