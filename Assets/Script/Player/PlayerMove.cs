using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    
    [Header("参照")]
    public Transform Camera;

    [Header("移動")]
    public float PlayerSpeed = 5f;

    [Header("回転")]
    public float RotationSpeed = 120f;
    public float CameraRotationSpeed = 80f;

    [Header("アニメーション")]
    //public Animator PlayerAnimator;
    public bool IsMoving { get; private set; }

    /*
    [Header("カメラオフセット")]
    [SerializeField] float CameraHeight = 1f;
    [SerializeField] float CameraDistance = 0f;
    */


    private Rigidbody rb;
    private float cameraRotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //PlayerAnimator = GetComponent<Animator>();

        // 倒れないように固定
        rb.freezeRotation = true;
        // カーソルを非表示にしてロック後で消す
        GameManager.SetCursorState(false);
    }

    void Update()
    {
        RotatePlayer();
        //CameraFollow();
    }

    void FixedUpdate()
    {
        Move();
    }

    // ===== 移動 =====
    void Move()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        { 
              direction += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        { 
              direction -= transform.right;
        }

        Vector3 velocity = direction.normalized * PlayerSpeed;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        IsMoving = direction != Vector3.zero;
        
        
    }

    // ===== 回転 =====
    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * CameraRotationSpeed;

        // プレイヤー左右回転
        transform.Rotate(0f, mouseX * Time.deltaTime, 0f);

        // カメラ上下回転
        cameraRotationX -= mouseY * Time.deltaTime;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -60f, 60f);

        if (Camera != null)
        {
            Camera.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);
        }
    }

    /*
    // ===== カメラ追従 =====
    void CameraFollow()
    {
        if (Camera == null) return;

        Vector3 offset = new Vector3(0f, CameraHeight, CameraDistance);

        Camera.position = transform.position + transform.rotation * offset;
    }
    */
}