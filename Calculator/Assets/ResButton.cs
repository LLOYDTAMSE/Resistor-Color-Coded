using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResButton : MonoBehaviour
{
    public int value = 0;
    
    public enum ButtonType {bandOne, bandTwo, bandThree, multiplier, tolerance}; // This code is used also to contain constant values.

    public ButtonType buttonType;

    public Resistor resistor;

    void Start()
    {

        resistor = GameObject.Find("Resistor").GetComponent<Resistor>();

        value = transform.GetSiblingIndex(); // used to manipulate the array on delegate function.

        
        GetComponent<Button>().onClick.AddListener(
            delegate 
            {

                if(buttonType == ButtonType.bandOne)
                {
                    resistor.images[0].color = GetComponent<Image>().color; //Set the first band's color to this button's color.
                }
                //continue bandTwo bandThree mult Tol
                 if(buttonType == ButtonType.bandTwo)
                {
                    resistor.images[1].color = GetComponent<Image>().color; //Set the second band's color to this button's color.
                }

                 if(buttonType == ButtonType.bandThree)
                {
                    resistor.images[2].color = GetComponent<Image>().color; //Set the third band's color to this button's color.
                }

                if(buttonType == ButtonType.multiplier)
                {
                    resistor.images[3].color = GetComponent<Image>().color; //Set the multiplier band's color to this button's color.
                }
                if(buttonType == ButtonType.tolerance)
                {
                    resistor.images[4].color = GetComponent<Image>().color;  //Set the multiplier band's color to this button's color.
                }

            });

        }

    }


