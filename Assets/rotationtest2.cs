using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationtest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.gyro.enabled)
        {
            Vector3 camera_v;
            Vector3 euler = transform.rotation.eulerAngles;
            Vector3 biased = Input.gyro.rotationRateUnbiased;
            camera_v.y = euler.y - biased.y;
            camera_v.z = euler.z + biased.z;
            camera_v.x = euler.x - biased.x;

            //camera_v.y = gyro_v.x - Init_v.x;
            //camera_v.x = Init_v.y - gyro_v.y;
            //camera_v.z = gyro_v.z - Init_v.z;
            transform.rotation = Quaternion.Euler(camera_v);
            
            
        }
    }
    public void resetView()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
