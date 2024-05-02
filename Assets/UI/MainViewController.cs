using UnityEngine;
using UnityEngine.UIElements;

public class MainViewController : MonoBehaviour
{
    // replace with model
    public GameModel model;
    public UIDocument view;

    private void OnEnable()
    {
        VisualElement root = view.rootVisualElement;

        Button startButton = root.Q<Button>("StartButton");
        Button stopButton = root.Q<Button>("StopButton");
        Button resetButton = root.Q<Button>("ResetButton");

        // the model does the real work
        startButton.clicked += () => model?.StartRotate();
        stopButton.clicked += () => model?.StopRotate();
        resetButton.clicked += () => model?.ResetRotations();
    }
}
