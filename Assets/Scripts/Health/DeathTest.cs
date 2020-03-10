using UnityEngine;

public class DeathTest : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<GenericHealth>().onDeath.AddListener(YouDied);;
    }

    private void YouDied()
    {
        print("I have passed away.");
    }
}
