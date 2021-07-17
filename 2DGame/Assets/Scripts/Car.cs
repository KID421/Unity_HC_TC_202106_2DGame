using UnityEngine;      // �ޥ� Unity ���� ���Ѫ� API (Unity Engine �R�W�Ŷ�)

// ���O
// �y�k�G�׹��� ���O����r �}���W��
public class Car : MonoBehaviour
{
    #region ����
    // �����ѡG�K�[�����B½Ķ�B��������...�|�Q�{������
    // KID 2021.07.17 (��) �}�o�T���}��

    /* �h�����
     * �h�����
     * �h�����
     * �h�����
     */
    #endregion

    #region �{�����P�`�Υ|�j����
    // ���G�x�s²�檺���
    // �y�k�G
    // �׹��� ������� ���W�� ���w�Ÿ� �w�]�� ����
    // ���w�Ÿ� =
    // �׹����G
    // 1. �p�H private �w�]�Ф����
    // 2. ���} public  �@�@�����

    // Unity ���`�Ϊ��|�j����
    // ��ơ@�@int    �ҡG1, 99, 0, -123
    // �B�I�ơ@float  �ҡG2.3, 3.1415, -1.123
    // �r��@�@string �ҡGBMW, ���h, ��ܤ��e@#...
    // ���L�ȡ@bool   �ҡGtrue, false

    // �w�q���
    // Unity �H�ݩ� Inspector ���O�W���Ȭ��D
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "���h";
    public bool windowSky = true;

    // �i�H�ϥΤ���A����ĳ - �s�X���D�P�ഫ�į���D
    // �W�߶}�o�B�ζ��\�i
    public int ���L�ƶq = 4;

    // ����ݩʡG���U���K�[�B�~�\��
    // �y�k�G[�ݩʦW��(�ݩʭ�)]
    // ���D�G[Header(�r��)]
    [Header("���L�ƶq")]
    public int wheelCount;
    // ���ܡG[Tooltip(�r��)]
    [Tooltip("�o����쪺�@�άO�]�w�T��������...")]
    public float height = 1.5f;
    // �d��G[Range(�̤p�ƭȡA�̤j�ƭ�)] - �ȭ��ƭ����� float �P int
    [Range(2, 10)]
    public int doorCount;
    // ���~�ܽd�G���A�Ω� float �P int �H�~������
    [Range(2, 10)]
    public bool canOpenMusic;
    #endregion

    #region ��L����
    // �C�� Color
    public Color color1;                                        // �����w���¦�z��
    public Color red = Color.red;                               // �ϥιw�]�C��
    public Color yellow = Color.yellow;
    public Color colorCustom1 = new Color(0.5f, 0.5f, 0);       // �ۭq�C��(R�AG�AB)
    public Color colorCustom2 = new Color(0.5f, 0, 0.5f, 0.5f); // �ۭq�C��(R�AG�AB�AA)

    // �y�� 2 - 4 �� Vector2 - 4
    // �O�s�ƭȸ�T�A�B�I��
    public Vector2 v2;
    public Vector2 v2Zero = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Custom = new Vector2(-99.5f, 100.5f);

    public Vector3 v3;
    public Vector4 v4;

    // ��������
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; // ���� 0�A�k�� 1�A�u�� 2

    // �C������P����
    public GameObject goCamera; // �C������]�t�����W���H�αM�פ����w�s��
    // ����ȭ���s���ݩʭ��O�������󪺪���
    public Transform traCar;
    public SpriteRenderer sprPicture;
    #endregion

    #region �ƥ�
    // �}�l�ƥ�G����C���ɰ���@���A�B�z��l��
    private void Start()
    {
        // ��X(�����������);
        print("���o�A�U�w~ :P");

        // �m�ߨ��o��� Get
        print(brand);
        // �m�߳]�w��� Set
        windowSky = true;
        cc = 5000;
        weight = 9.9f;
    }

    // ��s�ƥ�G�j���@�� 60 ���A60FPS�A�B�z���󲾰ʩΪ̺�ť���a��J
    private void Update()
    {
        print("�ڦb Update �� @3@");
    }
    #endregion
}
