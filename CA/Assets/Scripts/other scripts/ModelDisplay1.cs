﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OctaviansGameOfLife
{

    public class ModelDisplay : MonoBehaviour
    {

        Vector3 centerOfObject;

        // Use this for initialization
        void Start()
        {
            // Check if the object is a CA grid
            if (transform.name == "caGrid")
            {
                if (transform.GetComponent<CA>() != null)
                {
                    centerOfObject = new Vector3(transform.GetComponent<CA>().columns / 2, 0, transform.GetComponent<CA>().columns / 2);
                }
                else
                {
                    centerOfObject = new Vector3(transform.GetComponent<CA_3D>().columns / 2, 0, transform.GetComponent<CA_3D>().columns / 2);
                }
            }
            else
            {
                centerOfObject = new Vector3(0, 0, 0);
                Transform[] chidrenTransforms = gameObject.GetComponentsInChildren<Transform>();
                foreach (Transform childTransform in chidrenTransforms)
                {
                    centerOfObject += childTransform.position;
                }
                centerOfObject = centerOfObject / chidrenTransforms.Length;
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(centerOfObject, Vector3.up, 20 * Time.deltaTime);
        }
    }
}