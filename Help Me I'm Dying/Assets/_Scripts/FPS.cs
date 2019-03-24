using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    private float speed = 7.5f;

    public int level = 0; 

    private float m_MovX;
    private float m_MovY;
    private Vector3 m_moveHorizontal;
    private Vector3 m_moveVertical;
    private Vector3 m_velocity;
    private Rigidbody m_rigid;
    private float m_yRot;
    private float m_xRot;
    private Vector3 m_rotation;
    private Vector3 m_cameraRotation;
    private float m_lookSensitivity = 3.0f;
    private bool m_cursorIsLocked = true;

    private float y;
    bool isGrounded;

    private Camera m_Camera;

    // Use this for initialization
    void Awake() {
        SavePlayer();
        Cursor.lockState = CursorLockMode.Locked;
        m_rigid = GetComponent<Rigidbody>();
        m_Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        if (m_rigid)
        {
            y = Input.GetAxis("Jump") * 2;

            if (isGrounded && y != 0)
            {
                transform.Translate(0, y, 0);
                isGrounded = false;
            }
            m_MovX = Input.GetAxis("Horizontal");
            m_MovY = Input.GetAxis("Vertical");

            m_moveHorizontal = transform.right * m_MovX;
            m_moveVertical = transform.forward * m_MovY;

            m_velocity = (m_moveHorizontal + m_moveVertical).normalized * speed;

            //mouse movement
            m_yRot = Input.GetAxisRaw("Mouse X");
            m_rotation = new Vector3(0, m_yRot, 0) * m_lookSensitivity;

            m_xRot = Input.GetAxisRaw("Mouse Y");
            m_cameraRotation = new Vector3(m_xRot, 0, 0) * m_lookSensitivity;

            if (m_velocity != Vector3.zero && EnemyMovement.DialogueIsFinished)
            {
                m_rigid.MovePosition(m_rigid.position + m_velocity * Time.fixedDeltaTime);
            }
            if (m_rotation != Vector3.zero && EnemyMovement.DialogueIsFinished)
            {
                m_rigid.MoveRotation(m_rigid.rotation * Quaternion.Euler(m_rotation));
            }
            if (m_Camera != null && EnemyMovement.DialogueIsFinished)
            {
                m_Camera.transform.Rotate(-m_cameraRotation);
            }

        }
        //InternalLockUpdate();
    }

        private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            UnlockCursor(); 
        }
        else if (!m_cursorIsLocked)
        {
            LockCursor();
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Saved");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();

        Changeable.level = data.level;

        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //transform.position = position;

        Debug.Log("Loaded");
    }
}
