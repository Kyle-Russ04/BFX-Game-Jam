using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementByWill : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    private Rigidbody2D rb;
    public bool player2;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movement;
    private Vector3 LastMove;

    public Animator anim;
    public enum animationState {Idle, Movement}
	public animationState animState;
    public enum facingDirection { Left, Right, Up, Down}
	public facingDirection faceDir;
    public string currentState;
    public string catName;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(!player2)
        {
            moveHorizontal = Input.GetAxis("Horizontal_WASD");
            moveVertical = Input.GetAxis("Vertical_WASD");
        }else
        {
            moveHorizontal = Input.GetAxis("Horizontal_Arrows");
            moveVertical = Input.GetAxis("Vertical_Arrows");
        }

        movement = new Vector3(moveHorizontal, moveVertical, 0f ) * moveSpeed;
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);

        string action = animState == animationState.Idle ? "Idle" : animState == animationState.Movement ? "Walk" : null;
        if (action != null)
        {
            ChangeAnimationState($"{catName}{action}{faceDir}");
        }
    }

    void Update()
    {

        if(movement != new Vector3(0f, 0f, 0f))
        {
            animState = animationState.Movement;
            LastMove = movement;
            faceDir =	LastMove.y >= 0.01f ? facingDirection.Up :
				        LastMove.y <= -0.01f ? facingDirection.Down :
				        LastMove.x >= 0.01f ? facingDirection.Right :
				        LastMove.x <= -0.01f ? facingDirection.Left :
				        faceDir;
        }else
        {
            animState = animationState.Idle;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LeaveGame();
            //allows the player to go back to the home screen
        }
    }

	void ChangeAnimationState(string newState)
	{
		if (currentState == newState) return;

		anim.Play(newState);
		//animLeftHand.Play(newState);
		//animRightHand.Play(newState);
	}

    public void LeaveGame()
    {
        Debug.Log("return to the main menu");
        //debug.log is for developer use
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //changes the scene you are on to the home/ main menu
        Cursor.lockState = CursorLockMode.Confined;
        //stops the cursor from being locked in place on the screen
        //(might not need this but here just in case)
        return;
    }
}
