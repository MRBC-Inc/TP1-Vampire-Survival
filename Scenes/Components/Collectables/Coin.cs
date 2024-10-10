using Godot;
using System;

public partial class Coin : StaticBody2D
{
	public void Collect(){ 
		QueueFree();
	}
}
