using UnityEngine;
using UnityEngine.UIElements;

public class MainScreen : MonoBehaviour
{
    public UIDocument document;

    private GameModel model;
    private VisualElement mainRoot;
    private SetupScreen setupScreen;

    private void Start()
    {
        model = GameModel.Instance;

        VisualElement root = document.rootVisualElement;
        mainRoot = root.Q<VisualElement>("MainScreen");
        
        setupScreen = new SetupScreen(root.Q<VisualElement>("SetupScreen"));
        setupScreen.Hide();

        // Connection navigation controls
        mainRoot.Q<Button>("SetupButton").clicked += () => ShowSetup();

        // Connect buttons to model functions
        mainRoot.Q<Button>("StartButton").clicked += () => model.StartRotate();
        mainRoot.Q<Button>("StopButton").clicked += () => model.StopRotate();
        mainRoot.Q<Button>("ResetButton").clicked += () => model.ResetRotations();

        // Subscribe for model change events
        GameModel.WasChanged += RefreshUI;
    }

    private void OnDisable()
    {
        GameModel.WasChanged -= RefreshUI;
    }

    private void RefreshUI()
    {
        mainRoot.Q<Label>("NameLabel").text = model.UserName;
    }

    private void ShowSetup()
    {
        Debug.Log("Show setup?");
        setupScreen.Show();
    }
}
