using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプ力を返す
public class JumpPower : MonoBehaviour
{
    [Header("最大になるまでの時間")]
    [SerializeField] float _maxTime;//最大になるまでの時間(秒)
    [Header("ジャンプ関係のコントローラ操作")]
    [SerializeField] ControllerOfJump _controllerOfJump;//ジャンプ関係のコントローラ操作
    [Header("最大ジャンプ力")]
    [SerializeField] float _powerMax;
    [Header("最小ジャンプ力")]
    [SerializeField] float _powerMin;
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeJumpable _judgeJumpable;
    float _currentPowerRatio;//現在のジャンプ力(最大倍率に対しての割合)
    const float _maxPowerRatio = 1;
    const float _minPowerRatio = 0;
    float _powerRatioLastJump;//最後にジャンプした時のジャンプ力(最大倍率に対しての割合)

    public float Power//ジャンプ力
    {
        get
        {
            float gap=_powerMax - _powerMin;//最大ジャンプ力と最小ジャンプ力の差
            return _powerMin+gap*_currentPowerRatio;
        }
    }

    public float Ratio { get { return _currentPowerRatio; } }//ジャンプ力の割合(最小なら0、最大なら1)

    public float PowerLastJump//最後にジャンプした時のジャンプ力
    {
        get
        {
            float gap = _powerMax - _powerMin;//最大ジャンプ力と最小ジャンプ力の差
            return _powerMin + gap * _powerRatioLastJump;
        }
    }

    public float RatioLastJump { get { return _powerRatioLastJump; } }//最後にジャンプした時のジャンプ力の割合(最小なら0、最大なら1)

    public bool ChargeNow { get { return _judgeJumpable.Jumpable && _controllerOfJump.Pushing; } }//ジャンプ力チャージ条件、ジャンプできる時かつコントローラのジャンプボタンを押し続けている時

    //ジャンプ力のリセット、ジャンプが出来なくなった直後にする
    //
    public void ResetJumpPower()
    {
        _currentPowerRatio = _minPowerRatio;
    }

    public void MemorizeJumpPowerLastJump()//最後に飛んだ時のジャンプ力を記録
    {
        _powerRatioLastJump = _currentPowerRatio;
    }

    void Start()
    {
        ResetJumpPower();
        MemorizeJumpPowerLastJump();
        _judgeJumpable.ToNotJumpable += ResetJumpPower;
    }

    void Update()
    {
        Charge();
    }

    void Charge()//ジャンプ力のチャージ
    {
        if (ChargeNow)
        {
            //ジャンプ力を増加させる
            float chargeAmount=Time.deltaTime/_maxTime;//増加量
            _currentPowerRatio += chargeAmount;
            //限界突破しないようにする
            _currentPowerRatio = Mathf.Clamp(_currentPowerRatio, _minPowerRatio, _maxPowerRatio);
        }    
    }
}
