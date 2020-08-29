using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Text m_TimerUI;

    private float m_timer = 0f;
    private int m_timerBeuty = 0;

    [SerializeField] private GameObject m_enemyRefence;

    [SerializeField] private List<GameObject> m_enemies;

    [SerializeField] private Vector3 deltaPos;

    [SerializeField] private float ClonesPerSec;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        time += Time.deltaTime;

        if (time > (1f / ClonesPerSec))
        {
            GameObject tempObj = Instantiate(m_enemyRefence,
                transform.position + new Vector3(Random.Range(-1f, 1f), 0f, 0f),
                Quaternion.identity);
            //tempObj.transform.SetParent(transform);
            m_enemies.Add(tempObj);

            Destroy(tempObj,20f);

            time -= (1f / ClonesPerSec);

            for (int i = 0; i < m_enemies.Count; i++)
            {
                if (m_enemies[i] == null)
                {
                    m_enemies.RemoveAt(i);
                }
            }
        }

        foreach (GameObject obj in m_enemies)
        {
            if (obj != null)
            {
                obj.transform.position += deltaPos;
            }
        }
    }

    private void UpdateTimer()
    {
        m_timer += Time.deltaTime;
        string minutes = ((int)m_timer / 60).ToString();
        string seconds = (m_timer % 60).ToString("f2");
        m_TimerUI.text = minutes + ":" + seconds;
    }
}
