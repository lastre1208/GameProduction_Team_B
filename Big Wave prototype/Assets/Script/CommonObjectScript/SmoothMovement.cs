using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//動きを滑らかにする(Vector3を返却)
[System.Serializable]
public class SmoothMovement
{
    [Header("バッファー数")]
    [Tooltip("多すぎると遅延が発生しやすくなります")]
    [SerializeField] int _bufferNum;//"バッファー数、多すぎると遅延が発生しやすくなります
    private Vector3[] _posBuffers;
    private int _currentBufferNum=0;//現在バッファーに格納されている値の個数、初期は何も入ってないので0
    private int _nextBufferIndex = 0;//次に値を入れるバッファーの要素番号

    public SmoothMovement(int bufferNum)//コンストラクタ
    {
        _bufferNum = bufferNum;
        _currentBufferNum = 0;
        _nextBufferIndex = 0;

        SecureBuffer();
    }

    //バッファー確保(コンストラクタを用いずに使う場合は最初にこれを呼ぶ)
    public void SecureBuffer()
    {
        _posBuffers=new Vector3[_bufferNum];

        for(int i=0; i<_posBuffers.Length;i++)
        {
            _posBuffers[i]=new Vector3();
        }
    }

    public Vector3 Smooth(Vector3 nowPos)
    {
        //バッファーに現在の値を入れる
        _posBuffers[_nextBufferIndex]=nowPos;

        //現在バッファーに格納されている値の個数を更新
        

        //次に値を入れるバッファの要素番号を更新

        //バッファーに格納されている全ての値の平均をとる
        //現在バッファーに格納されている値の個数が、バッファー数に満たない場合は現在格納されている値の個数から平均をとる

        //得られた値を返す

        return Vector3.zero;
    }
}
