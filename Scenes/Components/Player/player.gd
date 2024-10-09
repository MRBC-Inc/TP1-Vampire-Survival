extends CharacterBody2D

const SPEED = 130.0

var rolling = false

var coins = 0
const SAVE_FILENAME = "PlayerSave"

@onready var animated_sprite = $AnimatedSprite2D

func _physics_process(delta):
	$Label.text = str(coins)
	var directionH = Input.get_axis("move_left", "move_right")
	var directionV = Input.get_axis("move_up", "move_down")
	
	if directionH > 0:
		animated_sprite.flip_h = false
	elif directionH < 0:
		animated_sprite.flip_h = true
		
	if !rolling:
		if directionV == 0 and directionH == 0:
			animated_sprite.play("idle")
		else:
			animated_sprite.play("run")
	
	if directionH:
		velocity.x = directionH * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	if directionV:
		velocity.y = directionV * SPEED
	else:
		velocity.y = move_toward(velocity.x, 0, SPEED)

	move_and_slide()
	
func _input(event: InputEvent) -> void:
	if Input.is_action_pressed("roll"):
		animated_sprite.play("roll")
		rolling = true
	
func _ready() -> void:
	Manager.Get().GetSaveManager().LoadGame(SAVE_FILENAME)
	
func _exit_tree() -> void:
	Manager.Get().GetSaveManager().SaveGame(SAVE_FILENAME)
	
func collectCoin() -> void:
	coins += 1


	
func _on_animated_sprite_2d_animation_finished() -> void:
	if animated_sprite.animation == "roll":
		rolling = false
