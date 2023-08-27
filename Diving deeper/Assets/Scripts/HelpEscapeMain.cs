using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEscapeMain : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject main_menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(true);
            main_menu.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
