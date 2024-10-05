using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class LimitVector
{
    [Header("移動制限するか")]
    [SerializeField] bool limit=false;//移動制限するか
    [Header("移動可能範囲")]
    [SerializeField] float range;//移動可能範囲

    public float Limit(float position)
    {
        if (!limit) return position;

        //移動制限の処理(しないならこれの前の文で処理は終わり)
        position = Mathf.Clamp(position, -range, range);
        return position;
    }
}

[System.Serializable]
class LimitMoveObject
{
    [Header("移動可能のパラメータ")]
    [SerializeField] LimitVector x;//x軸
    [SerializeField] LimitVector y;//y軸
    [SerializeField] LimitVector z;//z軸
    [Header("移動制限させるオブジェクト")]
    [SerializeField] GameObject limitObjects;

    //動きの制限
    //移動可能範囲外に出ないようにする
    public void Limit()
    {
        Vector3 currentPos = limitObjects.transform.localPosition;
        currentPos.x = x.Limit(currentPos.x);//x軸の制限
        currentPos.y = y.Limit(currentPos.y);//y軸の制限
        currentPos.z = z.Limit(currentPos.z);//z軸の制限
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
