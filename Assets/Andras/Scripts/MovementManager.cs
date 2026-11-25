using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private bool isWalking;
    public bool thisSceneWalk;
    [SerializeField] private MonoBehaviour swimmingMovement;
    [SerializeField] private MonoBehaviour walkingMovement;

    public Rigidbody2D player;

    private void Start()
    {
        if (thisSceneWalk)
        {
            SwitchToWalking();
        }
    }

    public void SwitchToWalking()
    {
        player.gravityScale = 5;
        player.freezeRotation = true;
        swimmingMovement.enabled = false;
        walkingMovement.enabled = true;
        isWalking = true;
    }

    public void SwitchToSwimming()
    {
        player.gravityScale = 0;
        player.freezeRotation = false;
        swimmingMovement.enabled = true;
        walkingMovement.enabled = false;
        isWalking = false;
    }
}
