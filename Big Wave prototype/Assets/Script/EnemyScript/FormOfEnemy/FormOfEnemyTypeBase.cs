using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在が第何形態かを返す
public abstract class FormOfEnemyTypeBase : MonoBehaviour
{
    public abstract int CurrentForm();//現在第何形態かを返す、ただし第一形態なら0、第二形態なら1...第n形態ならn-1を返すようにする
}
