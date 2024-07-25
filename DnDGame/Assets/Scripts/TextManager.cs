using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public TextMeshProUGUI commandTextDebug;
    List<string> dialogueList = new List<string>();
    List<string> commandList = new List<string>();
    int dialogueIndex = 0;
    int emptyLineCount = 0;
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
        // only updates the text when it's not empty
        if (string.IsNullOrWhiteSpace(newText))
        {
            // empty string can be used as a buffer action
            Debug.Log("EMPTY LINE " + emptyLineCount);
            emptyLineCount++;
        }
        else
        {
            uiText.text = newText;
        }
    }

    // Call this method to change the text using its internal list of strings
    public void UpdateText()
    {
        // test display for commands to be synced with dialogue
        commandTextDebug.text = commandList[dialogueIndex];

        string newText = dialogueList[dialogueIndex];
        // only updates the text when it's not empty
        if (string.IsNullOrWhiteSpace(newText))
        {
            // empty string can be used as a buffer action
            Debug.Log("EMPTY LINE " + emptyLineCount);
            emptyLineCount++;
            dialogueIndex = (dialogueIndex + 1) % dialogueList.Count;   // iterate dialogue index, loop back if overflow
        }
        else
        {
            uiText.text = newText;                                      // swaps text to next one in list
            dialogueIndex = (dialogueIndex + 1) % dialogueList.Count;   // iterate dialogue index, loop back if overflow
        }


    }

    // Parse a text file to load into the list of strings for the dialogue
    void LoadTextFile(TextAsset textFile)
    {
        // Debug.Log(textFile);
        if (textFile)   // only loads if the text file exists
        {
            string text = textFile.ToString();              // Convert TextAsset to string
            string[] textArray = text.Split("\n");          // Split file into separate lines
            // each entry in textArray should be a line in the text file

            // string prevLine = null;
            foreach (string line in textArray)  // Check each line separately to see if it's a command or not
            {
                // splits each line based on /
                // left half of line before / is dialogue, right half of line is command
                if (string.IsNullOrWhiteSpace(line))
                {
                    // empty line
                    dialogueList.Add(null);
                    commandList.Add(null);
                }
                else
                {
                    string formattedLine = line;
                    if (!line.Contains("//"))     // dialogue by itself, no command
                    {
                        formattedLine = line + "//";     // add the slash to end for splitting to work
                    }
                    Debug.Log("LINE: " + formattedLine);
                    string[] splitLine = formattedLine.Split("//");
                    foreach (string test in splitLine)
                    {
                        Debug.Log("ITEM: " + test);
                    }
                    string dialogueLine = splitLine[0].Trim(), commandLine = splitLine[1].Trim();

                    if (string.IsNullOrWhiteSpace(dialogueLine))
                    {
                        dialogueList.Add(null);
                    }
                    else
                    {
                        dialogueList.Add(dialogueLine);
                    }

                    if (string.IsNullOrWhiteSpace(commandLine))
                    {
                        commandList.Add(null);
                    }
                    else
                    {
                        commandList.Add(commandLine);
                    }
                }

                // all of the stuff below is probably useless, I was overcomplicating things

                /*
                string trimmedLine = line.Trim();   // removes leading and ending whitespace
                if (string.IsNullOrWhiteSpace(trimmedLine))
                {
                    Debug.Log("LINE: (EMPTY)");
                }
                else
                {
                    Debug.Log("LINE: " + trimmedLine);
                }
                
                
                // likely want to treat each list as a "timeline" for each action to perform in order, and in sync if needed
                // this means we'll need empty / buffer actions
                if (string.IsNullOrWhiteSpace(trimmedLine))
                {
                    // this line is empty
                    // if previous line was a command, insert null into dialogue only
                    if ((prevLine != null) && prevLine.StartsWith("//"))
                    {
                        dialogueList.Add(null);
                        Debug.Log("EMPTY LINE AFTER COMMAND");
                    }
                    else
                    {   
                        // insert null into both
                        commandList.Add(null);
                        dialogueList.Add(null);
                    }
                    
                }
                else
                {
                    if (trimmedLine.StartsWith("//"))
                    {
                        // this is a command line
                        commandList.Add(trimmedLine);
                    } 
                    else
                    {
                        // this is a dialogue line
                        dialogueList.Add(trimmedLine);
                        if ((prevLine != null) && prevLine.StartsWith("//")) 
                        {
                            // previous line was a command OR this is the first line
                            // add nothing to sync up with command
                        }
                        else
                        {
                            // previous line was empty, add null
                            commandList.Add(null);
                        }
                    }
                }

                prevLine = trimmedLine;     // keep track of previous line for logic purposes
                */
            }
        }

        // print out the stored lines for debugging
        for (int i = 0; i < commandList.Count(); i++)
        {
            Debug.Log("COMMAND: " + commandList[i] + "\nDIALOGUE: " + dialogueList[i]);
        }

        // should be equal
        if (commandList.Count() != dialogueList.Count())
        {
            Debug.Log("ERROR: COMMAND AND DIALOGUE ARE OUT OF SYNC.\nCOMMAND COUNT: " + commandList.Count()
            + "\nDIALOGUE COUNT: " + dialogueList.Count());
        }
        else
        {
            Debug.Log("Command and Dialogue are synced!");
        }

    }

    // Debug function for converting a normal string to a literal string (all special characters are escaped)
    string ToLiteral(string input)
    {
        StringBuilder literal = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            switch (c)
            {
                case '\n': literal.Append(@"\n"); break;
                case '\r': literal.Append(@"\r"); break;
                case '\t': literal.Append(@"\t"); break;
                case '\\': literal.Append(@"\\"); break;
                case '\0': literal.Append(@"\0"); break;
                case '\b': literal.Append(@"\b"); break;
                case '\f': literal.Append(@"\f"); break;
                default: literal.Append(c); break;
            }
        }
        return literal.ToString();
    }


}