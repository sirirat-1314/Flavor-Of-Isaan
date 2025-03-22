using UnityEngine;

public class MK : MonoBehaviour
{
    public static MK instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
}
