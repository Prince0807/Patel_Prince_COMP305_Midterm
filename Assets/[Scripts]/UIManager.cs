using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UIHintPanel;

    // Hold Tab to see Player Controls...
    private void Update()
    {
        UIHintPanel.SetActive(Input.GetKey(KeyCode.Tab));
    }
}
