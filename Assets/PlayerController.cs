using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    PlayerInput playerInput; //the player input system we're reading from
    InputAction moveInput, fireInput, exitInput;
    public float moveSpeed, rotateSpeed;

    void Awake(){

        playerInput = new PlayerInput();

    }

    void OnEnable(){

        moveInput = playerInput.Player.Move;
        moveInput.Enable();

        fireInput = playerInput.Player.Fire;
        fireInput.Enable();
        fireInput.performed += StartFire;
        fireInput.canceled += StopFire;

        exitInput = playerInput.Player.Exit;
        exitInput.Enable();
        exitInput.performed += Quit;

    }

    void OnDisable(){

        moveInput.Disable();
        fireInput.Disable();
        exitInput.Disable();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 vectorInput = moveInput.ReadValue<Vector2>();

        //Debug.Log("input is " + vectorInput.x + " and " + vectorInput.y);
        transform.Translate(new Vector3 (0, 0, vectorInput.y) * Time.deltaTime * moveSpeed);
        //
        transform.Rotate(new Vector3(0, vectorInput.x, 0) * Time.deltaTime * rotateSpeed);


    }


    void StartFire(InputAction.CallbackContext context){
        
        Debug.Log("pew pew pew");
    }

    void StopFire(InputAction.CallbackContext context)
    {

        Debug.Log("no more pew pew pew");
    }

    void Quit(InputAction.CallbackContext context){


                Debug.Log("Exiting the app ... alt f4");
                Application.Quit();
    }
}
