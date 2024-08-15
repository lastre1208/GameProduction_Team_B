using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTrickCombo : MonoBehaviour
{
    [Header("何秒経ったらコンボ回数をリセットするか")]
    [SerializeField] float ResetTime;//何秒経ったらコンボ回数をリセットするか
    private int comboCount = 0;//コンボ回数

    public int ComboCount
    {
        get { return comboCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
