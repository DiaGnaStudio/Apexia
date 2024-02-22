using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SidePanel.View
{
    public class ParentManager : MonoBehaviour
    {
        [SerializeField] private GameObject  parents1st;
        [SerializeField] private GameObject  parents2nd;

        public GameObject GetFirstParent()
        {
            parents1st.SetActive(true);
            return parents1st;
        }


    }
}
