using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectController : MonoBehaviour, IController
{
    public List<GameObject> m_objects;

    public void Activate()
    {
        m_objects.ForEach(x => x.SetActive(true));
    }

    public void Deactivate()
    {
        m_objects.ForEach(x => x.SetActive(false));
    }
}
