using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

    /**

data kinematic : posisi dan orientasi pada karakter telah terdapat pada class transform
untuk mengakses gunakan transform
      **/


    //Transform charakter; // sudah tidak perlu karena sudah bisa diakses dengan syntax this.transform 
    public Transform _target;
    public int _maxSpeed;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //GLB
        //position = position + velocity*time
        //lengkapi line code dibawah ini dan hilangkan sintax "//"
        this.transform.position = transform.position + getSteering()._velocity * Time.deltaTime;


    }

    public KinematicData getSteering()
    {
        KinematicData _KinematicOut = new KinematicData();
        //lengkapi line code dibawah ini dan hilangkan sintax "//"
        _KinematicOut._velocity = _target.position - this.transform.position; //#direction
        _KinematicOut._velocity = _KinematicOut._velocity.normalized; // normalize membuat resultan vektor = 1.
        //lengkapi line code dibawah ini dan hilangkan sintax "//"
        _KinematicOut._velocity = _KinematicOut._velocity *_maxSpeed;   //buat resultan vector velocity bernilai maxSpeed
        this.transform.eulerAngles = getNewOrientation(this.transform.eulerAngles, _KinematicOut._velocity); //rotation menggunakan euler angle (vector 3D(X,Y,Z)

        return _KinematicOut;
    }

    public Vector3 getNewOrientation(Vector3 _currentOrientation, Vector3 _velocity)
    {
        //Make sure we have a velocity
        if (_velocity.magnitude > 0) //length didapat dri fungsi magnitude (mendapatkan resultan)
        {
            //Calculate orientation using an arc tangent of the velocity components.
            //lengkapi line code dibawah ini dan hilangkan sintax "//"
            float radian = Mathf.Atan2(_velocity.x, _velocity.z); //dalam radian, tidak perlu minus karena rotasi unity searah jarum jam
            float angle = radian * (180/Mathf.PI);  // untuk mengganti ke angle
            Vector3 newOrientation = new Vector3(0,angle,0); //untuk unity 3D rotasi menggunakan vector 3D (X,Y,Z) , Y berisi angle berarti objek diputar sebesar angle derajat pada sumbu Y
            return newOrientation;
        }

        //Otherwise use the current orientation
        else
            return _currentOrientation;
    }
    

}
