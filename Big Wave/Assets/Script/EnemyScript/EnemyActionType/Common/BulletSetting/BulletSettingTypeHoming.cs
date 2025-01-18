using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ホーミング弾の設定
[System.Serializable]
public class BulletSettingTypeHoming
{
    [Header("▼弾")]
    [Header("注:弾には必ずHomingBulletをつけたオブジェクトを入れること")]
    [SerializeField] GameObject bulletPrefab;//撃ちだす弾
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] Transform shotPos;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    bool shoted;//弾を撃ったか

    //以下はHomingBullet固有のステータス
    [Header("発射されて何秒後からホーミングし始めるか")]
    [SerializeField] float startHomingTime;//発射されて何秒後からホーミングし始めるか
    [Header("何秒間ホーミングするか")]
    [SerializeField] float homingTime;//何秒間ホーミングするか
    [Header("標的に向く速度")]
    [Tooltip("1秒間にhomingSpeed度の速度で向きます")]
    [SerializeField] float homingSpeed;//標的に向く速度
    [Header("弾の移動速度")]
    [SerializeField] float speed;//弾の移動速度
    

    public GameObject BulletPrefab { get { return bulletPrefab; } }//撃ちだす弾
    public Transform ShotPos { get { return shotPos; } }//弾を撃ちだす位置
    public float DelayTime { get { return delayTime; } }//行動開始から撃つまでの遅延時間
    public bool Shoted { get { return shoted; } set { shoted = value; } }//弾を撃ったか

    //以下はHomingBullet固有のステータス
    public float StartHomingTime { get { return startHomingTime; } }//発射されて何秒後からホーミングし始めるか
    public float HomingTime { get { return homingTime; } }//何秒間ホーミングするか
    public float HomingSpeed { get { return homingSpeed; } }//標的に向く速度
    public float Speed { get { return speed; } }//弾の移動速度
}
