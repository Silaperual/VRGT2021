using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Matster : MonoBehaviour
{
    [SerializeField]
    Slider hpSlider;
    Vector3[] path;
    int currentPathIndex;
    Animator m_animator;
    NavMeshAgent m_NavAgent; 
    public int MaxHp { get { return GameManager.MasterMaxHp; }  }
    int hp;
    public int Hp { get { return hp; }set { hp = value; m_animator.SetInteger("hp", value);
            hpSlider.value = value;
            if (hp<=0)
            {
                Destroy(gameObject);
                GameManager.Init.Scure += 100;
            }
        } }

    public bool IsRun { get { return  !m_NavAgent.isStopped; }set { m_NavAgent.isStopped = !value; m_animator.SetBool("isRun", value); } }
    private void Awake()
    {
        hpSlider.maxValue = MaxHp;
        hpSlider.minValue = 0; 
        m_animator = GetComponent<Animator>();
        m_NavAgent = GetComponent<NavMeshAgent>();
        Hp = MaxHp;
   
    }
    // Start is called before the first frame update
    float timeCount=0;
    private void Update()
    {
        float dist = 0f; //距离目的地的距离 
        if (IsRun&&path!=null&&path.Length>=1)
        {
        
            Vector3 v = path[currentPathIndex];
            m_NavAgent.SetDestination(v);
            if (m_NavAgent.pathPending)
            {
                dist = Vector3.Distance(transform.position, v); 
            }
            else
            {
                dist = m_NavAgent.remainingDistance;
            } 
            if (dist <= m_NavAgent.stoppingDistance)
            {
                if (currentPathIndex<path.Length-1)
                {
                    currentPathIndex++;
                }
                else
                {
                    IsRun = false;
                    Destroy(this.gameObject);
                    try
                    {
                        m_NavAgent.ResetPath();
                    }
                    catch (System.Exception)
                    {
                         
                    }
                 
                }
            }
            else
            {
                timeCount+=Time.deltaTime;
                if (timeCount>6)
                {
                    Pause();
                    timeCount = 0;
                }
            }
        } 
    }
    IEnumerator Pause()
    {
        IsRun = false;
        int random= Random.Range(0, 1);
        m_animator.SetTrigger(random==0?"levelUp":"digLoop");
        yield return new WaitForSeconds(4);
        m_animator.SetTrigger(random == 0 ? "levelUp" : "digLoop");
        IsRun = true;
    }
    public void SetPos(params Vector3 [] vector3)
    {
        path = vector3;
        currentPathIndex = 0;
        m_NavAgent.ResetPath();
        IsRun = true;
    }
}
