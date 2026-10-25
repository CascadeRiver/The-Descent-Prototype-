using Godot;
using System;

public partial class BasicAnimations : AnimatedSprite2D
{
    private Vector2 lastPos;
    private bool verified = false;

    [Export] public string[] animationList = [
    "moving_up", "moving_left", "moving_down", "moving_right"];
    public override void _Ready()
    {
        lastPos = GlobalPosition;
        for (int i = 0; i < animationList.Length; i++)
        {
            if (!SpriteFrames.HasAnimation(animationList[i]))
            {
                return;
            }
        } verified = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!verified) // check if animations are there
        { return; }
        
        var dDistance = (GlobalPosition - lastPos);
        lastPos = GlobalPosition;

        if (dDistance != Vector2.Zero)
        {
            Play();
        }
        else
        {
            Stop();
        }
        
        if (MathF.Abs(dDistance.X) > MathF.Abs(dDistance.Y))
        {
            if (dDistance.X < 0)
            {
                SetAnimation(animationList[1]);
                return;
            } SetAnimation(animationList[3]);
        }
        else if ((MathF.Abs(dDistance.X) < MathF.Abs(dDistance.Y)))
        {
            if (dDistance.Y < 0)
            {
                SetAnimation(animationList[0]);
                return;
            } SetAnimation(animationList[2]);
        }
    }
}
