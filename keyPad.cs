using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPad : MonoBehaviour {
    public TextMesh _text;
    
    public string[] code = new string[3];
    int iteration;
    public bool isOn;
    void Start()
    {
        isOn = false;
        iteration = 0;
        setToZero();
    }
    void Update()
    {
        if (isOn == true)
        {
            input();
        }

        writeNumbers();
        correct();
       // Debug.Log(isOn);
    }

    void setToZero()
    {
        for (int i = 0; i < code.Length; i++)
        {
            code[i] = "0";
        }
    }

    void writeNumbers()
    {
        for (int i = 0; i < code.Length; i++)
        {
            _text.text = code[0].ToString()
                + code[1].ToString()
                + code[2].ToString()
                + code[3].ToString();
        }
    }
    void input()
    {
        if (iteration == 4 && Input.anyKeyDown)
        {
            iteration = 0;
            setToZero();
            isOn = false;
        }
        else if (Input.anyKeyDown)
        {
            code[iteration] = Input.inputString;
            iteration += 1;
        }
    }

    void correct()
    {
        int pass = 0;
        string[] cCode = new string[4];
        cCode[0] = "1";
        cCode[1] = "2";
        cCode[2] = "3";
        cCode[3] = "4";

        for(int i = 0; i < 4; i++)
        {
            if(cCode[i] == code[i])
            {
                pass++;
                if(pass == 4)
                {
                    this.gameObject.transform.position += Vector3.up;
                }
            }
        }
    }
}
