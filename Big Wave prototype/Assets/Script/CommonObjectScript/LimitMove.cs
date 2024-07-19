using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMove : MonoBehaviour
{
    [Header("移動可能範囲")]
    [SerializeField] float range = 7f;//移動可能範囲
    [Header("移動制限させるオブジェクト")]
    [SerializeField] GameObject[] limitObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<limitObjects.Length;i++)
        {
            Limit(limitObjects[i]);
        }
    }

    //キャラの動きの制限
    //移動可能範囲外に出ないようにする
    void Limit(GameObject obj)
    {
        Vector3 currentPlayerPos = obj.transform.localPosition;
        currentPlayerPos.x = Mathf.Clamp(currentPlayerPos.x, -range, range);//x軸で移動可能範囲を制限する
        obj.transform.localPosition = currentPlayerPos;
    }
}
