using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリティカルの状況によって、ガイドの矢印のアニメーションを動かす
public class GuideAnim_Critical : MonoBehaviour
{
    [Header("失敗時のトリガー名")]
    [SerializeField] string _failTriggerName;

    [Header("ガイドの矢印ごとのアニメーター")]
    [Header("東")]
    [SerializeField] Animator _eastGuide;
    [Header("西")]
    [SerializeField] Animator _westGuide;
    [Header("南")]
    [SerializeField] Animator _southGuide;
    [Header("北")]
    [SerializeField] Animator _northGuide;

    [Header("必要なコンポーネント")]
    [SerializeField] Trick _trick;
    [SerializeField] Critical _critical;

    const int currentCriticalButtonIndex = 0;//現在のクリティカルのボタンが見れる要素番号

    void Start()
    {
        _trick.TrickAction += OrderAnim;
    }

    void OrderAnim()
    {
        //失敗時に指されている方向の矢印が失敗のアニメーションを流すようにする
        if(!_critical.CriticalNow)
        {
            TrickButton currentButton = _critical.CriticalButton[currentCriticalButtonIndex];//現在の(クリティカルの)ボタン
            Animator guideAnimator = GuideAnimator(currentButton);

            guideAnimator.SetTrigger(_failTriggerName);
        }
    }

    //入れたトリックのボタンの種類に対応したアニメーションを返す
    Animator GuideAnimator(TrickButton trickButton)
    {
        switch(trickButton)
        {
            case TrickButton.east: return _eastGuide;
            case TrickButton.west: return _westGuide;
            case TrickButton.south: return _southGuide;
            case TrickButton.north: return _northGuide;
        }

        //例外
        return null;
    }
}
