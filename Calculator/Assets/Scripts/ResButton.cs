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

    public Calculator calculator;

    private int K = 1000;
    private int M = 1000000;
    private int G = 1000000000;
    private float GOLD = 0.1f;
    private float SILV = 0.01f;


    void Start()
    {

        resistor = FindObjectOfType<Resistor>();
        calculator = FindObjectOfType<Calculator>();

        value = transform.GetSiblingIndex(); // used to manipulate the array on delegate function.

        
        GetComponent<Button>().onClick.AddListener(
            delegate 
            {


                switch (buttonType)
                {
                    case ButtonType.bandOne:
                        UpdateColor(0);
                        break;
                    
                    case ButtonType.bandTwo:
                        UpdateColor(1);
                        break;
                    
                    case ButtonType.bandThree:
                        UpdateColor(2);
                        break;
                    
                    case ButtonType.multiplier:
                        UpdateColor(3);
                        break;
                    
                    case ButtonType.tolerance:
                        UpdateColor(4);
                        break;

                };

                UpdateValue(value);
                calculator.UpdateResistance();

            });

        }

        
    void UpdateColor(int childId)
    {
        resistor.images[childId].color = GetComponent<Image>().color; //Set the first band's color to this button's color.
    }

    void UpdateValue(int childId) // put values on bands color.
    {
        switch (buttonType)
        {
            case ButtonType.bandOne:
                calculator.firstVal = childId;
                Debug.Log("changed first value to " + childId);
                break;
                
            case ButtonType.bandTwo:
                calculator.secVal = childId;
                Debug.Log("changed second value to " + childId);
                break;
                
            case ButtonType.bandThree:
                calculator.thirdVal = childId;
                Debug.Log("changed third value to " + childId);
                break;
                
            case ButtonType.multiplier:

                 // childId is used to get the respective color component in each band. 
                // create all multiplier values
                switch (childId) 
                {
                    case 0:
                        calculator.mult = 1;
                        break;
                    case 1:
                        calculator.mult = 10;
                        break;
                    case 2:
                        calculator.mult = 100;
                        break;
                    case 3:
                        calculator.mult = 1*K;
                        break;
                    case 4:
                        calculator.mult = 10*K;
                        break;
                    case 5:
                        calculator.mult = 100*K;
                        break;
                    case 6:
                        calculator.mult = 1*M;
                        break;
                    case 7:
                        calculator.mult = 10*M;
                        break;
                    case 8:
                        calculator.mult = 100*M;
                        break;
                    case 9:
                        calculator.mult = 1*G;
                        break;
                    case 10:
                        calculator.mult = 1*GOLD;
                        break;
                    case 11:
                        calculator.mult = 1*SILV;
                        break;
                   
                }
                
                Debug.Log("changed mult value to " + calculator.mult);
                break;
                
            case ButtonType.tolerance:

                // put respective values to match the tolerance
                switch (childId)
                {
                    case 0:
                        calculator.tol = 0.01f; // this is for 1%
                        break;
                    case 1:
                        calculator.tol = 0.02f;
                        break;
                    case 2:
                        calculator.tol = 0.005f;
                        break;
                    case 3:
                        calculator.tol = 0.0025f;
                        break;
                    case 4:
                        calculator.tol = 0.001f;
                        break;
                    case 5:
                        calculator.tol = 0.05f;
                        break;
                    case 6:
                        calculator.tol = 0.1f;
                        break;
                }

                Debug.Log("changed tol value to " + calculator.tol);
                break;
        }
    }


}


