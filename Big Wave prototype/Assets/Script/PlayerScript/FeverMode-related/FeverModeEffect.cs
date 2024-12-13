using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//フィーバーモードのエフェクト
public class FeverModeEffect : MonoBehaviour
{
    [Header("フィーバーモード遷移時の効果音")]
    [SerializeField] AudioClip _feverSE;
    [SerializeField] AudioSource _audioSource;
    [Header("フィーバーモードのエフェクト")]
    [SerializeField] ParticleSystem _feverEffect;
    [Header("フィーバー状態中ずっと表示するエフェクト")]
    [SerializeField] GameObject[] _feverNowEffect;//フィーバー状態中ずっと表示するエフェクト
    [Header("フィーバーモードのコンポーネント")]
    [SerializeField] FeverMode _feverMode;


    void Start()
    {
        _feverMode.TransitToFeverAction += Trigger;

        //フィーバー状態中ずっと表示するエフェクトは初期は非表示にする
        for (int i = 0; i < _feverNowEffect.Length; i++)
        {
            _feverNowEffect[i].SetActive(false);
        }
    }

    void Update()
    {
        ChangeActiveEffect();
    }

    void ChangeActiveEffect()//フィーバー状態中はエフェクトを表示、そうでない場合は非表示にする
    {
        for (int i = 0; i < _feverNowEffect.Length; i++)
        {
            _feverNowEffect[i].SetActive(_feverMode.FeverNow);
        }
    }

    public void Trigger()
    {
        _audioSource.PlayOneShot(_feverSE);//効果音を鳴らす
        //エフェクトを出す
        _feverEffect.gameObject.SetActive(true);
        _feverEffect.Play();
    }
}
