using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private bool estaVivo;
    [SerializeField] private int forcaPulo;
    [SerializeField] private int ouro;
    [SerializeField] private int vida;
    [SerializeField] private float velocidade;
    [SerializeField] private bool temChave;
    [SerializeField] public bool pegando;
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
        //Pegar
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Pegando");
            pegando = true;
        }
        //Andar
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar", true);
            animator.SetBool("AndarPraTras", false);
            Walk();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarPraTras", true);
            animator.SetBool("Andar", false);
            Walk();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Andar", false);
        }
        else
        {
            animator.SetBool("Andar", false);
            animator.SetBool("AndarPraTras", false);
        }
        //Pulo
        if (Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            animator.SetTrigger("Pular");
            Jump();
        }
        if (!estaVivo)
        {
            animator.SetTrigger("EstaVivo");
            estaVivo = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Correr", true);
            Walk(8);
        }
        else
        {
            animator.SetBool("Correr", false);
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
        animator.SetBool("EstaNoChao", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaPulando = false;
            animator.SetBool("EstaNoChao", true);
        }
        if (collision.gameObject.CompareTag("Bau"))
        {
            Debug.Log("Aperte a Tecla E");
        }

    }

    private void TurnAroud()    
    {
        float sideInput = Input.GetAxis("Horizontal");
        Quaternion deltaRotation = Quaternion.Euler(angleRotation * sideInput * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation );   
    }

    

}
