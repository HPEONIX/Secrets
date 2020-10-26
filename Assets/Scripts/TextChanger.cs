using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    string s = "get the weapon. the door has opened";
    public void settext()
    {
        text.text = s;
    }
}
