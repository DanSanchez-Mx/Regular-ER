using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerMenu : MonoBehaviour
{
    public static MenuManagerMenu sharedInstance;
    public Canvas MenuCanvas;
    public Canvas CreditsCanvas;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }


    // Funciones para mostrar u ocultar el canvas del juego
    public void ShowMenuCanvas()
    {
        MenuCanvas.enabled = true;
    }
    public void HaidMenuCanvas()
    {
        MenuCanvas.enabled = false;
    }

    // Funciones para mostrar u oculatra el canvas del Game Over
    public void ShowCreditsCanvas()
    {
        CreditsCanvas.enabled = true;
    }
    public void HaidCreditsCanvas()
    {
        CreditsCanvas.enabled = false;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }
}
