using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // allow to use the textmesh pro in unity UI.

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
    public Transform multiGroup;
    public Transform tolBandGroup; 
    public GameObject thirdBandObj;

    [Header("Values")] // int is used to represent the number data.
    public int firstVal;
    public int secVal;
    public int thirdVal;
    public float mult = 1; // float is number type where you can use decimals and whole number at the same time.
    public float tol = 0.01f; //default value

    public int resistance;

    //TODO: create 2 floats named minResistance and maxResistance

    [Header("Textboxes")]
    public TMP_Text resistanceText;

    //TODO: reference min resistance text and max resistance text


    // Start is called before the first frame update
    void Start()
    {
        UpdateResistance();
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

    public void OnStateChange() // Code used in UI dropdown or in choosing Bands.
    {
        if(dropdown.value == 0)
        {
            resistorState = ResistorState.Four;
        } else
        if(dropdown.value == 1)
        {
            resistorState = ResistorState.Five;
        }

        UpdateResistance();
    }

    public void UpdateResistance()
    {
        //  Create an equation to solve the resistance. That matters with the number of bands.
        if(resistorState == ResistorState.Four)
        {
           resistance = firstVal*10 + secVal;
        }else 
        if(resistorState == ResistorState.Five)
        {
            resistance = firstVal*100 + secVal*10 + thirdVal;
        }

        //Declare a float variable for resistance by converting the resistance to float
        float floatResistance = (float) resistance;

        //Multiplying resistance to the multiplier
        floatResistance *= mult;

        //TODO: declare values for min resistance and max resistance
        // here


        //Displaying the resistance text
        resistanceText.text = floatResistance.ToString() + " Ω ±" + (tol * 100).ToString() + "%";

        //TODO: display the min resistance and max resistance to textboxes



        Debug.Log("Resistance Updated, resistance is now " + resistanceText.text);

    }
}
