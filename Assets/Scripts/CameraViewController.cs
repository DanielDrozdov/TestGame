using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float viewSpeed;

    private void Update() {
        float xRot = transform.rotation.eulerAngles.x - joystick.Direction.y * viewSpeed * Time.deltaTime;
        float yRot = transform.rotation.eulerAngles.y + joystick.Direction.x * viewSpeed * Time.deltaTime;
        float zRot = transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
    }
}
