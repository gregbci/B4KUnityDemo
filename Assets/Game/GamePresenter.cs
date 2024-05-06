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
        // cache model and subscribe for changed event
        model = GameModel.Instance;
        GameModel.WasChanged += ModelChanged;
    }


    private void OnDisable()
    {
        GameModel.WasChanged -= ModelChanged;
    }

    void Update()
    {
        if (model?.IsRotating ?? false)
        {
            cube.transform.Rotate(model.RotationRates * Time.deltaTime);
        }
    }

    private void ModelChanged()
    {
        // update the cube color
        cube.GetComponent<Renderer>().material.color = model.CubeColor;
    }
}

