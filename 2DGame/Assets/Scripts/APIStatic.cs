using UnityEngine;

/// <summary>
/// �{�� API �H�βĤ@�إΪk�G�R�A static
/// </summary>
public class APIStatic : MonoBehaviour
{
    // API ���A������j��
    // 1. �R�@�A�G������r static
    // 2. �D�R�A�G�L����r static

    // �ݩʡGProperties �i�H�z�Ѭ����P�����
    // ��k�GMethods

    public float number = 9.99f;
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22, 22, 22);

    private void Start()
    {
        #region �{���R�A�ݩʻP��k
        // �R�A�ݩ�
        // 1. ���o
        // �� �y�k�G���O.�R�A�ݩ�
        print("�H���ȡG" + Random.value);           // 0 - 1
        print("�L���j�G" + Mathf.Infinity);

        // 2. �]�w
        // �� �y�k�G���O.�R�A�ݩ� ���w �ȡF
        Cursor.visible = false;
        // Random.value = 7.7f; // - ��Ū�ݩʤ���]�w Read Only
        Screen.fullScreen = true;

        // �R�A��k
        // 3. �I�s
        // �� �y�k�G���O.�R�A��k(�����޼�)�F
        float r = Random.Range(7.5f, 9.8f);
        print("�H���d�� 7.5 ~ 9.8�G" + r);
        #endregion

        #region �m���R�A�ݩʻP��k
        // 1. ���o�R�A�ݩ�
        print("�Ҧ���v���ƶq�G" + Camera.allCamerasCount);
        print("2D ���O�G" + Physics2D.gravity);
        print("��P�v�G" + Mathf.PI);
        // 2. �]�w�R�A�ݩ�
        Physics2D.gravity = new Vector2(0, -20);
        print("2D ���O�G" + Physics2D.gravity);
        Time.timeScale = 0.5f;                  // �C�ʧ@�A�ְʧ@ 2�A�Ȱ� 0
        print("�ɶ��j�p�G" + Time.timeScale);

        // 3. �I�s�R�A��k
        number =  Mathf.Floor(number);
        print("9.99 �h�p���I�G" + number);

        float d = Vector3.Distance(a, b);
        print("A �P B ���Z���G" + d);

        Application.OpenURL("https://unity.com/");
        #endregion
    }

    public float hp = 70;

    private void Update()
    {
        #region �{���R�A�ݩʻP��k
        hp = Mathf.Clamp(hp, 0, 100);       // �ƾ�.����(�ȡA�̤p�ȡA�̤j��) - �N��J���ȧ��b�̤p�̤j�d��
        print("��q�G" + hp);
        #endregion

        #region �m���R�A�ݩʻP��k
        // 1. ���o�R�A�ݩ�
        print("�O�_���U���N��G" + Input.anyKey);
        // print("�C���L�F�h�[�G" + Time.time);

        // 3. �I�s�R�A��k
        bool space = Input.GetKeyDown("space");
        print("�O�_���U�ť���G" + space);
        #endregion
    }
}
