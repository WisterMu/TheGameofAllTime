using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    List<string> dialogueList = new List<string>();
    List<string> commandList = new List<string>();
    int dialogueIndex = 0;
    public TextAsset dialogueInput;     // Drag and drop text file to load

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = "Initial text";
        // Debug.Log("Initial Capacity: " + dialogueList.Capacity.ToString());
        LoadTextFile(dialogueInput);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: animate text appearing letter by letter?
    }

    // Call this method to change the text of this object directly
    public void UpdateTextOverride(string newText)
    {
        uiText.text = newText;
    }

    // Call this method to change the text using its internal list of strings
    public void UpdateText()
    {
        uiText.text = dialogueList[dialogueIndex];                  // swaps text to next one in list
        dialogueIndex = (dialogueIndex + 1) % dialogueList.Count;   // iterate dialogue index, loop back if overflow
    }

    // Parse a text file to load into the list of strings for the dialogue
    void LoadTextFile(TextAsset textFile)
    {
        // Debug.Log(textFile);
        if (textFile)   // only loads if the text file exists
        {
            string text = textFile.ToString();              // Convert TextAsset to string
            string[] textArray = text.Split("\n");          // Split file into separate lines
            // Debug.Log(textArray);
            // dialogueList = new List<string>(textArray);     // Convert array into list

            foreach (string line in textArray)  // Check each line separately to see if it's a command or not
            {
                // No newlines to worry about, thankfully
                // foreach(char ch in line)
                // {
                //     if (ch == '\n')
                //     {
                //         Debug.Log("NEWLINE FOUND");
                //     }
                // }

                if (line[0] == '/')     // if the line starts with a slash (this is a command)
                {
                    commandList.Add(line);
                } 
                else 
                {
                    dialogueList.Add(line);
                }
            }
        }

        // print out the stored lines for debugging
        foreach (string line in commandList)
        {
            Debug.Log("COMMAND: " + line);
        }
        foreach (string line in dialogueList)
        {
            Debug.Log("DIALOGUE: " + line);
        }

    }

}
