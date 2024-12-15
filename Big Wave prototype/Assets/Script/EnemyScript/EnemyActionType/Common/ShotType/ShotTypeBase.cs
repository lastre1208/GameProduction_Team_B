using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//弾を撃つ(抽象クラス)
public abstract class ShotTypeBase : MonoBehaviour
{
    public abstract void InitShotTiming();//撃つタイミングの初期化

    public abstract void UpdateShotTiming();//撃つタイミングの更新
}
