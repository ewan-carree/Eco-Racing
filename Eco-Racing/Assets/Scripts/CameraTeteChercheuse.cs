using UnityEngine;

//dezoom quand vehicule en l'air

public class CameraTeteChercheuse : MonoBehaviour
{
    public Transform target; //notre objet à suivre
    public float smoothSpeed = 0.125f;  //vitesse de decalage

    
    private Vector3 offset = new Vector3(0,0,-10); //decalage de la camera en fonctions des layers

    
    void LateUpdate() //LateUpdate pour eviter de faire trop d'actions en meme temps (bug)
    {
        transform.position = target.position + offset; //suivi de notre objet
    }
}
