using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    public TextManager text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Button Clicked");
            HandleLeftClick();
        }
    }

    // Action to perform when left click is detected
    void HandleLeftClick()
    {
        // text.UpdateTextOverride("Testing updated text");
        text.UpdateText();
    }
}
