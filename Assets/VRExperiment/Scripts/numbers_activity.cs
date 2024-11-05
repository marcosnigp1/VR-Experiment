using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //This will help in getting the UI values.


public class numbers_activity : MonoBehaviour
{

    public TextMeshProUGUI main_output; //Main testing field

    //Texting output fields
    public TextMeshProUGUI output1;
    public TextMeshProUGUI output2; 
    public TextMeshProUGUI output3;
    public TextMeshProUGUI output4;

    public void ChangeValue(){
        main_output.text = "Hello world!";


        //Show values.
        output1.text = "Hi!";
        output2.text = "Hi!";
        output3.text = "Hi!";
        output4.text = "Hi!";
    }
}
