using UnityEngine;

public class Mover : MonoBehaviour
{
    public static Mover moverInstance;
    public Vector3 axis = new Vector3(0,0,10);

    private void Awake() 
    {
       
        if(moverInstance == null)
        {
            PlayerPrefs.DeleteAll();
            moverInstance = this;
           // DontDestroyOnLoad(this);
        }
        else if(moverInstance != null)
        {
            Destroy(this);
        }
    }

    void Update()
    {
        transform.position += axis * Time.deltaTime;
    }

}