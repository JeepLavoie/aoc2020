using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DockingData
{
    public record DockingSystem(IEnumerable<string> MemoryInputs)
    {
        public long ReadMemory()
        {
            var memory = new Dictionary<long, string>();
            var mask = string.Empty;

            foreach (var memoryInput in MemoryInputs)
            {
                var value = memoryInput.Split(" = ")[1];

                if (memoryInput.Contains("mask"))
                {
                    mask = value;
                    continue;
                }

                var indexRegex = Regex.Match(memoryInput, @"\[\d*\]");
                var index = long.Parse(indexRegex.Value.Replace("[", string.Empty).Replace("]", string.Empty));

                var bitValue = Convert.ToString(long.Parse(value), 2).PadLeft(36, '0').ToArray();

                for (var i = 0; i < mask.Length; i++)
                    bitValue[i] = mask[i] == 'X' ? bitValue[i] : mask[i];

                memory[index] = string.Join(string.Empty, bitValue);
            }

            return memory.Sum(x => Convert.ToInt64(x.Value, 2));
        }

        public long ReadMemoryV2()
        {
            var memory = new Dictionary<long, string>();
            var mask = string.Empty;

            foreach (var memoryInput in MemoryInputs)
            {
                var value = memoryInput.Split(" = ")[1];

                if (memoryInput.Contains("mask"))
                {
                    mask = value;
                    continue;
                }

                var indexRegex = Regex.Match(memoryInput, @"\[\d*\]");
                var index = long.Parse(indexRegex.Value.Replace("[", string.Empty).Replace("]", string.Empty));

                var indexBitValue = Convert.ToString(index, 2).PadLeft(36, '0').ToArray();
                var bitValue = Convert.ToString(long.Parse(value), 2).PadLeft(36, '0');

                for (var i = 0; i < mask.Length; i++)
                    indexBitValue[i] = mask[i] == '0' ? indexBitValue[i] : mask[i];

                var addresses = GenerateFloatingAddresses(string.Join("", indexBitValue));

                foreach (var address in addresses)
                    memory[Convert.ToInt64(address, 2)] = bitValue;
            }

            return memory.Sum(x => Convert.ToInt64(x.Value, 2));
        }

        private List<string> GenerateFloatingAddresses(string adress)
        {
            if (adress.Any(c => c == 'X'))
            {
                var adress0 = ReplaceFirstX(adress, "0");
                var adress1 = ReplaceFirstX(adress, "1");
                return GenerateFloatingAddresses(adress0).Concat(GenerateFloatingAddresses(adress1)).ToList();
            }
            else
                return new List<string> { adress };

        }

        private string ReplaceFirstX(string address, string newValue)
        {
            int index = address.IndexOf('X');
            if (index < 0)
                return address;
            return address.Remove(index, 1).Insert(index, newValue);
        }
    }
}
