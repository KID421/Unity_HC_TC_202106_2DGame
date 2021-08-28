using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �ǰe���޲z�G�P�_���a�O�_�i�J�H�Χ������d����
/// </summary>
public class TeleportManager : MonoBehaviour
{
    // 1. �R�A�������O�Ҧ�����@�θ�ơG�Ƽƪ�������A�X�ϥ��R�A
    // 2. �R�A�b���J�����ᤣ�|��_�w�]��
    // 3. �R�A��줣�|��ܦb�ݩʭ��O

    /// <summary>
    /// �Ҧ��Ǫ��ƶq
    /// </summary>
    public static int countAllEnemy;

    // Unity Button ���s�ƥ�ۦ�w�q�覡
    // 1. �ޥ� UnityEngine.Events API
    // 2. �w�q UnityEvent ���
    // 3. �ݭn����ƥ󪺦a��ϥ� Invoke() �I�s
    // 4. �ȭ��I�s�L�ѼƩΤ@�ӰѼƪ���k
    [Header("�L���ƥ�")]
    public UnityEvent onPass;

    private void Start()
    {
        countAllEnemy = GameObject.FindGameObjectsWithTag("�Ǫ�").Length;
    }

    // Ĳ�o�ƥ�GTrigger
    // 1. ��ӸI�����󳣭n�� Collider 
    // 2. �åB�䤤�@�ӭn�� Rigidbody
    // 3. ��Ө䤤�@�Ӧ��Ŀ� Is Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �p�G �i�J�ǰe�����O�D�� �åB �Ǫ��ƶq ���s �N�i�H�L��
        if (collision.name == "�D��" && countAllEnemy == 0)
        {
            onPass.Invoke();
        }
    }
}
