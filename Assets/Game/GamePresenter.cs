using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    public GameObject cube;
    private GameModel model;

    void Start()
    {
        // look this up once instead of every update
        model = GameModel.Instance;
    }

    void Update()
    {
        if (model?.IsRotating ?? false)
        {
            cube.transform.Rotate(model.RotationRates * Time.deltaTime);
        }
    }
}

