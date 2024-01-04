using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ColorSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ColorSelect()
    {
        if (player.GetComponent<Renderer>().material.color == new Color(0, 0, 0))
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            Debug.Log("Negro");
        }
        else if(player.GetComponent<Renderer>().material.color == new Color(127, 19, 54))
        {
            GetComponent<Renderer>().material.color = new Color(63, 19, 54);
            Debug.Log("Rojo");
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.cyan;
            Debug.Log("Otro");
        }
    }

}
