using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public Transform Target;

    public float Distancia = 10;
    public float Altura = 5;
    public float CambioDeAltura = 2;
    public float CambioDeRotacion = 0;

    public bool LookAtPlayer;

    private void LateUpdate()
    {
        if (!Target)
            return;

        float RotacionDeseada = Target.eulerAngles.y;
        float AlturaDeseada = Target.position.y + Altura;
        float RotacionActual = transform.eulerAngles.y;
        float AlturaActual = transform.position.y;

        RotacionActual = Mathf.LerpAngle(RotacionActual, RotacionDeseada, CambioDeRotacion * Time.deltaTime);
        AlturaActual = Mathf.LerpAngle(AlturaActual, AlturaDeseada, CambioDeAltura * Time.deltaTime);

        Quaternion rotacion = Quaternion.Euler(0, RotacionActual, 0);

        transform.position = Target.position;
        transform.position -= rotacion * Vector3.forward * Distancia;
        transform.position = new Vector3(transform.position.x, AlturaActual, transform.position.z);
        if (LookAtPlayer)
            transform.LookAt(Target);


    }

}
