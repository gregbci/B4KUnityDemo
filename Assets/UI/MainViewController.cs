using UnityEngine;
using UnityEngine.UIElements;

public class MainViewController : MonoBehaviour
{
    public GameController gameController;
    public UIDocument view;

    private void OnEnable()
    {
        VisualElement root = view.rootVisualElement;

        // lookup buttons, there might be a nicer way to do this to avoid name coupling
        Button startButton = root.Q<Button>("StartButton");
        Button stopButton = root.Q<Button>("StopButton");
        Button resetButton = root.Q<Button>("ResetButton");

        // connect functions to the button clicked actions, note that view controller
        // delegates all the game control to game controller
        startButton.clicked += () => gameController?.startRotate();
        stopButton.clicked += () => gameController?.stopRotate();
        resetButton.clicked += () => gameController?.resetRotations();
    }
}
