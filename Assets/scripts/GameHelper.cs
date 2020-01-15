using UnityEngine;
using System.Collections;

public class GameHelper : MonoBehaviour {
    public BirdsHelper SelectedBirdsHelper { get; set; }
                                       // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool _Bird_selected_bool;
        bool _red=false;
        bool _yellow=false;
        bool _boomerang=false;
        Vector3 cour = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectedBirdsHelper == null)
            {
                Collider2D[] all = Physics2D.OverlapCircleAll(cour, 0.1f);
                foreach (var item in all)
                {
                    if (item.GetComponent<BirdsHelper>())
                    {
                        SelectedBirdsHelper = item.GetComponent<BirdsHelper>();
                        Debug.Log(item);
                        if (item.name == "red")
                        {
                            _red = true;
                            Debug.Log("======================================================================================");
                        }
                        if (item.name == "yellow")
                        {
                            _yellow = true;
                            Debug.Log("======================================================================================");
                        }
                        if (item.name == "boomerang")
                        {
                            _boomerang = true;
                            Debug.Log("======================================================================================");
                        }
                        break;
                    }
                }
            }
        }
        if (SelectedBirdsHelper != null)
        { 
            SelectedBirdsHelper.transform.position = Vector3.MoveTowards (SelectedBirdsHelper.transform.position, new Vector2(cour.x,cour.y) , Time.deltaTime * 100.0f);

            var dir =SelectedBirdsHelper.StartPosition -new Vector2 (SelectedBirdsHelper.transform.position.x, SelectedBirdsHelper.transform.position.y);

            var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
            SelectedBirdsHelper.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //GameObject _Bird = new GameObject();
            //_Bird = GameObject.Find("yellow");
            //_Bird.transform.position = Vector2.MoveTowards(SelectedBirdsHelper.transform.position, new Vector3(8, 1), Time.deltaTime);

            if (SelectedBirdsHelper != null)
            {
                if (_red==true)
                {
                    Debug.Log("00000000000000000000000000000000000000000000000000000000000000000000000");
                }
                SelectedBirdsHelper.GetComponent<Rigidbody2D>().isKinematic = false;
                SelectedBirdsHelper.GetComponent<Rigidbody2D>().AddForceAtPosition(SelectedBirdsHelper.transform.right*Vector3.Distance (SelectedBirdsHelper.transform.position, SelectedBirdsHelper.StartPosition)* 700,
                SelectedBirdsHelper.StartPosition);
                SelectedBirdsHelper = null;
            }
        } 
	}

    //void OnCollisionEnter(Collision collision)      типо проверка на столкновения
    //{
    //    Debug.Log("qwerqwerqwerqwerqwrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
    //    if (collision.gameObject.name== "con")
    //    {
    //        Debug.Log("qwerqwerqwerqwerqwrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
    //    }
    //}
    //
    //void OnCollisionEnter(Collision collision)
    //{
    //    // Вызывается, когда происходит физическое столкновение
    //    Debug.Log("Collided with " + collision.gameObject.name);
    //}
}
