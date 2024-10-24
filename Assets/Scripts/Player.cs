using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool estaVivo;
    [SerializeField] private int forcaPulo;
    [SerializeField] private int ouro;
    [SerializeField] private int vida;
    [SerializeField] private float velocidade;
    [SerializeField] private bool temChave;
    [SerializeField] private bool pegando;
    [SerializeField] private List<GameObject> inventario = new List<GameObject>();
    private Rigidbody rb;
    private bool estaPulando;
    private Vector3 angleRotation;
    private bool podePegar;
    // Start is called before the first frame update
    void Start()
    {
        angleRotation = new Vector3(0, 90, 0);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnAroud();

        //Andar
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andando", true);
            animator.SetBool("AndarPraTras", false);
            Walk();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarPraTras", true);
            animator.SetBool("Andando", false);
            Walk();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Andando", false);
        }
        else
        {
            animator.SetBool("Andando", false);
            animator.SetBool("AndarPraTras", false);
        }
        //Pulo
        if (Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            animator.SetTrigger("Pular");
            Jump();
        }
    }

    private void Walk(float velo = 1)
    {
        if ((velo == 1))
        {
            velo = velocidade;
        }
        float fowardInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * fowardInput;
        Vector3 moveForward = rb.position + moveDirection * velo * Time.deltaTime;
        rb.MovePosition(moveForward);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        estaPulando = true;
        animator.SetBool("EstarNoChao", false);
    }

    private void TurnAroud()
    {
        float sideInput = Input.GetAxis("Horizontal");
        Quaternion deltaRotation = Quaternion.Euler(angleRotation * sideInput * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}
