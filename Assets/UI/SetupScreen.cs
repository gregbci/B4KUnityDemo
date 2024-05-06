using UnityEngine;
using UnityEngine.UIElements;

public class SetupScreen
{
    private GameModel model;
    private VisualElement root;

    public SetupScreen(VisualElement setupRoot)
    {
        model = GameModel.Instance;
        root = setupRoot;
        root.Q<Button>("DoneButton").clicked += () => Hide();
        
        TextField nameField = root.Q<TextField>("PlayerNameField");
        nameField.value = model.UserName;
        nameField.RegisterValueChangedCallback(NameFieldChanged);
    }

    private void NameFieldChanged(ChangeEvent<string> evt)
    {
        model.SetName(evt.newValue);
    }

    public void Show()
    {
        root.style.display = DisplayStyle.Flex;
        root.style.visibility = Visibility.Visible;
    }

    public void Hide()
    {
        root.style.display = DisplayStyle.None;
        root.style.visibility = Visibility.Hidden;
    }
}
