using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動内容を選んで渡す
public abstract class SelectActionOfEnemyTypeBase : MonoBehaviour
{
    public abstract ActionPattern SelectAction();//次にやる行動を返す
}
