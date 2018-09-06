using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonnageScript : MonoBehaviour {

	public float vitesseMarche ;    // la vitesse de marche. Valeur de 1,5 dans l'inspecteur
	public float vitesseCourseMax ; // la vitesse de course maximum. Valeur de 3 dans l'inspecteur

	public float vitesseTotale; //vitesse marche + vitesse course


	private Rigidbody persoRigid ; // référence au composant rigidbody du personnage
	private Animator persoAnim ; // référence au composant animator du personnage
	float vitesseCourse; // la vitesse de course actuelle.

	public GameObject dard; //le dard




	///////////////////////////////////////////////////////////////////////////
	void Start ()
	{
		persoRigid = GetComponent<Rigidbody>();
		persoAnim = GetComponent<Animator>();

	}
	///////////////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////////////
	void Update()
	{
		transform.Rotate(0,Input.GetAxis("Horizontal")*2,0);

		vitesseTotale = 0;
		//Gestion de la course et de la marche
		if(Input.GetAxis("Vertical") != 0)
		{
			if(Input.GetKey(KeyCode.LeftShift) )
			{
				if(vitesseCourse < vitesseCourseMax) 
					vitesseCourse +=0.1f;
			}
			else if(vitesseCourse>0)
			{
				vitesseCourse -=0.1f;
			}

			vitesseTotale = vitesseMarche+vitesseCourse;

			persoRigid.velocity = transform.forward * Input.GetAxis("Vertical") * vitesseTotale;

		}


		// informe Animator de la valeur de la vitesse, pour animer le personnage
		persoAnim.SetFloat("vitesse",vitesseTotale);                                                

	}



	///////////////////////////////////////////////////////////////////////////
	void OnCollisionEnter(Collision infoCol)
	{
		
	}

	void OnCollisionExit(Collision infoCol)
	{
		
	}



	void OnTriggerEnter(Collider infoCol)

	{
		
	}

	void OnTriggerExit(Collider infoCol)
	{
		
	}

}