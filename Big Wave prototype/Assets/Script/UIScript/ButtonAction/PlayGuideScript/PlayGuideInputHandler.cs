using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

//作成者：桑原

public partial class PlayGuideInputHandler : MonoBehaviour
{
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
    [SerializeField] InputSystemUIInputModule inputModule;

    private InputSystemUIInputModule actionHandler;
    private InputAction leftRightAction;
    private InputAction cancelAction;
    private float inputThreshould = 0.2f;
    private bool isHolding = false;

    private void Awake()
    {
        if (leftRightActionReference != null)
            leftRightAction = leftRightActionReference.action;

        if (cancelActionReference != null)
            cancelAction = cancelActionReference.action;

        actionHandler = inputModule.GetComponent<InputSystemUIInputModule>();
    }

    private void OnEnable()
    {
        leftRightAction.Enable();
        cancelAction.Enable();
        leftRightAction.performed += OnleftRightInput;
        cancelAction.performed += OnCancelInput;
    }

    private void OnDisable()
    {
        leftRightAction.Disable();
        cancelAction.Disable();
        leftRightAction.performed -= OnleftRightInput;
        cancelAction.performed -= OnCancelInput;
    }

    public void OnleftRightInput(InputAction.CallbackContext context)//左右入力時の処理
    {
        float xValue = context.ReadValue<Vector2>().x;

        if (Mathf.Abs(xValue) > inputThreshould)
        {
            if (isHolding)
                return;

            isHolding = true;

            if (xValue < 0)
                leftEvent.Invoke();

            else if (xValue > 0)
                rightEvent.Invoke();
        }

        else
            isHolding = false;
    }

    public void OnCancelInput(InputAction.CallbackContext context)//キャンセル入力時の処理
    {
        cancelEvent.Invoke();
    }
}
