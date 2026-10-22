
using Godot;

public partial class Player : CharacterBody3D
{
    [Export] public float MoveSpeed = 5.0f;

    private Camera3D camera;

    public override void _Ready()
    {
        camera = GetNode<Camera3D>("SpringArm3D/Camera3D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 input = Input.GetVector("move_left", "move_right","move_forward", "move_backward");

        Vector3 forward = -camera.GlobalBasis.Z;
        Vector3 right = camera.GlobalBasis.X;

        forward.Y = 0;
        right.Y = 0;

        forward = forward.Normalized();
        right = right.Normalized();

        Vector3 direction = right * input.X - forward * input.Y;

        Velocity = direction * MoveSpeed;

        MoveAndSlide();
    }
}
