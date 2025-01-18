using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山詩恩
//ムービーをスキップする操作
public class ControllerOfMovieSkip : MonoBehaviour
{
    [SerializeField] MovieCameraEvent _movieCameraEvent;
   
    public void Skip(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        _movieCameraEvent.End();
    }
}
