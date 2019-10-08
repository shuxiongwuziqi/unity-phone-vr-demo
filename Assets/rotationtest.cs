using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationtest : MonoBehaviour
{
    private float vertRotateRate, horiRotateRate,zRotationRate;
    public float maxRotateRate = Mathf.PI;
    public Vector3 initEyeRotation;
    private Quaternion _initEyeRotation;
    

    public Button btn;
    public Text btn_text;
    private bool isPress;
    private float PressTime;
    public float delayTimeForClick = 3f;

    public Transform Canvas, eye;
    private float delta;

    private void Start()
    {
        Input.gyro.enabled = true;
        _initEyeRotation.eulerAngles = initEyeRotation;

        btn.interactable = false;
        isPress = false;
        PressTime = 0f;
        delta = 0f;
    }

    private void Update()
    {
        if (Input.gyro.enabled)
        {
            vertRotateRate = Input.gyro.rotationRateUnbiased.x;
            horiRotateRate = Input.gyro.rotationRateUnbiased.y;
            zRotationRate = Input.gyro.rotationRateUnbiased.z;

            vertRotateRate = Mathf.Sign(vertRotateRate) * Mathf.Clamp(Mathf.Abs(vertRotateRate), 0, maxRotateRate);
            horiRotateRate = Mathf.Sign(horiRotateRate) * Mathf.Clamp(Mathf.Abs(horiRotateRate), 0, maxRotateRate);
            zRotationRate = Mathf.Sign(zRotationRate) * Mathf.Clamp(Mathf.Abs(zRotationRate), 0, maxRotateRate);

            eye.transform.Rotate(-vertRotateRate, -horiRotateRate, zRotationRate);
            Canvas.transform.RotateAround(eye.transform.position, Vector3.up, -horiRotateRate);
            delta += horiRotateRate;
        }
        Vector3 forward = eye.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(eye.transform.position, forward ,Color.red);

        RaycastHit hit;
        if(Physics.Raycast(eye.transform.position,forward,out hit))
        {
            if (hit.collider.gameObject.CompareTag("button"))
            {
                if (!isPress)
                {
                    isPress = true;
                    btn.interactable = true;
                    PressTime = 0;
                }
                else
                {
                    PressTime += Time.deltaTime;
                    btn_text.text = "press"+PressTime.ToString("f0")+"s";
                    if (PressTime > delayTimeForClick)
                    {
                        btn.onClick.Invoke();
                        PressTime = 0;
                    }
                }
            }
        }
        else// on exit
        {
            isPress = false;
            btn.interactable = false;
            btn_text.text = "reset";
        }
    }

    public void ResetView()
    {
        eye.transform.rotation = _initEyeRotation;
        Canvas.transform.RotateAround(eye.transform.position, Vector3.up, delta);
        delta = 0f;
    }
}
