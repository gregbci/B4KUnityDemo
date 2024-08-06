# B4KDemoApp

## Overview
This is a demo Unity application for the BCI4Kids development team.  It shows how to solve common problems encountered by the team when working in Unity:

* Persisting settings between sessions
* Sharing data and propagating changes
* Separating "game" visualization from application control UI elements (ex: settings)

The demo is a "game" that consists of a spinning cube, controls to change the cube and settings. The Model View Presenter (MVP) architecture is used to separate visualizaion (cube, UI controls) from the actual business logic of the game (state, rules, etc).  This is done to make it easier to share data within the application.  For example, propagating the cube's color setting from a UI element to an actual cube GameObject.

The game elements are: 
* A GameModel (singleton) contains the current state of the cube and provides methods to change it.
* A GamePresenter object observes the model and generates a visualization of the model, in this case, controlling a Cube GameObject.
* The game visualization, the cube, is dumb.  It knows nothing about the game, it's just told what to do by a presenter.

The application elements are:
* MainPresenter changes GameModel based on UI button clicks (rotate, reset, stop)
* SetupPresenter changes GameModel based on chages to the Settings UI, ex: color, user name
* SaveLoadManager initializes GameModel's data (GameData) on startup, saves to disk on shutdown
* The UI is dumb, it is initialized and controlled by the presenters

## Further reading
* [Design Patterns in Unity](https://unity.com/resources/level-up-your-code-with-game-programming-patterns)
* [Unity's UI Toolkit](https://docs.unity3d.com/Manual/UIElements.html)
* [Unity's QuizU demo application](https://discussions.unity.com/t/quizu-managing-menu-screens-in-ui-toolkit/310272) - example is available in the [AssetStore](https://assetstore.unity.com/packages/essentials/tutorial-projects/quizu-a-ui-toolkit-sample-2684920)



