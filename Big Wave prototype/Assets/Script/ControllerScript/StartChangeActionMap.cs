using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartChangeActionMap : MonoBehaviour
{
    [SerializeField] string _actionMapName;
    [SerializeField] PlayerInput _playerInput;

    void Start()
    {
        _playerInput.SwitchCurrentActionMap(_actionMapName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
