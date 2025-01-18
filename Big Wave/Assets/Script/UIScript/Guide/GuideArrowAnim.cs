using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ガイドの矢印のアニメーションの動き
public class GuideArrowAnim : MonoBehaviour
{
    [Header("アニメーションの成功判定のbool名")]
    [SerializeField] string _successBoolName;
    [Header("アニメーションの失敗のtrigger名")]
    [SerializeField] string _failTriggerName;

    [Header("ガイドの矢印")]
    [SerializeField] GetTrickButton<Animator> _guideAnim;

    [Header("必要なコンポーネント")]
    [SerializeField] Trick _trick;
    [SerializeField] Critical _critical;

    const int currentCriticalButtonIndex = 0;//現在のクリティカルのボタンが見れる要素番号

    void Awake()
    {
        _trick.TrickAction += RunAnim;
    }

    void RunAnim()
    {
        bool criticalNow = _critical.CriticalNow;//クリティカルだったか
        TrickButton currentButton = _critical.CriticalButton[currentCriticalButtonIndex];//現在の(クリティカルの)ボタン
        Animator guideAnimator = _guideAnim.Get(currentButton);

        //クリティカル失敗の時のみtriggerを出す
        guideAnimator.SetBool(_successBoolName,criticalNow);
        if (!criticalNow) guideAnimator.SetTrigger(_failTriggerName);
    }
}
