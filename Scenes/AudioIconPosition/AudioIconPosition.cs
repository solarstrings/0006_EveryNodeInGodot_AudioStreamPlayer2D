using Godot;
using System;

public class AudioIconPosition : KinematicBody2D
{
    [Export]
    public float MaxSpeed = 450;                // The max movement speed
    [Export]
    public float Acceleration = 1600;           // Movement accelleration
    [Export]
    public float Friction = 0.2f;               // Friction for interpolating the speed down to zero  
    private Vector2 _velocity = Vector2.Zero;   // The velocity 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    private void MoveAudioIcon(float delta)
    {
        var inputVector = Vector2.Zero;                                                             // Initialize the input vector to zero
        inputVector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");   // Get the horizontal input strength
        inputVector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");      // Get the vertical input strength
        inputVector.Normalized();                                                                   // Normalize the lenght of the input vector

        // If the Audio icon is not moving
        if (inputVector == Vector2.Zero)
        {
            _velocity = _velocity.LinearInterpolate(Vector2.Zero, Friction);    // Interpolate the speed towards 0
        }
        // If the audio icon is moving
        else
        {
            _velocity += inputVector * Acceleration * delta;    // Calculate the velocity
            _velocity = _velocity.LimitLength(MaxSpeed);        // Limit velocity to max speed
        }
        _velocity = MoveAndSlide(_velocity);                    // Update movement with Godot's in-built move and slide method
    }  

    public override void _PhysicsProcess(float delta)
    {
        MoveAudioIcon(delta);  // move the audio icon
    }
}
