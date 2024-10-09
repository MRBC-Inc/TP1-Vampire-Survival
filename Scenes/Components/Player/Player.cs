using Godot;
using System;
using static Manager;

public partial class Player : CharacterBody2D
{
	private const float SPEED = 130.0f;
	private bool rolling = false;
	private int coins = 0;
	private const string SAVE_FILENAME = "PlayerSave";

	[Export]
	private Label label;

	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Manager.Get().GetSaveManager().LoadGame(SAVE_FILENAME);
	}

	public override void _ExitTree()
	{
		Manager.Get().GetSaveManager().SaveGame(SAVE_FILENAME);
	}

	public override void _PhysicsProcess(double delta)
	{
		// Update coin label
		label.Text = coins.ToString();

		float directionH = Input.GetAxis("move_left", "move_right");
		float directionV = Input.GetAxis("move_up", "move_down");

		// Handle sprite flipping
		if (directionH > 0)
		{
			animatedSprite.FlipH = false;
		}
		else if (directionH < 0)
		{
			animatedSprite.FlipH = true;
		}

		// Handle animations
		if (!rolling)
		{
			if (directionH == 0 && directionV == 0)
			{
				animatedSprite.Play("idle");
			}
			else
			{
				animatedSprite.Play("run");
			}
		}

		// Handle movement
		Vector2 velocity = Velocity;
		if (directionH != 0)
		{
			velocity.X = directionH * SPEED;
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, SPEED);
		}

		if (directionV != 0)
		{
			velocity.Y = directionV * SPEED;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(velocity.Y, 0, SPEED);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionPressed("roll"))
		{
			animatedSprite.Play("roll");
			rolling = true;
		}
	}

	private void _OnAnimatedSprite2DAnimationFinished()
	{
		if (animatedSprite.Animation == "roll")
		{
			rolling = false;
		}
	}

	public void CollectCoin()
	{
		coins += 1;
	}
}
