using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:福島
//バリアの破壊エフェクトを置く処理をDeleteObjectに入れていたのでこっちに移動しておきましたby杉山
public class DestroyBarrierEffect : MonoBehaviour
{
    [SerializeField] GameObject _destroyBarrierEffect;

    public void Generate()
    {
        if (_destroyBarrierEffect != null)
        {
            Instantiate(_destroyBarrierEffect, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}
