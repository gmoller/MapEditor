using System.Collections.Generic;
using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class UnitTypes
    {
        private readonly Dictionary<int, UnitType> _unitTypes;

        private UnitTypes(List<UnitType> unitTypes)
        {
            _unitTypes = new Dictionary<int, UnitType>();
            foreach (UnitType item in unitTypes)
            {
                _unitTypes.Add(item.Id, item);
            }
        }

        public static UnitTypes Create(List<UnitType> unitTypes)
        {
            return new UnitTypes(unitTypes);
        }

        public UnitType this[int index]
        {
            get
            {
                if (index < 0 || index > _unitTypes.Count - 1)
                {
                    return UnitType.Invalid;
                }

                return _unitTypes[index];
            }
        }

        private string DebuggerDisplay => $"{{Count={_unitTypes.Count}}}";
    }
}