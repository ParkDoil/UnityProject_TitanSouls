using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
    public float Speed;
    public GameObject WeakPoint;
    public ParticleSystem HitEffect;

    ObjectManager _objectManager;
    GameObject _player;
    Rigidbody2D _rigid;
    Animator _animator;

    private bool IsLeft;
    private bool IsDead;
    private bool IsStart;

    public bool IsShootArc;

    private int _patternIndex;
    private int _patternCount;
    
    public int[] _maxPattern;
    Vector2 _firstPosition;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        _firstPosition = transform.position;
    }

    void Update()
    {
        _rigid.velocity = Vector2.zero;

        if (WeakPoint.GetComponent<WeakPoint>().IsHit == true)
        {
            IsDead = true;

            _animator.SetTrigger(BossAnimID.DIE);

            //HitEffect.transform.position = WeakPoint.transform.position;
            //HitEffect.transform.rotation = WeakPoint.transform.rotation;
            //HitEffect.Play();

            Invoke("Die", 1.5f);
        }

        if (IsDead == false && IsShootArc == false)
        {
            Move();
            if (IsStart == false)
            {
                IsStart = true;
                Invoke("Think", 2f);
            }
        }
    }
    void Move()
    {
        Vector2 MoveVec = Vector2.right * Speed;
        if (IsLeft == true)
        {
            _rigid.AddForce(-MoveVec);

            if (transform.position.x <= -16f)
            {
                IsLeft = false;
            }
        }
        else
        {
            _rigid.AddForce(MoveVec);

            if (transform.position.x >= 7f)
            {
                IsLeft = true;
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Think()
    {
        if(IsDead == true)
        {
            return;
        }

        _patternIndex = _patternIndex == 3 ? 0 : _patternIndex + 1;
        _patternCount = 0;
        switch (_patternIndex)
        {
            case 0:
                FireFoward();
                break;
            case 1:
                FireToPlayer();
                break;
            case 2:
                FireArc();
                break;
            case 3:
                FireAround();
                break;
        }

    }

    void FireFoward()
    {
        if (IsDead == true)
        {
            return;
        }

        GameObject _bulletR = _objectManager.MakeObj("BossBulletB");
        _bulletR.transform.position = transform.position + Vector3.right * 0.4f; GameObject _bulletRR = _objectManager.MakeObj("BossBulletB");
        _bulletRR.transform.position = transform.position + Vector3.right * 1.2f; GameObject _bulletL = _objectManager.MakeObj("BossBulletB");
        _bulletL.transform.position = transform.position + Vector3.left * 0.4f; GameObject _bulletLL = _objectManager.MakeObj("BossBulletB");
        _bulletLL.transform.position = transform.position + Vector3.left * 1.2f;

        Rigidbody2D _rigidBulletR = _bulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D _rigidBulletRR = _bulletRR.GetComponent<Rigidbody2D>();
        Rigidbody2D _rigidBulletL = _bulletL.GetComponent<Rigidbody2D>();
        Rigidbody2D _rigidBulletLL = _bulletLL.GetComponent<Rigidbody2D>();

        _rigidBulletR.AddForce(Vector2.down * 20, ForceMode2D.Impulse);
        _rigidBulletRR.AddForce(Vector2.down * 20, ForceMode2D.Impulse);
        _rigidBulletL.AddForce(Vector2.down * 20, ForceMode2D.Impulse);
        _rigidBulletLL.AddForce(Vector2.down * 20, ForceMode2D.Impulse);

        ++_patternCount;

        if(_patternCount < _maxPattern[_patternIndex])
        {
            Invoke("FireFoward", 1.1f);
        }
        else
        {
            Invoke("Think", 3f);
        }
    }
    void FireToPlayer()
    {
        if (IsDead == true)
        {
            return;
        }

        for (int i = 0; i < 5; ++i)
        {
            GameObject bullet = _objectManager.MakeObj("BossBulletA");
            bullet.transform.position = transform.position;

            Rigidbody2D _rigidBullet = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = _player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-3f, 3f), Random.Range(0f, 2f));
            dirVec = dirVec + ranVec;
            _rigidBullet.AddForce(dirVec.normalized * 20, ForceMode2D.Impulse);
        }


        ++_patternCount;
        if (_patternCount < _maxPattern[_patternIndex])
        {
            Invoke("FireToPlayer", 2.4f);
        }
        else
        {
            Invoke("Think", 3f);
        }
    }
    void FireArc()
    {
        if (IsDead == true)
        {
            return;
        }
        IsShootArc = true;
        transform.position = _firstPosition;

        GameObject bullet = _objectManager.MakeObj("BossBulletA");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D _rigidBullet = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 15f * (float)_patternCount / _maxPattern[_patternIndex]), -1f);
        _rigidBullet.AddForce(dirVec.normalized * 25, ForceMode2D.Impulse);

        ++_patternCount;

        if (_patternCount < _maxPattern[_patternIndex])
        {
            Invoke("FireArc", 0.1f);
        }
        else
        {
            IsShootArc = false;
            Invoke("Think", 3f);
        }
    } 
    void FireAround()
    {
        if (IsDead == true)
        {
            return;
        }
        int roundNumA = 40;
        int roundNumB = 30;
        int roundNum = _patternCount % 2 == 0 ? roundNumA : roundNumB;

        for(int i=0;i<roundNum;++i)
        {
            GameObject _bullet = _objectManager.MakeObj("BossBulletA");
            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D _rigidBullet = _bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2f * i /roundNum), Mathf.Sin(Mathf.PI * 2f * i / roundNum));
            _rigidBullet.AddForce(dirVec.normalized * 7, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * i / roundNum + Vector3.forward * 90;
            _bullet.transform.Rotate(rotVec);
        }

        ++_patternCount;
        if (_patternCount < _maxPattern[_patternIndex])
        {
            Invoke("FireAround", 1.2f);
        }
        else
        {
            Invoke("Think", 3f);
        }
    }
}
