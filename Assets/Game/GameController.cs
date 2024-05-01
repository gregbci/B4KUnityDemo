using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cube;
    public Vector3 rotateAmount;

    void Update()
    {
        if (rotate)
        {
            cube.transform.Rotate(rotateAmount * Time.deltaTime);
        }
    }

    public void startRotate()
    {
        rotate = true;
    }

    public void stopRotate()
    {
        rotate = false;
    }

    public void resetRotations()
    {
        cube.transform.rotation = Quaternion.identity;
    }

    private bool rotate = false;
}

