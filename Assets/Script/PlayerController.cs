using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stamina")]
    [Tooltip("�÷��̾ �޸� �� �ִ� �ִ� �ð� (�� ����)")]
    [SerializeField] 
    private float runDuration = 7f;
    [Tooltip("Ȱ�� ��� �� �ִ� �ִ� �ð� (�� ����)")]
    [SerializeField] 
    private float drawDuration = 5f;

    private Status status;
    private float runCost => status.MaxStamina / runDuration;
    private float drawCost => status.MaxStamina / drawDuration;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk;
    [SerializeField] 
    private AudioClip audioClipRun;


    private RotateCamera _rotateCamera;
    private MovementCharacterController _movementCharacterController;
    private PlayerAnimatorController animator;
    private AudioSource audioSource;
    //private Bow bow;
    private bool onBow = false;

    bool running; // �޸��°�?


    private void Awake()
    {
        //���콺 Ŀ���� ������ �ʰ� �����ϰ� ���� ��ġ�� ����
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _rotateCamera = GetComponent<RotateCamera>();
        _movementCharacterController = GetComponent<MovementCharacterController>();

        status = GetComponent<Status>();
        status.OnDeath += Die; // ��� �̺�Ʈ ����

        animator = GetComponent<PlayerAnimatorController>();    
        audioSource = GetComponent<AudioSource>();
        //bow = GetComponentInChildren<Bow>();
    } 

    // Update is called once per frame
    void Update()
    {
        running = UpdateMove(); 
        //bool holding = UpdateBowAction();
        UpdateRotate();
        UpdateJump();

        if (!running) // ��� ���� ���� ���� && !holding
        {
            status.RecoverStamina();
        }
        if(status.CurrentHp == 0)
        {
            //status.ReduceHp(0f);
        }
    }

    private void UpdateRotate()
    {
        float cameraX = Input.GetAxis("Mouse X");
        float cameraY = Input.GetAxis("Mouse Y");

        _rotateCamera.UpdateRotate(cameraX, cameraY);
    }

    private bool UpdateMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // �޸��� ����: ������ �̵� ���̰� Run Ű ����
        bool isTryingToRun = z > 0 && Input.GetKey(KeyCode.LeftShift);

        // ���� ���¹̳��� �޸� �� ���� ��ŭ ���� �ִ°�?
        bool hasStamina = status.CurrentStamina > 0f;

        // ���������� �޸� �� �ִ°�?
        bool isRun = isTryingToRun && hasStamina;

        //�̵� �� �� �� (�ȱ� or �ٱ�)
        if (x != 0 || z != 0)
        {
            _movementCharacterController.MoveSpeed = (isRun == true) ? status.RunSpeed : status.WalkSpeed;
            animator.MoveSpeed = (isRun == true) ? 1 : 0.5f;
            audioSource.clip = (isRun == true) ? audioClipRun : audioClipWalk;
            
            if(audioSource.isPlaying == false)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            _movementCharacterController.MoveSpeed = 0;
            animator.MoveSpeed = 0;

            if(audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }
        }

        _movementCharacterController.MoveTo(new Vector3(x,0,z));

        if (isRun == true)
        {
            status.UseStamina(runCost); // ���׹̳� �Ҹ�(�ٱ�)
            return true; // ��� ȸ�� �Ұ�(�ٱ�)
        }
        
        return false; // ��� ȸ�� ����(�ȱ�, ����)
    }

    private void UpdateJump() 
    {
        if(Input.GetButtonDown("Jump"))
        {
            _movementCharacterController.Jump();
        }
    }

    private bool UpdateBowAction()
    {
        

        if (animator.BowState > 0.5f)
        {
            status.UseStamina(drawCost);
            return true; // ��� ȸ�� �Ұ�
        }
        return false; // ��� ȸ�� ����(animator.BowState <= 0.5f)
    }

    private void Die()
    {
        Debug.Log("�÷��̾� ���1");
        GameManager_JS.instance.RespawnPlayer(this.gameObject);
    }

    private void OnDestroy()
    {
        if (status != null)
            status.OnDeath -= Die; // ���� ���� (�޸� ���� ����)
    }
}
