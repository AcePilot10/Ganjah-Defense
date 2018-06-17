using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTurret : DefenseBase
{

    public GameObject projectile;
    public float projectileSpeed;
    public Transform shootPos;
    public float rotateSpeed;
    public GameObject binObject;

    public override void Fire()
    {
        GameObject obj = Instantiate(projectile) as GameObject;
        obj.transform.position = shootPos.position;
        obj.transform.SetParent(binObject.transform);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = shootPos.forward * projectileSpeed;
    }

    private void RotateToTarget()
    {
        if (currentTarget != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }

    public static Vector3 CalculateInterceptCourse(Vector3 aTargetPos, Vector3 aTargetSpeed, Vector3 aInterceptorPos, float aInterceptorSpeed)
    {
        Vector3 targetDir = aTargetPos - aInterceptorPos;
        float iSpeed2 = aInterceptorSpeed * aInterceptorSpeed;
        float tSpeed2 = aTargetSpeed.sqrMagnitude;
        float fDot1 = Vector3.Dot(targetDir, aTargetSpeed);
        float targetDist2 = targetDir.sqrMagnitude;
        float d = (fDot1 * fDot1) - targetDist2 * (tSpeed2 - iSpeed2);
        if (d < 0.1f)  // negative == no possible course because the interceptor isn't fast enough
            return Vector3.zero;
        float sqrt = Mathf.Sqrt(d);
        float S1 = (-fDot1 - sqrt) / targetDist2;
        float S2 = (-fDot1 + sqrt) / targetDist2;
        if (S1 < 0.0001f)
        {
            if (S2 < 0.0001f)
                return Vector3.zero;
            else
                return (S2) * targetDir + aTargetSpeed;
        }
        else if (S2 < 0.0001f)
            return (S1) * targetDir + aTargetSpeed;
        else if (S1 < S2)
            return (S2) * targetDir + aTargetSpeed;
        else
            return (S1) * targetDir + aTargetSpeed;
    }

    public override void DefenseUpdate()
    {
        RotateToTarget();

    }
}