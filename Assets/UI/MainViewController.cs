using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class MainViewController : MonoBehaviour
{
    public UIDocument view;
    public GameModel model;

    private void Start()
    {
        model = GameModel.Instance;
        VisualElement root = view.rootVisualElement;

        // Connect buttons to model functions
        root.Q<Button>("StartButton").clicked += () => model.StartRotate();
        root.Q<Button>("StopButton").clicked += () => model.StopRotate();
        root.Q<Button>("ResetButton").clicked += () => model.ResetRotations();

        // Subscribe for model change events
        GameModel.WasChanged += RefreshUI;
    }

    private void OnDisable()
    {
        GameModel.WasChanged -= RefreshUI;
    }

    private void RefreshUI()
    {
        VisualElement root = view.rootVisualElement;
        root.Q<Label>("NameLabel").text = model.UserName;
    }
}
