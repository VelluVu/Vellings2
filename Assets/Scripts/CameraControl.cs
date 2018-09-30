using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    float speed;
    float scalerXY;
    float speedFixY;

    Vector3 moveX;
    Vector3 moveY;
    Vector3 moveXY;
    Vector3 scaleVectorHalf;
    Vector3 yFix;

    private void Start()
    {     
        speed = 0.25f * Time.deltaTime;
        scalerXY = 0.30f;
        speedFixY = 0.25f * Time.deltaTime;
        moveX.Set(speed,0f,0f);
        moveY.Set(0f, speed, 0f);
        yFix.Set(0f, speedFixY, 0f);
        scaleVectorHalf.Set(scalerXY, scalerXY, 0f);
    }

    private void LateUpdate()
    {
        CamMovement();
    }

    private void CamMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveX);
            //Debug.Log("D Key pressed");           

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                moveXY = moveX + yFix;
                
                moveXY.Scale(scaleVectorHalf);
                transform.Translate(moveXY);
                
                //Debug.Log("D and W Key pressed");
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                moveXY = moveX - yFix;
                
                moveXY.Scale(scaleVectorHalf);
                transform.Translate(moveXY);
                
                //Debug.Log("D and S Key pressed");
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveX);
            //Debug.Log("A Key pressed");

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                moveXY = -moveX + yFix;
                
                moveXY.Scale(scaleVectorHalf);
                transform.Translate(moveXY);
                
                //Debug.Log("A and W Key pressed");
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                moveXY = -moveX - yFix;
                
                moveXY.Scale(scaleVectorHalf);
                transform.Translate(moveXY);
                
                //Debug.Log("A and S Key pressed");
            }
        }

        else if (Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(yFix);
            //Debug.Log("W Key pressed");

        }

        else if (Input.GetKey(KeyCode.S))
        {
           
            transform.Translate(-yFix);
            //Debug.Log("S Key pressed");

        }
    }

    public void ChangeSpeed (float amount)
    {
        if (amount <= 1 || amount > 0)
        this.speed = amount;
    }
}
