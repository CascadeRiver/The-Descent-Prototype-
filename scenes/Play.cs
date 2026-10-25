using Godot;
using System;

public partial class Play : Button
{
    [Export] public string sceneDirectory = "res://scenes/2d_workspace.tscn";

    void changeScene()
    {
        GetTree().ChangeSceneToFile(sceneDirectory);
    }

    public override void _Pressed()
    {
        changeScene();
    }
}
