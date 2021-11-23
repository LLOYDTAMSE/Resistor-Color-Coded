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

    [Header("Band Groups")]
    public Transform firstBandGroup;
    public Transform secondBandGroup;
    public Transform thirdBandGroup;
    public Transform ResistorImage;


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

            //TODO: Disable thirdband gameobject by using SetActive(false)
            foreach(Transform child in ResistorImage)
            {
                child.GetComponent<Button>().
            }


        } else
        {
            //If five band, enable all 3rd bands
            foreach(Transform child in thirdBandGroup)
            {
                child.GetComponent<Button>().interactable = true;
            }
            
            //TODO: opposite

        }
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
