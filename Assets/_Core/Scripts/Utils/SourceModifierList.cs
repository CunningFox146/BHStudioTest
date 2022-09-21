using System.Collections.Generic;

namespace BhTest.Utils
{
    public class SourceModifierList
    {
        private Dictionary<string, float> _modifiers = new Dictionary<string, float>();
        public float Modifier { get; private set; }
        private float _startValue;

        public SourceModifierList() : this(1f) { }

        public SourceModifierList(float startValue)
        {
            _startValue = startValue;
            Modifier = _startValue;
        }

        public void AddModifier(string name, float value)
        {
            _modifiers[name] = value;
            RecalculateModifier();
        }

        public void RemoveModifier(string name)
        {
            _modifiers.Remove(name);
            RecalculateModifier();
        }

        private void RecalculateModifier()
        {
            Modifier = _startValue;
            foreach (float modifier in _modifiers.Values)
            {
                Modifier *= modifier;
            }
        }
    }
}
