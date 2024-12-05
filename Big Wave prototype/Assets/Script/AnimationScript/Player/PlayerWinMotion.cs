using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

//作成者:杉山、桑原が一部修正
//勝利時のプレイヤーのモーション
public class PlayerWinMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [Header("何秒後に勝利モーションを再生するか")]
    [SerializeField] float _startMotionTime;

    float _currentStartMotionTime = 0;
    bool _startMotion = false;

    public void Trigger()
    {
        _startMotion = true;
    }

    void Update()
    {
        UpdatePlayAnimation();
    }

    void UpdatePlayAnimation()
    {
        if (!_startMotion) return;

        _currentStartMotionTime += Time.deltaTime;

        if (_currentStartMotionTime > _startMotionTime )
        {
            _player_animator.SetTrigger(_deadTriggerName);
            _startMotion = false;
        }
    }
}
