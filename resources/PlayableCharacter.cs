using Godot;
using System;

[GlobalClass]
public partial class PlayableCharacter : CharacterBody2D
{
	[Export] public int walkSpeed = 50; // in units per second

	[Export] public AudioStreamPlayer2D audioPlayer = null;

	private bool audioDebounce = false;
	/*
	public override void _Ready()
	{
		
	}
	*/
	Single boolToInt (bool param) // function for simple WASD comparing on input
	{
		return param ? 1 : 0;
	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;
		
		velocity = new Vector2(
			boolToInt(Input.IsActionPressed("RightKey")) - boolToInt(Input.IsActionPressed("LeftKey")),
			0.8f*(boolToInt(Input.IsActionPressed("DownKey")) - boolToInt(Input.IsActionPressed("UpKey")))
		);

		if (velocity != Vector2.Zero)
		{
			if (!audioDebounce)
			{
				audioDebounce = true;
				audioPlayer.Play();
			}
		}
		else
		{
			audioDebounce = false;
			audioPlayer.Stop();
		}
		MoveAndCollide(velocity.Normalized() * walkSpeed * (float)delta);
	}
}
