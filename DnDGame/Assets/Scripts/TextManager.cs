using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = "Initial text";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this method to change the text of this object
    public void UpdateText(string newText)
    {
        uiText.text = newText;
    }
}
