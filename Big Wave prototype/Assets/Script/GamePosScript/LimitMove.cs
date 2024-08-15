using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class LimitMoveObject
{
    [Header("移動可能範囲")]
    [SerializeField] float range = 7f;//移動可能範囲
    [Header("移動制限させるオブジェクト")]
    [SerializeField] GameObject limitObjects;

    //動きの制限
    //移動可能範囲外に出ないようにする
    internal void Limit()
    {
        Vector3 currentPos = limitObjects.transform.localPosition;
        currentPos.x = Mathf.Clamp(currentPos.x, -range, range);//x軸で移動可能範囲を制限する
        limitObjects.transform.localPosition = currentPos;
    }
}

public class LimitMove : MonoBehaviour
{
    [Header("移動制限させたいオブジェクトと制限範囲")]
    [SerializeField] LimitMoveObject[] limitMoveObjects;//移動制限させたいオブジェクトと制限範囲
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i< limitMoveObjects.Length;i++)
        {
            limitMoveObjects[i].Limit();
        }
    }
}
