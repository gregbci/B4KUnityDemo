using UnityEngine;
using UnityEngine.UIElements;

public class MainViewController : MonoBehaviour
{
    public UIDocument view;
    
    private void Start()
    {
        VisualElement root = view.rootVisualElement;
        Button startButton = root.Q<Button>("StartButton");
        Button stopButton = root.Q<Button>("StopButton");
        Button resetButton = root.Q<Button>("ResetButton");

        // the model does the real work
        GameModel model = GameModel.Instance;
        startButton.clicked += () => model?.StartRotate();
        stopButton.clicked += () => model?.StopRotate();
        resetButton.clicked += () => model?.ResetRotations();
    }
}
