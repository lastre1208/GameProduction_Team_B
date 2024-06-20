using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    //☆福島君が書いた
    [Header("▼表示させるテキスト")]
    [SerializeField] TMP_Text Time_UI;//表示させるテキスト
    //public static float seconds;//秒
    //public static int minute;//分
    [Header("▼制限時間（分）")]
    [SerializeField] int initialMinutes = 2;
    private static int minutes;
    [Header("▼制限時間（秒）")]
    [SerializeField] float initialSeconds = 0f;
    private static float seconds;
    
    private float oldSeconds;//過去の秒。secondsと比較する
    //public static  bool sceneSwitch;//メインのシーンから始まっている事を検知
    private static bool sceneSwitch;//メインのシーンから始まっている事を検知

    public static float Seconds
    {
        get { return seconds; }

        private set { seconds = value; }            
    }

    public static int Minutes
    {
        get { return minutes; }

        private set { minutes = value; }
    }

    public static bool SceneSwitch
    {
        get { return sceneSwitch; }

        private set { sceneSwitch = value; }
    }
   

    void Start()
    {
        sceneSwitch = true;
        minutes = initialMinutes;
        seconds = initialSeconds;
        oldSeconds = 0f;
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <0f)//秒が0を下回ったら分を減らして59秒にする
        {
            minutes--;
            seconds += 60;
        }
        if (seconds != oldSeconds)
        {
            Time_UI.text = "TIME:" + minutes.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
