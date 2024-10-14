using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DontChangeSelectButton : MonoBehaviour
{
    [SerializeField] Button button;

    public void DontChangeSelect()
    {
        EventSystem.current.SetSelectedGameObject(null);
        button.Select();
    }
}
