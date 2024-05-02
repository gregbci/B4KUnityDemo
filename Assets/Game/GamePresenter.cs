using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    public GameObject cube;
    public GameModel model;

    void Update()
    {
        if (model.IsRotating)
        {
            cube.transform.Rotate(model.RotationRates * Time.deltaTime);
        }
    }
}

