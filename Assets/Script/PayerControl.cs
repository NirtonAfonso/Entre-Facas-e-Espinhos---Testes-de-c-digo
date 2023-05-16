using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PayerControl : MonoBehaviour
{
    private Vector3 direcao;
    public float moveSpeed = 3;
    private float moveSpeedRunning;
    private Rigidbody rb;
    public float jumpForce = 3;
    private Animator animator;
    private bool isGround = false;
    private bool isRunning = false;

    public Transform orientation;
    private int coletavel;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        moveSpeedRunning = moveSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxisRaw("Horizontal");
        float eixoZ = Input.GetAxisRaw("Vertical");
        //direcao = new Vector3(eixoX, 0, eixoZ);
        direcao = orientation.forward * eixoZ + orientation.right * eixoX;

        if (direcao != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direcao);
            animator.SetBool("walking", true);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!isRunning)
                {
                    animator.SetBool("runnig", true);

                    moveSpeedRunning = moveSpeed * 2;
                    isRunning = true;
                }
                else
                {
                    animator.SetBool("runnig", false);

                    moveSpeedRunning = moveSpeed;
                    isRunning = false;

                }
            }
        }
        else
        {
            animator.SetBool("walking", false);
            animator.SetBool("runnig", false);
            isRunning = false;
            moveSpeedRunning = moveSpeed;
        }

        //rb.AddForce(direcao * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            //animator.SetTrigger("jump");
            animator.SetBool("jump", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
        else
        {
            animator.SetBool("jump", false);

        }





    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position +
            (direcao * moveSpeedRunning * Time.deltaTime));

    }

    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }

   /* public void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.CompareTag("Coletavel")))
        {
            Destroy(collider.gameObject);
            coletavel++;
            Debug.Log("Coletouuuuuu" + "\nQuantidade Coletaveis: " + coletavel);
        }
    }
   */

}
