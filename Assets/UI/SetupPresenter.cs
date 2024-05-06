using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SetupPresenter
{
    private GameModel model;
    private VisualElement root;

    public SetupPresenter(VisualElement setupRoot)
    {
        model = GameModel.Instance;
        root = setupRoot;
        root.Q<Button>("DoneButton").clicked += () => Hide();

        TextField nameField = root.Q<TextField>("PlayerNameField");
        nameField.value = model.UserName;
        nameField.RegisterValueChangedCallback(NameFieldChanged);

        DropdownField colorDropdown = root.Q<DropdownField>("CubeColor");
        colorDropdown.value = model.CubeColorName;
        colorDropdown.choices = model.CubeColorNames;
        colorDropdown.RegisterValueChangedCallback(ColorDropdownChanged);
    }

    private void NameFieldChanged(ChangeEvent<string> evt)
    {
        model.SetUserName(evt.newValue);
    }

    private void ColorDropdownChanged(ChangeEvent<string> evt)
    {
        model.SetCubeColor(evt.newValue);
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
