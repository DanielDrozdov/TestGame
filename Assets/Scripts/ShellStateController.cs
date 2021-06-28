using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellStateController : MonoBehaviour
{
    [Header("Base variables")]
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [Header("Secondary variables")]
    [SerializeField] private LayerMask targetPartsLayerMask;
    [SerializeField] private float damageExplosionRadius;
    [SerializeField] private float impulseExplosionRadius;
    [SerializeField] private float explosionForce;
    private float lifeTimeBalance;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        Explode();
        StopAllCoroutines();
        ShellsPoolManager.GetInstance().ReturnObjToPool(this);
    }

    public void SetDirection(Vector3 startPos,Vector3 viewDirection) {
        lifeTimeBalance = lifeTime;
        transform.position = startPos;
        StartCoroutine(MoveCoroutine(viewDirection));
    }

    private IEnumerator MoveCoroutine(Vector3 dir) {
        while(lifeTimeBalance > 0) {
            lifeTimeBalance -= Time.deltaTime;
            transform.Translate(dir * speed * Time.deltaTime);
            yield return null;
        }
        ShellsPoolManager.GetInstance().ReturnObjToPool(this);
    }

    private void Explode() {
        Collider[] damageColliders = Physics.OverlapSphere(transform.position, impulseExplosionRadius, targetPartsLayerMask);
        for(int i = 0;i < damageColliders.Length;i++) {
            if(Vector3.Distance(transform.position, damageColliders[i].transform.position) <= damageExplosionRadius) {
                damageColliders[i].transform.parent = null;
                damageColliders[i].attachedRigidbody.isKinematic = false;
            }
            damageColliders[i].attachedRigidbody.AddExplosionForce(explosionForce, transform.position, impulseExplosionRadius);
        }
    }
}
