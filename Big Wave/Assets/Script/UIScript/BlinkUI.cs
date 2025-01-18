using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkUI : MonoBehaviour
{
    private TMP_Text T_Color;
    [SerializeField] float cycle = 1f; // 点滅の間隔
    [SerializeField] JumpUI jump; // 外部から設定されるJumpUIクラス

    private float time;

    private void Start()
    {
        // TMP_Text コンポーネントを取得
        T_Color = this.GetComponent<TMP_Text>();
        T_Color.enabled = true;
    }

    // 毎フレーム実行
    void Update()
    {
        Blink_UI();
    }

    // 点滅ロジック
    void Blink_UI()
    {
        if (jump != null && jump.reached)
        {
            // 点滅を停止し、常に表示状態にする
            T_Color.enabled = true;
            return;
        }

        // 時間を加算
        time += Time.deltaTime;

        // cycleごとに点滅を切り替え
        if (time > cycle)
        {
            time = 0f; // 時間をリセット
            T_Color.enabled = !T_Color.enabled; // 表示/非表示を切り替え
        }
    }
}
