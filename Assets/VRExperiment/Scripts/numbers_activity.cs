using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //This will help in getting the UI values.


public class numbers_activity : MonoBehaviour
{

    public TextMeshProUGUI output; //Add field for TextMeshProUGUI

    public void ChangeValue(){
        output.text = "Hello world!";
    }
}
