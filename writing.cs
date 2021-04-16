using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class writing : MonoBehaviour {
    /*
    -you need to attatch this to a book
    -then add a ui text as a child of the book
        -write the text that you want in the book in this text
    -attatch that ui text object as the public text on the this script on the book
    */
    public Text text;

    //returns the attatched text as a string
    public string words()
    {
        return text.text.ToString();
    }
}
