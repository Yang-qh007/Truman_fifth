using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Ҫ�����Ŀ�꣨ͨ������ң�")]
    public Transform target;

    // 
    [Header("�����Ŀ��֮���ƫ����")]
    public Vector3 offset = new Vector3(0, 0, -10);

    // 
    //[Header("ƽ�����ӣ�ֵԽ��Խ�����")]
    private float smoothSpeed = 20f;

    /*// 
    [Header("����߽�����")]
    public Vector2 minPosition;
    public Vector2 maxPosition;*/

    private void LateUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        // ����Ŀ��λ��
        Vector3 desiredPosition = target.position + offset;

     /*   // Ӧ�ñ߽����ƣ���������ˣ�
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);*/

        // ƽ���ƶ���Ŀ��λ��
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // �������λ��
        transform.position = smoothedPosition;
    }

    // ��ѡ�������ⲿ����Ŀ��
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}