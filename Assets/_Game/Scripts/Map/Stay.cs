using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Lưu lại vị trí và góc quay ban đầu của đối tượng
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Đặt lại vị trí và góc quay của đối tượng về giá trị ban đầu trong mỗi khung hình
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
