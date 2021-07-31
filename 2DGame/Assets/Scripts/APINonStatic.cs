using UnityEngine;

public class APINonStatic : MonoBehaviour
{
    // API ���A������j��
    // 1. �R�@�A�G������r static
    // 2. �D�R�A�G�L����r static

    // �ϥΫD�R�A�ݩ� 1. ���w�q���D�R�A�ݩʪ����O���
    // �ϥΫD�R�A�ݩ� 3. ��쥲����J�n������T������A�� ���ର�ŭ�
    public Transform traA;
    public Camera cam;
    public Transform traB;

    private void Start()
    {
        // 1. ���o�D�R�A�ݩ�

        // print("���o�y�СG" + Transform.position); // ���~�G�ݭn������Ѧ�

        // �ϥΫD�R�A�ݩ� 2. 
        // �� �y�k�G���.�D�R�A�ݩ�
        print("���o�ߤ���y�СG" + traA.position);
        print("���o��v�����I���C��G" + cam.backgroundColor);

        // 2. �]�w�D�R�A�ݩ�
        // �� �y�k�G���.�D�R�A�ݩ� ���w �ȡF
        cam.backgroundColor = new Color(0.8f, 0.5f, 0.6f);

        // 3. �I�s�D�R�A��k
        // �� �y�k�G���.�D�R�A��k(�����޼�)�F
        traB.Translate(1, 0, 0);
    }
}