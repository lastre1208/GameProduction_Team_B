using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者:杉山
//動きを滑らかにする(Vector3を返却)
[System.Serializable]
public class SmoothMovement
{
    [Header("バッファー数")]
    [Tooltip("多すぎると遅延が発生しやすくなります")]
    [SerializeField] int _bufferNum;//"バッファー数、多すぎると遅延が発生しやすくなります
    private Queue<Vector3> _posBuffer; // バッファをQueueで管理
    Vector3 sum = new Vector3();//合計

    public SmoothMovement(int bufferNum)//コンストラクタ
    {
        _bufferNum = bufferNum;

        SecureBuffer();
    }

    //バッファー確保(コンストラクタを用いずに使う場合は最初にこれを呼ぶ)
    public void SecureBuffer()
    {
        _posBuffer = new Queue<Vector3>(_bufferNum);
    }

    public Vector3 Smooth(Vector3 nowPos)
    {
        // バッファに現在の値を追加&合計に現在の値を加算
        _posBuffer.Enqueue(nowPos);
        sum += nowPos;

        // バッファのサイズが指定したバッファー数を超えた場合、古い値を削除&合計からその値分引く
        if (_posBuffer.Count > _bufferNum)
        {
            sum-=_posBuffer.Dequeue();
        }

        //バッファーに格納されている全ての値の平均をとる
        //現在バッファーに格納されている値の個数が、バッファー数に満たない場合は現在格納されている値の個数から平均をとる
        Vector3 ret = sum / _posBuffer.Count;

        //得られた値を返す
        return ret;
    }
}
