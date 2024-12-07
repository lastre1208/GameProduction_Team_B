using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseResumeEvent : MonoBehaviour
{
    [Header("ポーズ状況を判断するコンポ―ネント")]
    [SerializeField] JudgePauseNow _judgePauseNow;
    [Header("ゲームの開始処理をするコンポーネント")]
    [SerializeField] GameStartSequence _gameStartSequence;
    [Header("ポーズメニューを開いた時の最初に選択されるボタン")]
    [SerializeField] Button _firstSelectbutton;
    [Header("ポーズメニュー")]
    [SerializeField] GameObject _pauseMenu;
    [Header("ゲーム中UI")]
    [SerializeField] GameObject _duringGameUI;
    [Header("再開時の効果音")]
    [SerializeField] AudioClip _resumeSE;
    [Header("ポーズ時の効果音")]
    [SerializeField] AudioClip _pauseSE;
    [Header("必要なコンポーネント")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] ControlTime _controlTime;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] CloseMenuEasily _closeMenuEasily;
    string _actionMapName_Original;//元の操作名
    const string _actionMapName_Pause = "UI";//ポーズ用の操作名

    void Start()
    {
        _judgePauseNow.SwitchPauseAction += Event;
    }

    void Event(bool pause)
    {
        if(pause)//ポーズ時のみ
        {
            _eventSystem.SetSelectedGameObject(_firstSelectbutton.gameObject);//ポーズメニューの選択ボタンを設定
            _closeMenuEasily.OpenNewMenu(_firstSelectbutton); //メニューを閉じるコンポーネントにその選択ボタンを設定
        }

        //ゲーム中UIの表示・非表示切り替え(スタートのムービーが終了していなかったら表示しない)
        _duringGameUI.SetActive(_gameStartSequence.FinishedStartMovie ? !pause : false);
        _pauseMenu.SetActive(pause);//ポーズメニューの表示・非表示切り替え

        //操作の変更(ポーズ状態に切り替えるなら、元の操作名を覚えておく、ポーズ状態解除時は元の操作に戻す)
        if(pause)
        {
            _actionMapName_Original = _playerInput.currentActionMap.name;
            _playerInput.SwitchCurrentActionMap(_actionMapName_Pause);
        }
        else
        {
            _playerInput.SwitchCurrentActionMap(_actionMapName_Original);
        }

        _controlTime.ChangeTimeScale(pause);//時間のスピードの変更
        _audioSource.PlayOneShot(pause ? _pauseSE : _resumeSE);//効果音を流す
    }


}
