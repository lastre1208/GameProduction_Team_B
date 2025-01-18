using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//作成者:杉山
//トリックポイントが満タンになった時に出すエフェクト
public class ChargeTrickEffect_TrickPointFull : MonoBehaviour
{
    [Header("トリックポイント")]
    [SerializeField] TrickPoint _trickPoint;
    [Header("全てのトリックゲージが満タン時に流す効果音")]
    [SerializeField] AudioClip _fullSE;
    [SerializeField] AudioSource _audioSource;

    [Header("全てのトリックゲージが満タン時に表示させるテキスト")]
    [SerializeField] TMP_Text _fulltext;
    [SerializeField]Transform _canvas;
    
    [Header("各ゲージが満タン時に出すエフェクト")]
    [Tooltip("Element0が1個目のトリックゲージが満タン時、Element1が2個目のトリックゲージが満タン時に出すエフェクト")]
    [SerializeField] ParticleSystem[] _chargeEffect;

    void Start()
    {
        _trickPoint.FullEvent += Trigger;
    }

    public void Trigger(int maxCount)
    {
        if(maxCount<=_chargeEffect.Length)
        {
            //トリックゲージが一つ満タンになるごとにそれに対応したエフェクトを出す
            ParticleSystem effect = _chargeEffect[maxCount - 1];
            effect.gameObject.SetActive(true);
            effect.Play();
        }

        //全てのトリックゲージが満タン時に効果音を流す
        if(_trickPoint.TrickGaugeNum==maxCount)
        {
            _audioSource.PlayOneShot(_fullSE);
            Instantiate(_fulltext,_canvas.transform.position,_canvas.rotation,_canvas.transform);
        }
    }
}
