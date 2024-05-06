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
        // Subscribe for model change events
        model = GameModel.Instance;
        GameModel.WasChanged += RefreshUI;

        VisualElement root = document.rootVisualElement;
        mainRoot = root.Q<VisualElement>("MainScreen");

        // Connect game control buttons to model functions
        mainRoot.Q<Button>("StartButton").clicked += () => model.StartRotate();
        mainRoot.Q<Button>("StopButton").clicked += () => model.StopRotate();
        mainRoot.Q<Button>("ResetButton").clicked += () => model.ResetRotations();

        // Setup button shows a different screen.  For a more compilcated menu, it would be
        // better to break this out to a separate class (MenuController) who's job is just 
        // showing screens - using a "stack" style of navigation.
        setupScreen = new SetupScreen(root.Q<VisualElement>("SetupScreen"));
        setupScreen.Hide();
        mainRoot.Q<Button>("SetupButton").clicked += () => ShowSetup();
    }

    private void OnDisable()
    {
        GameModel.WasChanged -= RefreshUI;
    }

    private void RefreshUI()
    {
        string displayName = "Player: " + model.UserName;
        mainRoot.Q<Label>("NameLabel").text = displayName;
    }

    private void ShowSetup()
    {
        setupScreen.Show();
    }
}
