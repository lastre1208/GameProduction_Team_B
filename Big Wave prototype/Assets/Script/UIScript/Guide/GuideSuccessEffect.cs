using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//トリック成功時のガイドの矢印のエフェクト
public class GuideSuccessEffect : MonoBehaviour
{
    [Header("生成するエフェクト")]
    [SerializeField] GameObject _effect;

    [Header("ガイドの矢印の位置")]
    [SerializeField] GetTrickButton<Transform> _guideAnim;

    [Header("必要なコンポーネント")]
    [SerializeField] Trick _trick;
    [SerializeField] PushedButton_CurrentTrickPattern _pushedButton;
    [SerializeField] Critical _critical;

    void Awake()
    {
        _trick.TrickAction += GenerateEffect;
    }

    //クリティカル時のみ、押した方向のガイド付近にエフェクトを生成
    void GenerateEffect()
    {
        if (!_critical.CriticalNow) return;

        TrickButton pushedButton = _pushedButton.PushedButton;//押したボタンの色
        Transform geneTrans = _guideAnim.Get(pushedButton);//生成位置情報(これを親オブジェクトとして生成)

        //生成
        Instantiate(_effect, geneTrans.position, geneTrans.rotation, geneTrans);
    }
}
