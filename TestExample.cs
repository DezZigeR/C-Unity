using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains.Test
{
    internal sealed class TestExample
    {
        public delegate void TestDelegate(string value); // 1

        private TestDelegate _testDelegate;   // 2

        private string _money ="9999999999999999999 рублей";

        private Button _button;

        private void NameMethod()
        {
            _testDelegate += TestDelegateMethod; // 3

            #region MyRegion

            _testDelegate += t => { Debug.Log(t); };
            _testDelegate += delegate(string value) { Debug.Log(value); };

            #endregion

            #region MyRegion

            _button.onClick.AddListener(() => Debug.Log(3));
            _button.onClick.RemoveAllListeners();

            #endregion

            _testDelegate("454");  // 4
        }

        public void GetMoney(TestDelegate testDelegate)
        {
            testDelegate?.Invoke(_money);
        }

        private void TestDelegateMethod(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}
