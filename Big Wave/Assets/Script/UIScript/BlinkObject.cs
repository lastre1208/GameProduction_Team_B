using UnityEngine;
using UnityEngine.UI;

public class BlinkObject : MonoBehaviour
{
    [SerializeField] private Image targetObject; // 対象のゲームオブジェクト
    [SerializeField] private float cycleDuration = 1f; // 点滅サイクル時間
    [SerializeField] private float speed = 1f; // 点滅速度
    private float elapsedTime = 0f; // 経過時間
    private bool change=true;
    private float isVisible ; // 現在の表示状態

   

    private void Update()
    {
        BlinkObjectLogic();
    }

    private void BlinkObjectLogic()
    {
        // 経過時間を更新
        elapsedTime += speed * Time.deltaTime;
        // サイクル時間を超えた場合に切り替え
        if (elapsedTime > cycleDuration)
        {
            change = !change;
            elapsedTime = 0f; // 経過時間をリセット
            isVisible = (change ? 0 : 255);
            targetObject.color = new(targetObject.color.r, targetObject.color.g, targetObject.color.b,isVisible ); // 表示状態を適用
        }
    }
}
