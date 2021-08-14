using UnityEngine;

/// <summary>
/// ��Z�������ĤH�����G��Z������
/// </summary>
// ���O : �����O
// : �_���᭱�Ĥ@�ӥN�����O�n�~�Ӫ����O
public class NearEnemy : BaseEnemy
{
    #region ���
    [Header("�����ϰ쪺�첾�P�j�p")]
    public Vector2 checkAttackOffset;
    public Vector3 checkAttackSize;
    #endregion

    #region �ƥ�
    protected override void OnDrawGizmos()
    {
        // �����O�쥻���{�����e
        base.OnDrawGizmos();

        Gizmos.color = new Color(0.5f, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(
            transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize);
    }

    protected override void Update()
    {
        base.Update();

        CheckPlayerInAttackArea();
    }
    #endregion

    #region ��k
    /// <summary>
    /// �ˬd���a�O�_�i�J�����ϰ�
    /// </summary>
    private void CheckPlayerInAttackArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize, 0, 1 << 7);

        // �p�G �I�쪫�󬰪��a �N�N���A�אּ ����
        if (hit) state = StateEnemy.attack;
    }
    #endregion
}