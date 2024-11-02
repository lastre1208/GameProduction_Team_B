using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ComboPopUp : MonoBehaviour
{
   

    [SerializeField] Canvas canvas;  
    [SerializeField] TMP_Text text_countPrefab;
    [SerializeField] TMP_Text text_comboPrefab;
    [SerializeField] Transform target;
  
    private TMP_Text text_countInstance;
    private TMP_Text text_comboInstance;
    private int comboCount;
   
   
    public void PopUp()
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
        comboCount++;
        text_countPrefab.text = (("")+comboCount);
        // Canvas の子要素としてインスタンスを生成
        text_countInstance = Instantiate(text_countPrefab, canvas.transform);
        text_comboInstance = Instantiate(text_comboPrefab, canvas.transform);
       
        // 表示内容を設定
       

        // インスタンスの位置をターゲットのスクリーン座標に合わせる
      
        

        RectTransform rectTransformCount = text_countInstance.GetComponent<RectTransform>();
        RectTransform rectTransformCombo = text_comboInstance.GetComponent<RectTransform>();

        // スクリーン座標を UI のローカル座標に変換
        rectTransformCount.position = screenPosition;
        rectTransformCombo.position = screenPosition;


    }
    public void ResetCount()
    {
        comboCount = 0;
    }
}
