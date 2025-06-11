using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 2f, runSpeed = 4f, speed = 0f;
    public float jumpForce = 4f;
    public bool grounded = true;
    public Transform modelMesh;

    private Rigidbody _rb;

    private Vector3 _movementVector, _playerDirection;

    

    private Animator _ani;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _ani = modelMesh.GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Perform a boxcast straight down to see if I'm touching the ground 
        grounded = Physics.BoxCast(transform.position + Vector3.up, Vector3.one * 0.5f, Vector3.down, modelMesh.rotation, 0.7f);

        //flattened versions of the camera's direction. Removing their y-axis from play.
        Vector3 forwardFlat = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 sideFlat = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        //calculation of movementVector using WASD
        _movementVector = (forwardFlat * Input.GetAxis("Vertical")) + (sideFlat * Input.GetAxis("Horizontal"));
        //Normalized to avoid inappropriate speeds (diagonals)
        _movementVector.Normalize();

        /*if (Input.GetMouseButton(1))
        {
            _playerDirection = Vector3.Slerp(_playerDirection, forwardFlat, 5 * Time.deltaTime);
        }*/

        //was just to brag, a ternary operator within a ternary operator
        //Also Rotating player direction towards the movement vector. Locking rotation if RMB is held
        //_playerDirection = Vector3.Slerp(_playerDirection, Input.GetMouseButton(1) ? forwardFlat : _movementVector.magnitude > 0 ? _movementVector : _playerDirection, 5 * Time.deltaTime);
        _playerDirection = Vector3.Slerp(_playerDirection, _playerDirection, 5 * Time.deltaTime);

        modelMesh.rotation = Quaternion.LookRotation(_playerDirection);

        //Jumping if SPACE pressed AND we're grounded
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        //Lerping of SPEED towards 0, walkspeed and runspeed, given condition.
        //MOVE TOWARDS -- lerping with a set step
        if(_movementVector.magnitude > 0)
        {
            speed = Mathf.MoveTowards(speed, Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed, 2 * Time.deltaTime);
        }
        else
        {
            speed = Mathf.MoveTowards(speed, 0, 5 * Time.deltaTime);
        }

        //Animation Updates
        _ani.SetFloat("X", Input.GetAxis("Horizontal"));
        _ani.SetFloat("Z", Input.GetAxis("Vertical"));
        _ani.SetBool("Grounded", grounded);
        
    }

    //Runs to what the fixed Timestep is set, by default it's 0.02 seconds
    void FixedUpdate()
    {
        //use movementvector and speed to calculate my object's movement this FixedUpdate
        //re-apply the object's y velocity to retain gravity.
        _rb.linearVelocity = (_movementVector * speed) + (Vector3.up * _rb.linearVelocity.y);
    }
}
