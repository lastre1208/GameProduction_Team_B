using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに当たった時に弾を消す
public class DestroyBullet : MonoBehaviour
{
    [Header("プレイヤーに当たった時に弾を消すか")]
    [SerializeField] bool ifHitDestroy = true;//プレイヤーに当たった時に弾を消すか
    [Header("壊すオブジェクト")]
    [SerializeField] GameObject destroyObject;

    public void Destroy()
    {
        //プレイヤーが当たれば弾を消す
        if (ifHitDestroy && destroyObject != null)
        {
            Destroy(destroyObject);
        }
    }
}
