using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//形態ごとにランダムで行動パターン(コンボみたいな感じで一連の動作を設定できる)を選ぶ(形態ごとに最初にする行動も設定可能)
public class SelectActionOfEnemyTypeFormCombo : SelectActionOfEnemyTypeBase
{
    //形態ごとの行動パターン
    //現在の形態を返すコンポーネント
    //前の形態番号

    public override ActionPattern SelectAction()//次にやる行動を返す
    {
        return null;
    }
}
