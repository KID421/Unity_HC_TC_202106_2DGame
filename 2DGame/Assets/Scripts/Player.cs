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

    // �p�H��줣���
    // �}���ݩʭ��O�����Ҧ� Debug �i�H�ݨ�p�H���
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    /// <summary>
    /// ���a������J��
    /// </summary>
    private float hValue;
    #endregion


    #region �ƥ�
    private void Start()
    {
        // GetComponent<����>() �x����k�A�i�H���w��������
        // �@�ΡG���o������ 2D ���餸��
        rig = GetComponent<Rigidbody2D>();
    }

    // �@������� 60 ��
    private void Update()
    {
        GetPlayerInputHorizontal();
    }

    // �T�w��s�ƥ�
    // �@��T�w���� 50 ���A�x���ĳ���ϥΨ쪫�z API �n�b���ƥ󤺰���
    private void FixedUpdate()
    {
        Move(hValue);
    }
    #endregion

    #region ��k
    /// <summary>
    /// ���o���a��J�����b�V�ȡGA�BD�B���B�k
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        // ������ = ��J.���o�b�V(�b�V�W��)
        // �@�ΡG���o���a���U�������䪺�ȡA���k�� 1�A������ -1�A�S���� 0
        hValue = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���k�ƭ�</param>
    private void Move(float horizontal)
    {
        // �ϰ��ܼơG�b��k�������A���ϰ�ʡA�ȭ��󦹤�k���s��
        // ²�g�Gtransform ������ Transform �ܧΤ���
        // posMove = �����e�y�� + ���a��J��������
        // Time.fixedDeltaTime �� 1/50 ��
        Vector2 posMove = transform.position + new Vector3(horizontal, 0, 0) * speed * Time.fixedDeltaTime;
        // ����.���ʮy��(�n�e�����y��)
        rig.MovePosition(posMove);
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
