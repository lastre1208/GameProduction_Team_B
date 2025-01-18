using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//画面遷移直後に少し待ってからフェードインする
public class StartFadeIn : MonoBehaviour
{
    [SerializeField] FadeIn _fadeIn;
    [Header("フェードインを待つ時間")]
    [SerializeField] float _fadeWaitTime;
    [Header("フェードインに使う画像")]
    [SerializeField] Image _fadeInImage;
    private void Start()
    {
        //フェードインに使う画像を表示
        _fadeInImage.enabled = true;

        StartCoroutine(WaitFadeIn());
    }

    IEnumerator WaitFadeIn()
    {
        //数秒待ってからフェードインを開始する
        yield return new WaitForSeconds(_fadeWaitTime);

        _fadeIn.StartTrigger();
    }
}
