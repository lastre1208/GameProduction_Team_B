using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickTheCharger : MonoBehaviour
{
    [Header("チャージ倍率(トリックゲージの個数分配列を用意してください)")]
    [SerializeField] float[] chargeRate;//チャージ倍率
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //満タンのゲージの数に対応したチャージ倍率を返す
    public float ChargeRate()
    {
        int maxCount = player.MaxCount;
        maxCount = Mathf.Clamp(maxCount, 0, player.TrickGaugeNum - 1);
        return chargeRate[maxCount];
    }
}
