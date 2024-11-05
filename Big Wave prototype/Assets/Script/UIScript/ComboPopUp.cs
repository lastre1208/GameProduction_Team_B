using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ComboPopUp : MonoBehaviour
{
    [SerializeField] TMP_Text text_countPrefab;
    [SerializeField] Transform chasePlayer;
    //[SerializeField] Canvas canvas;  
    private TMP_Text text_countInstance;
    private int comboCount;
   
   
    public void PopUp()
    {

        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
        comboCount++;
        text_countPrefab.text = (comboCount+("COMBO!!"));
        // Canvas の子要素としてインスタンスを生成
        text_countInstance = Instantiate(text_countPrefab,chasePlayer.transform.position, chasePlayer.transform.rotation, chasePlayer.transform);
        //text_countInstance = Instantiate(text_countPrefab, canvas.transform);
        // 表示内容を設定
        // インスタンスの位置をターゲットのスクリーン座標に合わせる
        //RectTransform rectTransformCount = text_countInstance.GetComponent<RectTransform>();
        // スクリーン座標を UI のローカル座標に変換
        //rectTransformCount.position = screenPosition;
    }
    public void ResetCount()
    {
        comboCount = 0;
    }
}
