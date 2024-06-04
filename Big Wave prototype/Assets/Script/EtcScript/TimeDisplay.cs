using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
   //☆福島君が書いた
    public TMP_Text Time_UI;//表示させるテキスト
    public static float seconds;//秒
    public static int minute;//分
    private float oldSeconds;//過去の秒。secondsと比較する
    public static  bool sceneSwitch;//メインのシーンから始まっている事を検知
   

    void Start()
    {
        sceneSwitch = true;
        minute = 2;
        seconds = 0f;
        oldSeconds = 0f;
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <0f)//秒が0を下回ったら分を減らして59秒にする
        {
            minute--;
            seconds += 60;
        }
        if (seconds != oldSeconds)
        {
            Time_UI.text = "TIME:" + minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
