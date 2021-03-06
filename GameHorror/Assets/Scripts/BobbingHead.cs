﻿using UnityEngine;
using System.Collections;

public class BobbingHead : MonoBehaviour {

    // Use this for initialization
    private float timer = 0.0f;
    float bobbingSpeed = 9.5f;
    float bobbingAmount = 0.2f;
    float midpoint = 2.0f;

    void Update()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0){
            timer = 0.0f;
        }
        else{
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed * Time.deltaTime;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0){
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 0.5f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else{
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }
}
