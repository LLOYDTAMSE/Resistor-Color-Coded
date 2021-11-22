using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{

    public enum ResistorState {
        Four,
        Five
    }

    [Header("Resistor State")]
    public ResistorState resistorState;
    public TMP_Dropdown dropdown;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStateChange()
    {
        if(dropdown.value == 0)
        {
            resistorState = ResistorState.Four;
        } else
        if(dropdown.value == 1)
        {
            resistorState = ResistorState.Five;
        }
    }
}
