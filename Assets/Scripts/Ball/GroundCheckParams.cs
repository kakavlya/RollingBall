using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GroundCheckParams:MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    public float GroundCheckRadius { get => _groundCheckRadius; }
    public LayerMask GroundLayer { get => _groundLayer; }
    public Transform GroundCheck { get => _groundCheck; }
}

