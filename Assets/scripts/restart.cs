using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {
    public BirdsHelper SelectedBirdsHelper { get; set; }
    // Update is called once per frame
    void Update ()
    {
        Vector3 cour = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectedBirdsHelper == null)
            {
                Collider2D[] all = Physics2D.OverlapCircleAll(cour, 0.1f);
                foreach (var item in all)
                {
                    if (item.name == "RBtn")
                    {
                        Application.LoadLevel(Application.loadedLevel);
                    }
                }
            }
        }
    }
}
