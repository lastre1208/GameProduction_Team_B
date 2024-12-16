using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//作成者:杉山
//選んだシーンに移行する
[System.Serializable]
class SelectScene
{
    [SerializeField] Scene _scene;
    [SerializeField] int _gameSceneStageID;
    [SerializeField] SceneController _sceneController;

    //デフォルトコンストラクタ
    public SelectScene() { }

    //コンストラクタ
    public SelectScene(Scene scene)
    {
        _scene = scene;
    }

    public void ChangeScene()
    {
        switch(_scene)
        {
            case Scene.gameover: _sceneController.GameOverScene(); break;//ゲームオーバーシーンに移行
            case Scene.clear: _sceneController.ClearScene(); break;//クリアシーンに移行
            case Scene.menu: _sceneController.MenuScene(); break;//メニューシーンに移行
            case Scene.game: _sceneController.GameScene(_gameSceneStageID); break;//ゲームシーンに移行
            case Scene.end: _sceneController.EndGame(); break;//ゲーム終了
        }
    }
}
