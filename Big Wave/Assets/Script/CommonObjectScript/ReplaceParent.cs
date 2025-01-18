using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//スタートしてから少し時間たったら親オブジェクトを変える
//ロープのバグ修正に使ってます
public class ReplaceParent : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] Transform parentObject;
    float currentTime = 0;
    bool done=false;

    void Update()
    {
       UpdateTime();
    }

    void UpdateTime()
    {
        currentTime += Time.deltaTime;

        if(currentTime>=time&&!done) Replace();
    }

    void Replace()
    {
        transform.parent = parentObject;
        done = true;
    }
}
