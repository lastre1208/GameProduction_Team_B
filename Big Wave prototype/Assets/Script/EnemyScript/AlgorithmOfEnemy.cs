using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//(現在の)行動パターンを設定して、その行動パターンの処理をする
public class AlgorithmOfEnemy : MonoBehaviour
{
    [Header("最初の行動パターン")]
    [SerializeField] ActionPattern firstActionPattern;//最初の行動パターン
    [Header("行動選択")]
    [SerializeField] SelectActionOfEnemyTypeBase selectAction;//行動選択
    private float currentActionTime = 0;//現在の行動時間
    private float actionTime;//行動時間、現在の行動時間(currentActionTime)がこれ以上になったら行動を変更する
    private ActionPattern currentActionPattern;//現在の行動パターン
    bool _switch = false;//これがfalseになっている時は行動しない、trueの時は行動する
    bool _setFirstAction = false;//最初の行動をセットしたか、セットするまでは行動のアルゴリズムを動かさない

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    void Update()
    {
        SetFirstAction();
        Algorithm();
    }

    void SetFirstAction()//最初の行動の設定
    {
        if (_setFirstAction||!_switch) return;//最初の行動をセット済みまたはスイッチがOFFの時はしない

        ChangeAction(firstActionPattern);//最初の行動を設定
        _setFirstAction=true;
    }

    void Algorithm()//行動アルゴリズムの処理
    {
        if (!_setFirstAction || !_switch) return;//最初の行動が未セットセットまたはスイッチがOFFの時は動かさない

        currentActionTime += Time.deltaTime;

        bool actionNow = (currentActionTime < actionTime);//現在行動しているか

        if (actionNow)//行動中
        {
            //現在の行動の毎フレームの処理
            for (int i = 0; i < currentActionPattern.Action.Length; i++)
            {
                currentActionPattern.Action[i].OnUpdate();
            }
        }
        else//行動終了
        {
            ChangeAction(selectAction.SelectAction());//行動変更
        }
    }

    public void ChangeAction(ActionPattern nextActionPattern)//行動変更
    {
        //現在の行動の行動終了時の処理

        if(currentActionPattern!=null)//最初の行動の設定以降の時
        {
            //前の行動の行動終了時の処理
            for (int i = 0; i < currentActionPattern.Action.Length; i++)
            {
                currentActionPattern.Action[i].OnExit(nextActionPattern.Action);
            }

            //次の行動の行動開始時の処理
            for (int i = 0; i < nextActionPattern.Action.Length; i++)
            {
                nextActionPattern.Action[i].OnEnter(currentActionPattern.Action);
            }
        }
        else//最初の行動を設定する時
        {
            //次の行動の行動開始時の処理
            for (int i = 0; i < nextActionPattern.Action.Length; i++)
            {
                nextActionPattern.Action[i].OnEnter(null);
            }
        }

        //現在の行動を次の行動に変更
        currentActionPattern = nextActionPattern;
        //現在の行動時間をリセット
        currentActionTime = 0;
        //行動時間を更新
        actionTime = currentActionPattern.ActionTime;
    }
}
