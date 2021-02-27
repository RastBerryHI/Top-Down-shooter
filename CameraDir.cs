using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDir : MonoBehaviour
{
    [SerializeField]
    float Sensivity = 100f;

    [SerializeField]
    Transform player;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
    }
}
