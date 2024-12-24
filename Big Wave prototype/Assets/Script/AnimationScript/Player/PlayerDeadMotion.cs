using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [Header("表示状態を切り替えるオブジェクト")]
    [SerializeField] ChangeActiveOfObject _changeObjects;
    bool _startMotion = false;

    public void Trigger()
    {
        _player_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
    }

    void Update()
    {
        UpdateChangeActive();
    }

    void UpdateChangeActive()
    {
        if (!_startMotion) return;

        _changeObjects.UpdateActive();
    }
}
