using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

//作成者：桑原

public class PlayGuideInputModule : MonoBehaviour
{
    [SerializeField] InputSystemUIInputModule inputModule;
    [Header("▼左右入力を対応させるアクション")]
    [SerializeField] InputActionReference leftRightActionReference;
    [Header("▼キャンセル入力を対応させるアクション")]
    [SerializeField] InputActionReference cancelActionReference;
    [Header("▼左入力時に呼び出す処理")]
    [SerializeField] UnityEvent leftEvent;
    [Header("▼右入力時に呼び出す処理")]
    [SerializeField] UnityEvent rightEvent;
    [Header("▼キャンセル入力時に呼び出す処理")]
    [SerializeField] UnityEvent cancelEvent;

    private InputSystemUIInputModule actionHandler;
    private InputAction leftRightAction;
    private InputAction cancelAction;

    private bool isLeftRightInputActive = false;//左右入力が行われているか
    private float inputThreshould = 0.2f;

    private void Awake()
    {
        actionHandler = inputModule.GetComponent<InputSystemUIInputModule>();

        leftRightAction = leftRightActionReference.action;
        cancelAction = cancelActionReference.action;

        EnableAllUIActions();//全入力を有効化
    }

    private void OnEnable()
    {
        leftRightAction.Enable();//左右入力を有効化
        cancelAction.Enable();//キャンセル入力を有効化

        leftRightAction.performed += OnleftRightInput;
        cancelAction.performed += OnCancelInput;
    }

    private void OnDisable()
    {
        leftRightAction.Disable();//左右入力を無効化
        cancelAction.Disable();//キャンセル入力を無効化

        leftRightAction.performed -= OnleftRightInput;
        cancelAction.performed -= OnCancelInput;
    }

    public void OnleftRightInput(InputAction.CallbackContext context)//左右入力の処理
    {
        float xValue = context.ReadValue<Vector2>().x;

        if (Mathf.Abs(xValue) > inputThreshould)
        {
            if (!isLeftRightInputActive)
            {
                isLeftRightInputActive = true;

                if (context.ReadValue<Vector2>().x < 0)
                {
                    leftEvent.Invoke();//左入力時の処理
                }

                else if (context.ReadValue<Vector2>().x > 0)
                {
                    rightEvent.Invoke();//右入力時の処理
                }
            }
        }

        else
        {
            isLeftRightInputActive = false;
        }
    }

    public void OnCancelInput(InputAction.CallbackContext context)//キャンセル入力時の処理
    {
        cancelEvent.Invoke();
    }

    public void EnableAllUIActions()//全ての入力を有効化
    {
        actionHandler.point.action.Enable();
        actionHandler.move.action.Enable();
        actionHandler.submit.action.Enable();
        actionHandler.cancel.action.Enable();
    }

    public void DisableAllUIActions()//全ての入力を無効化
    {
        actionHandler.point.action.Disable();
        actionHandler.move.action.Disable();
        actionHandler.submit.action.Disable();
        actionHandler.cancel.action.Disable();
    }

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
}
