using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class carControler : MonoBehaviour
{
    [SerializeField] private float m_MovmentFactor = 0.1f;
    [SerializeField] private float m_MovmentFactorForward = 0.1f;
    [SerializeField] private float m_RotationFactor = 0.01f;
    [SerializeField] private float m_PokerFactor = 80f;
    [SerializeField] private float m_shotFactor = 80f;

    [SerializeField] private GameObject m_enemyRefence;
    [SerializeField] private Text m_coinsCounterToScreen;
    private int m_coinsCounter;

    private Transform player;
    private Rigidbody playerRig;
    private CharacterController controller;
    private static bool m_isDead = false;
    private int m_numOfCollision = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = transform;
        playerRig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDead)
            return;
        CheckInputs();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
        if (collision.gameObject.tag == "coin")
        {
            m_numOfCollision++;
            m_coinsCounterToScreen.text = m_numOfCollision.ToString();
            Object.Destroy(collision.gameObject);
        }
    }

    private void Death()
    {
        m_isDead = true;
    }

    private void CheckInputs()
    {
        player.position += player.forward * m_MovmentFactorForward;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.position += player.right * m_MovmentFactor;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.position -= player.right * m_MovmentFactor;
        }
    }
    public static bool IsDead
    {
        get 
        {
            return m_isDead;
        }
    }
}
