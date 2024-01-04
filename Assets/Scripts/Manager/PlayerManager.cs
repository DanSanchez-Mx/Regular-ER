using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    int characterIndex;

    public static int numCoins;
    public TextMeshProUGUI coinsTextGame, coinsTextPause, coinsTextGameOver;

    private void Awake()
    {
        numCoins = PlayerPrefs.GetInt("numCoins", 0);

        // Seccion para cambiar el personaje
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(characterPrefabs[characterIndex], new Vector2(0, -6), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Linea para regresar a 0 todos los prefabs
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        coinsTextGame.text      = "" + numCoins;
        coinsTextPause.text     = "" + numCoins;
        coinsTextGameOver.text  = "" + numCoins;
    }
}
