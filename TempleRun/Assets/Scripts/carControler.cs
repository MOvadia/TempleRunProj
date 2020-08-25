using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControler : MonoBehaviour
{
    [SerializeField] private float m_MovmentFactor = 0.1f;
    [SerializeField] private float m_JumpFactor = 80f;
    [SerializeField] private float m_RotationFactor = 0.01f;
    [SerializeField] private float m_PokerFactor = 80f;
    [SerializeField] private float m_shotFactor = 80f;

    private Transform player;
    private Rigidbody playerRig;

    private Vector3 m_lastMousePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = transform;
        playerRig = gameObject.GetComponent<Rigidbody>();
        m_lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
        m_lastMousePos = Input.mousePosition;


    }

    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.position += player.forward * m_MovmentFactor;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.position -= player.forward * m_MovmentFactor;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.position += player.right * m_MovmentFactor;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.position -= player.right * m_MovmentFactor;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRig.AddForce(player.up * m_JumpFactor);
        }

    }
}
