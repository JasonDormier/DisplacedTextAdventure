using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public InputField inputField;

    private Controller controller;

    // Use this for initialization
    void Awake()
    {
        //getting the controller class
        controller = GetComponent<Controller>();
        
        //getting the input field and priming it to repsond when the user hits enter.
        inputField.onEndEdit.AddListener(TakeUserInput);
    }

    //creating a method to take in user input also creating a varible string to transfer that input.
    void TakeUserInput(string userInput)
    {
        //making sure whatever the user types is converted to lower case.
        userInput = userInput.ToLower();

        //calling the method from the controller script to log the userInput when we hit enter.
        controller.LogWithEnter(userInput);
        
        //creates an array that is filled with a black space so we can seperate the words the player inputs
        char[] splitUserInputs = { ' ' };

        //splits the words the user inputs into array objects using the space between the words setup with splitUserInputs.
        string[] seperatedInputWords = userInput.Split(splitUserInputs);

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputActions = controller.inputActions[i];
            if(inputActions.keyWord == seperatedInputWords[0])
            {
                inputActions.ResponseToPlayer(controller, seperatedInputWords);
                
            }
        }

        InputComplete();
        Debug.Log(userInput);
       
    }

    void InputComplete()
    {
        //calling the DisplayText function in the controller class
        controller.DisplayText();

        //built in feature to when the player hits enter the cursor stays in the input.
        inputField.ActivateInputField();

        //clears the input box when the player pushes enter.
        inputField.text = null;
    }
}
