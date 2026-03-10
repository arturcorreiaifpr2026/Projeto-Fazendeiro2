using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 20f;
    public GameObject projectilePrefab;
    private float horizontalInput;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pressPause;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;  //imput SYSTEM daqui para frente. NUNCA USAR IMPUT 
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        // dispara comida ao pressionar barra de espa�o
        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if (pressPause.WasPressedThisFrame())
        {
           // Instantiate(//CANVA, CAMINHO DE RETORNO)
        }
        
    }

    // public void MoveEvent(InputAction.CallbackContext context)
    // {
    //     horizontalInput = context.ReadValue<Vector2>().x;
    // }

    // public void FireEvent(InputAction.CallbackContext context)
    // {
    //     if (context.performed)// se n especificar, atira no começo, meio e fim
    //     Debug.Log("peipei");
    //      Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    // }

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("fire");
        pressPause = InputSystem.actions.FindAction("Pause");
    } 
}
