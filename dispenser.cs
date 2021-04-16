using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispenser : MonoBehaviour {

    public TextMesh _text;
    public string number;
    public bool isOn;

    public GameObject geome;
    public Vector3 instPosition;

    private int _textINT;


    void Start()
    {
        isOn = false;
        setToZero();
    }

    void Update()
                        
    {
        int.TryParse(_text.text, out _textINT);
        if (isOn == true)
        {
            input();
            int.TryParse(_text.text, out _textINT);
            input();
            writeNumbers();
        }

        //Debug.Log(isOn);
        //Debug.Log(_textINT);
    }

    void setToZero()
    {
            number = "0";
    }

    void writeNumbers()
    {
            _text.text = number;
    }

    void input()
    {
        if (Input.anyKeyDown)
        {
            number = Input.inputString;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (int.TryParse(_text.text, out _textINT) == true)
            {
                for (int i = 0; i < _textINT; i++)
                {
                    Instantiate(geome, instPosition + new Vector3(Random.Range(-2,2),0,Random.Range(-2,2)), Quaternion.identity);
                }
            }
            else
            {
                _text.text = "ERROR";
            }
            setToZero();
        }
    }
}
