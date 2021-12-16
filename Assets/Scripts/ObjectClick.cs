using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{

    private void OnMouseDown() 
    {

        //RA Manager
        RAManager.Instance.ObjectClicked(this.gameObject);

    
    }



       




}
