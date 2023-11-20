using Godot;
using System;

public class AudioPositionDemo : Node2D
{
    private KinematicBody2D _audioIcon;
    private AudioStreamPlayer2D _audioStream;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _audioIcon = GetNode<KinematicBody2D>("AudioIconPosition");
        _audioStream = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        _audioStream.Position = _audioIcon.Position;        
    }
}
