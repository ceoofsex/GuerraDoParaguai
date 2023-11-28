using UnityEngine;

public class tntNoOpen : MonoBehaviour
{
    internal int _value;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_value == 1)
        {
            tnt boom = GetComponentInParent<tnt>();
            boom.tntLife -= _value;
            _value = 0;
        }

    }
}
