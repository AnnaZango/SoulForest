using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject impactVFX;
    [SerializeField] GameObject damageEnemtVFX;
    [SerializeField] float speed = 20;
    [SerializeField] float damageBullet = 3;
    [SerializeField] bool isExplosive = false;
    [SerializeField] float rangeDamage = 5;
    private float timeToDestroy = 5;
    private MeshRenderer bulletRenderer;
    
    bool hitHappened = false;

    public Vector3 target { get; set; }

    public IDamageable damageableElement { get; set; }

    private void Awake()
    {
        bulletRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy); //just in case..!
    }
        

    private void OnDrawGizmos() //debugging purposes
    {
        if(isExplosive)
        {
            Gizmos.DrawWireSphere(transform.position, rangeDamage);
        }
    }

    void Update()
    {
        if (hitHappened) { return; }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, target) < 0.001f) 
        {            
            if (isExplosive)
            {
                ExplosionDamage(transform.position, rangeDamage);
            }
            else
            {
                ContactDamage();
            }
            GameObject vfx = Instantiate(impactVFX, transform.position, Quaternion.identity);

            DestroyDelayed();
        }
    }

    private void ContactDamage()
    {
        if (damageableElement != null) //set by PlayerShooting
        {
            GameObject vfxDamage = Instantiate(damageEnemtVFX, transform.position, Quaternion.identity);
            damageableElement.ReceiveDamage(damageBullet);
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.GetComponent<IDamageable>() != null)
            {
                IDamageable damageableElement = hitCollider.gameObject.GetComponent<IDamageable>();
                GameObject vfxDamage = Instantiate(damageEnemtVFX, hitCollider.gameObject.transform.position, Quaternion.identity);
                damageableElement.ReceiveDamage(damageBullet);
            }
        }
    }

    private void DestroyDelayed()
    {
        bulletRenderer.enabled = false;
        hitHappened = true;
        Destroy(gameObject, 1f);
    }

}
