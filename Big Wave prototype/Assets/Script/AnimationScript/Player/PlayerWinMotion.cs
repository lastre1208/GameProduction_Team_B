using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//勝利時のプレイヤーのモーション
public class PlayerWinMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;

    public void Trigger()
    {
        _player_animator.SetTrigger(_deadTriggerName);
    }
}
