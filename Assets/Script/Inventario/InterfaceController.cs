using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public GameObject inventoryPanel;
    public Text itemText;
    public Text[] quantText;

    bool inActive = false;


    void Start()
    {
        itemText.text = null;
        for (int i = 0; i < quantText.Length; i++)
        {
            quantText[i].text = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab)) {
            inActive =!inActive;
            inventoryPanel.SetActive(inActive);
            Cursor.visible = inActive;

        }
        if(inActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState= CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }


}
