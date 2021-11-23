using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("Band Groups")] // Transform is used to have children properties.
    public Transform firstBandGroup;
    public Transform secondBandGroup;
    public Transform thirdBandGroup; 
    public GameObject thirdBandObj;

    [Header("Values")] // int is used to represent the number data.
    public int firstVal;
    public int secVal;
    public int thirdVal;
    public int mult;
    public int tol;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(resistorState == ResistorState.Four)
        {
            //If four band, disable all 3rd bands
            foreach(Transform child in thirdBandGroup)
            {
                child.GetComponent<Button>().interactable = false;
            }

            //Disable thirdband gameobject by using SetActive(false)
            thirdBandObj.SetActive(false);


        } else
        {
            //If five band, enable all 3rd bands
            foreach(Transform child in thirdBandGroup)
            {
                child.GetComponent<Button>().interactable = true;
            }
            
            // Abling thirdband gameobject by using SetActive(true)
            thirdBandObj.SetActive(true);

        }
    }

    public void OnStateChange() // Code used in UI dropdown.
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
