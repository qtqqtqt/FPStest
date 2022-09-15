using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    private void DisableInputs()
    {
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }

    public void HandleDeath()
    {
        DisableInputs();
        gameOverCanvas.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
