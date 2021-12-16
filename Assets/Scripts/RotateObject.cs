using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 10;

    private void OnMouseDrag()
    {
        float inputX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;

        transform.RotateAroundLocal(Vector3.up, inputX);
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}
}
