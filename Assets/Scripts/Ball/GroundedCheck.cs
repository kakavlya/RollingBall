using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GroundedCheck : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _Layer;
    [SerializeField] private Transform _checkingPoint;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_checkingPoint.position, _radius, _Layer);
    }
}