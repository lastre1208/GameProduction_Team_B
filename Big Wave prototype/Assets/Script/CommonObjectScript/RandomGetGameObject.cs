using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//登録したゲームオブジェクトの中からランダムにゲームオブジェクトを返す
[System.Serializable]
public class RandomGetGameObject
{
    [SerializeField] GameObject[] objects;

    //呼ばれるとランダムにゲームオブジェクトを返す
    public GameObject GetObjectRandom()
    {
        if (objects == null)
        {
            Debug.Log("何も設定されていません");
            return null;
        }

        return objects[Random.Range(0,objects.Length)];
    }
}
