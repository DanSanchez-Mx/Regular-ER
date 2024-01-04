using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState
{
    menu,
    credits
}

public class MenuCanvas : MonoBehaviour
{
    public MenuState currentMenuState = MenuState.menu;
    public static MenuCanvas sharedInstance;

    public bool gameRunning = true;

    private void Awake()
    {
        //El if solo es para asegurar que solo hay un shared Instance
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentMenuState != MenuState.menu)
        {
            Menu();
        }
    }

    public void Menu()
    {
        SetMenuState(MenuState.menu);
    }

    public void Credits()
    {
        SetMenuState(MenuState.credits);
    }

    private void SetMenuState(MenuState newMenuState)
    {
        if (newMenuState == MenuState.menu)
        {
            MenuManagerMenu.sharedInstance.ShowMenuCanvas();
            MenuManagerMenu.sharedInstance.HaidCreditsCanvas();

        }
        else if (newMenuState == MenuState.credits)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManagerMenu.sharedInstance.HaidMenuCanvas();
            MenuManagerMenu.sharedInstance.ShowCreditsCanvas();
        }

        this.currentMenuState = newMenuState;
    }
}
