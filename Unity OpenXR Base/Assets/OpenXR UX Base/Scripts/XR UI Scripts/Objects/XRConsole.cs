/**********************************************************************************************************************************************************
 * XRConsole
 * ---------
 *
 * 2021-08-25
 *
 * A simple console where you can send strings, integers, floats or booleans and have them displayed.  Great for debugging in VR.
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface _XRConsole
{
    void Clear(); // Clear the console

    void Input(string newTitle); // Add line to the console
    void Input(int newTitle); // Add line to the console
    void Input(float newTitle); // Add line to the console
    void Input(bool newTitle); // Add line to the console
    void Input(XRData newData); // Add line to the console
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Objects/XRConsole")]
public class XRConsole : MonoBehaviour, _XRConsole
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    [Header("____________________________________________________________________________________________________")]
    [Header("A console-like text field that holds a number of lines of text.\n____________________________________________________________________________________________________")]
    [Header("INPUTS\n\n - Clear() - Clear the console.\n - Input( [ int | float | bool | string | XRData ] ) - Add a line of text.")]
    [Header("____________________________________________________________________________________________________")]
    [Header("SETTINGS")]
    [Header("Number of lines in the console.")]
    public int numLines = 20;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private string[] linesOfText;
    private int currentLine = -1;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Overloaded Print functions for various types
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Input(float theItem) { Input (theItem.ToString()); }
    public void Input(int theItem) { Input (theItem.ToString()); }
    public void Input(bool theItem) { Input (theItem.ToString()); }
    public void Input(string theItem) { AddLineOfText(theItem); }
    public void Input(XRData theData) { AddLineOfText(theData.ToString()); }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Set up the variables ready to go.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        linesOfText = new string[numLines];
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Refresh the display when turned on.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void OnEnable()
    {
        CommitToDisplay();
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Clear the display array and reset the currentLine position to the start
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Clear()
    {
        if (linesOfText != null)
        {
            for(int lineNumber = 0; lineNumber < numLines; lineNumber++)
            {
                linesOfText[lineNumber] = "";
            }
            currentLine = -1;
            CommitToDisplay();
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Add a new line of text to the display array, moving it all up from the bottom if necessary.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private void AddLineOfText(string theText)
    {
        if (linesOfText != null)
        {
            currentLine = currentLine + 1;
            if (currentLine >= numLines)
            {
                for(int lineNumber = 0; lineNumber < numLines-1; lineNumber++)
                {
                    linesOfText[lineNumber] = linesOfText[lineNumber+1];
                }
                currentLine = numLines-1;
            }
            linesOfText[currentLine] = theText;
            CommitToDisplay();
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Change the text in the display from the array of text
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private void CommitToDisplay()
    {
        if (linesOfText != null)
        {
            string theText = "";
            for(int lineNumber = 0; lineNumber < numLines; lineNumber++)
            {
                theText += linesOfText[lineNumber] + "\n";
            }
            ChangeTextOnTMP textToChange = GetComponentInChildren<ChangeTextOnTMP>(true);
            if (textToChange != null) textToChange.Input(theText);
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}