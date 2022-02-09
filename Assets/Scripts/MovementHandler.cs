using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class MovementHandler : MonoBehaviour
{
    //Outlets
    protected Transform tf;
    //Configurations

    //States

    //Methods
    //Helper Methods

    //Updates transform of controller
    protected void Move(Vector2 vector){
        tf.position += new Vector3(vector.x, vector.y, 0);
    }

    protected void Rotate(Vector2 vector){
        throw new NotImplementedException();
    }

    protected void SetPosition(Vector3 vector){
        tf.position = vector;
    }

    protected abstract void InputListener();
}
