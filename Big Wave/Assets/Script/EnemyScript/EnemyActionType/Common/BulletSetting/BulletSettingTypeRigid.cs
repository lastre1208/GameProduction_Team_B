using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//通常弾(Rigidbodyを使う)の設定
[System.Serializable]
public class BulletSettingTypeRigid
{
    [Header("▼弾")]
    [Header("注:弾には必ずRigidbodyをつけたオブジェクトを入れること")]
    [SerializeField] GameObject bulletPrefab;//撃ちだす弾
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] Transform shotPos;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    bool shoted;//弾を撃ったか

    //以下はRigidbody固有のステータス
    [Header("射撃の種類")]
    [SerializeField] ShotType shotType;
    [Header("▼撃つ力")]
    [SerializeField] float shotPower;//撃つ力

    public GameObject BulletPrefab { get { return bulletPrefab; } }//撃ちだす弾
    public Transform ShotPos { get { return shotPos; } }//弾を撃ちだす位置
    public float DelayTime { get { return delayTime; } }//行動開始から撃つまでの遅延時間
    public bool Shoted { get { return shoted; } set { shoted = value; } }//弾を撃ったか

    //以下はRigidbody固有のステータス
    public ShotType ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
