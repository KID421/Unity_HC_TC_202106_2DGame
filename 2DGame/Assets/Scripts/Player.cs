using UnityEngine;

public class Player : MonoBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("���D����"), Range(0, 3000)]
    public int jump = 100;
    [Header("��q"), Range(0, 200)]
    public float hp = 100;
    [Header("�O�_�b�a�O�W"), Tooltip("�Ψ��x�s����O�_�b�a�O�W����T�A�b�a�O�W true�B���b�a�O�W false")]
    public bool isGround;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion

    #region �ƥ�
    #endregion

    #region ��k
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���k�ƭ�</param>
    private void Move(float horizontal)
    {

    }

    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {

    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�y�����ˮ`</param>
    public void Hurt(float damage)
    {

    }

    /// <summary>
    /// ���`
    /// </summary>
    private void Dead()
    {

    }

    /// <summary>
    /// �Y�D��
    /// </summary>
    /// <param name="propName">�Y�쪺�D��W��</param>
    private void EatProp(string propName)
    {

    }
    #endregion
}
