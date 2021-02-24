using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Geekbrains
{

    public delegate void GetBonusEvent(string value); // 1

    private GetBonusEvent _GetBonusEvent;   // 2

    private string _bonus = "Вы подняли буст ХП";

    private UnityEvent cameraShake bool;

       
        _GetBonusEvent += TestDelegateMethod; // 3


        _testDelegate("454");  // 4

    _GetBonusEvent -= TestDelegateMethod; // 5

    private void TestDelegateMethod(string value)
    {
        throw new System.NotImplementedException();
    }



    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker, IEquatable<GoodBonus>
    {
        public int Point;
        private Material _material;
        private float _lengthFlay;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
        }

        protected override void Interaction()
        {
            _view.Display(Point);
            // Add bonus
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        //.....

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }
    }
}