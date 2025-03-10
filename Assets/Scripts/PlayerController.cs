using UnityEngine;

public class PlayerController : Movement
{
    // Start is called before the first frame update
    private void Start()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
        anim = GetComponent<Animator>();
        this.RigidBody = GetComponent<Rigidbody2D>();
        this.SetControllerType(ControllerType.User);
        this.IsInitialized = true;
        
    }

    void Update()
    {
        if (gameLogic.GameIsActive) ProcessUserInputs();
    }

    private void ProcessUserInputs()
    {
        float deltaX = Input.GetAxisRaw("Horizontal");
        this.MoveRight(deltaX > 0);
        this.MoveLeft(deltaX < 0);

        if (Input.GetKeyDown(KeyCode.Space))
            this.Jump();
    }
}
