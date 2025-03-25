using LogbookERD.Core.Models.ItemRepository.Equipments;
using System.Text.RegularExpressions;

namespace LogbookERD.Core.Models
{
    public class EquipmentModel
    {
        private readonly EquipmentName _equipmentName;
        private readonly List<string> _kks;

        public EquipmentModel(string name, List<string> kks)
        {
            if (name == null || name.Length == 0)
            {
                throw new ArgumentNullException("Equipment name missing.", nameof(name));
            }
            if (kks == null || kks.Count < 1)
            {
                throw new ArgumentNullException("Equipment list kks missing.", nameof(kks));
            }

            foreach (var item in kks)
            {
                if (!Regex.IsMatch(item, @"^[a-zA-Z0-9]+$"))
                {
                    throw new ArgumentException("KKS contains invalid chars.", nameof(item));
                }
            }

            _equipmentName = new EquipmentName() { Name = name };
            _kks = kks;
        }

        public EquipmentName EquipmentName => _equipmentName;

        public List<string> KKS => _kks;
    }
}
