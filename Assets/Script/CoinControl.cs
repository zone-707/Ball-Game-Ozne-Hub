using UnityEngine;

public class CoinControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 350 *Time.deltaTime);
    }
}
