using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [Header("ƒQ[ƒ€’†’f‚ÉŒÄ‚ÔƒCƒxƒ“ƒg")]
    [SerializeField] UnityEvent quitEvents;

    public void Quit()//ƒQ[ƒ€’†’f‚Ìˆ—
    {
        quitEvents.Invoke();
        SceneManager.LoadScene("MenuScene");
    }
}
