using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_360 : MonoBehaviour
{

    //Done with the following help: https://discussions.unity.com/t/simple-360-degree-cube-rotation-around-y-axis/184375/3 and https://www.youtube.com/watch?v=8pC3SE5PIzY 
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
