using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//形態ごとにランダムで行動パターン(コンボみたいな感じで一連の動作を設定できる)を選ぶ(形態ごとに最初にする行動も設定可能)
public class SelectActionOfEnemyTypeFormSequence : SelectActionOfEnemyTypeBase
{
    [Header("形態ごとの行動パターン")]
    [SerializeField] SequenceOfActionPatternPerForm[] _forms;//形態ごとの行動パターン
    [Header("▼現在の形態を返すコンポーネント")]
    [SerializeField] FormOfEnemyTypeBase _formOfEnemy;//現在の形態を返すコンポーネント
    bool _actedFirst = false;//最初の行動をしたか
    int _beforeFormNum;//前(に呼ばれた時)の形態番号
    const int _defaultActionIndex = 0;//行動内容の最初の行動番号(後でコメント書き直す)
    int _actionIndex = _defaultActionIndex;//行動内容の行動番号(後でコメント書き直す)
    SequenceOfActionPattern _currentAction=null;//現在の行動内容

    void Start()
    {
        _beforeFormNum = _formOfEnemy.DefaultForm();//前(に呼ばれた時)の形態番号の初期値を最初の形態番号に設定

        //全ての形態の行動確率の合計を算出
        for (int i = 0; i < _forms.Length; i++)
        {
            _forms[i].CalcSum();
        }
    }

    public override ActionPattern SelectAction()//次にやる行動を返す
    {
        //〇形態を確認
        int currentFormNum=_formOfEnemy.CurrentForm();//現在の形態番号

        //形態が変わっていたら
        //最初の行動をした判定をリセット(してない状態に戻す)、現在の行動内容を空にする、行動番号をリセット
        if(currentFormNum!=_beforeFormNum)
        {
            _actedFirst = false;
            _actionIndex = _defaultActionIndex;
            _currentAction = null;
        }

        //前に呼ばれた時の形態番号に現在の形態番号を記録
        _beforeFormNum=currentFormNum;


        //〇最初の行動を確認

        //まだ最初の行動を行っていなかったら
        if(!_actedFirst)
        {
            _actedFirst=true;

            //最初の行動をする設定になっていたら現在の行動内容を最初の行動内容に設定
            if(_forms[currentFormNum].ActFirst)
            {
                _currentAction = _forms[currentFormNum].FirstAction;
            }
        }


        //〇一連の行動が続いているかを確認

        //現在の行動内容が空になっていたら
        //or 現在の行動番号が範囲外のものだったら...
        //現在の行動を抽選、行動番号をリセット
        if (_currentAction==null || _currentAction.ActionNum <= _actionIndex)
        {
            _currentAction = _forms[currentFormNum].SelectAfterAction();
            _actionIndex = _defaultActionIndex;
        }

        //現在の行動番号の行動を返す
        int currentActionIndex = _actionIndex;//現在の行動番号
        _actionIndex++;//行動内容の次の行動に設定
        return _currentAction[currentActionIndex];
    }
}
