using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプ力を返す
public class JumpPower : MonoBehaviour
{
    [Header("ジャンプパワーの周期とボタンを押した直後の初期値")]
    [SerializeField] RepetitiveValue_Sin _repetitiveValue;
    [Header("ジャンプ関係のコントローラ操作")]
    [SerializeField] ControllerOfJump _controllerOfJump;//ジャンプ関係のコントローラ操作
    [Header("最大ジャンプ力")]
    [SerializeField] float _powerMax;
    [Header("最小ジャンプ力")]
    [SerializeField] float _powerMin;
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeJumpable _judgeJumpable;

    public float Power//ジャンプ力
    {
        get
        {
            float gap=_powerMax - _powerMin;//最大ジャンプ力と最小ジャンプ力の差

            return _powerMin+gap*_repetitiveValue.Value;
        }
    }

    public float Ratio//ジャンプ力の割合(最小なら0、最大なら1)
    {
        get { return _repetitiveValue.Value; }
    }

    public void ResetJumpPower()//ジャンプ力のリセット、ジャンプ(操作)直後もしくはジャンプが出来なくなった直後にする
    {
        _repetitiveValue.ResetCycle();
    }

    void Start()
    {
        _repetitiveValue.ResetCycle();
    }

    void Update()
    {
        Charge();
    }

    void Charge()
    {
        //ジャンプ力チャージ条件はジャンプできる時かつコントローラのジャンプボタンを押し続けている時
        bool chargeNow = _judgeJumpable.Jumpable && _controllerOfJump.Pushing;

        if (chargeNow)
        {
            _repetitiveValue.UpdateValue();
        }    
    }
}
