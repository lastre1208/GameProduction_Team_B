using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public partial class PlayGuideInputHandler
{
    public void EnableSpecificUIActions()//一部入力を有効化
    {
        leftRightAction.Enable();
        cancelAction.Enable();
    }

    public void DisableSpecificUIActions()//一部入力を無効化
    {
        leftRightAction.Disable();
        cancelAction.Disable();
    }

    public void EnableAllUIActions()//全ての入力を有効化
    {
        if (actionHandler == null) return;

        actionHandler.point.action.Enable();
        actionHandler.move.action.Enable();
        actionHandler.submit.action.Enable();
        actionHandler.cancel.action.Enable();
    }

    public void DisableAllUIActions()//全ての入力を無効化
    {
        if (actionHandler == null) return;

        actionHandler.point.action.Disable();
        actionHandler.move.action.Disable();
        actionHandler.submit.action.Disable();
        actionHandler.cancel.action.Disable();
    }
}
