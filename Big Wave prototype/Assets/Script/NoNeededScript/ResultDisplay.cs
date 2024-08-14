using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResultDisplay : MonoBehaviour
{
    //☆作成者:福島
    [SerializeField] TMP_Text ResultTime_UI;
    [SerializeField] TMP_Text ResultScore_UI;
   
    // Start is called before the first frame update
    void Start()
    {
        if (TimeDisplay.SceneSwitch != false)//クリア画面に移行した事を確認したらその時点の時間を表示する
        {
            ResultTime_UI.text = "ClearTime: " + TimeDisplay.Minutes.ToString("00") + ":" + TimeDisplay.Seconds.ToString("00");
            ResultScore_UI.text = "TotalScore: " + ManagementOfScore.TotalScore.ToString("");
        }
        else
        {
            ResultTime_UI.text = "ClearTime:00:00";
            ResultScore_UI.text = "TotalScore:0 ";
        }
    }

    // Update is called once per frame
   
}
