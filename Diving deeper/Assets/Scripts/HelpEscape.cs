using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEscape : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject pause;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(true);
            pause.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
