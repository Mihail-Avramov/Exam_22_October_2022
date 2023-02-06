using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => this.Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (this.Multiprocessor.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            for (int i = 0; i < this.Multiprocessor.Count; i++)
            {
                if (this.Multiprocessor[i].Brand == brand)
                {
                    this.Multiprocessor.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public CPU MostPowerful()
        {
            double maxFrequency = 0;
            int maxFrequencyIndex = -1;

            for (int i = 0; i < this.Multiprocessor.Count; i++)
            {
                if (this.Multiprocessor[i].Frequency > maxFrequency)
                {
                    maxFrequency = this.Multiprocessor[i].Frequency;
                    maxFrequencyIndex = i;
                }
            }

            if (maxFrequencyIndex != -1)
            {
                return this.Multiprocessor[maxFrequencyIndex];
            }

            return default;
        }

        public CPU GetCPU(string brand)
        {
            foreach (var processor in this.Multiprocessor)
            {
                if (processor.Brand == brand)
                {
                    return processor;
                }
            }

            return default;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var processor in this.Multiprocessor)
            {
                sb.AppendLine(processor.ToString());
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
