using Godot;
using System;

[GlobalClass]
public partial class CharacterControl : Node
{
	[Export] private int WalkSpeed = 10; //in godot x units/delta or smth idk??
	[Export] private int JumpHeight = 10; //in godot y units
	[Export] private int Health = 50;
	[Export] private int MaxHealth = 50;

	private bool isHPmicro;

	private void correctHealth()
	{
		isHPmicro = Health < 0 ? true : false;
		if (isHPmicro)
		{
			Health = 0;
			return;
		}
		Health = MaxHealth;
		return;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (Health < 0 || Health > MaxHealth)
		{
			correctHealth();
		}
	}

	public void TakeDamage(int damage) 
	{
		Health -= damage;
	}

	public void ChangeSpeed(int speed)
	{
		WalkSpeed = speed;
	}
	
}
