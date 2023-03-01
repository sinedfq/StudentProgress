using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable.Models
{
    public class Student
    {
        private float sr_scores = 0;
        private ushort[] scores = { 0, 0, 0 };
        private string name = "";

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        public ushort Visual
        {
            get => scores[0];
            set => scores[0] = value;
        }


        public ushort Architecture
        {
            get => scores[1];
            set => scores[1] = value;
        }

        public ushort Networks
        {
            get => scores[2];
            set => scores[2] = value;
        }

        public float Average_Score
        {
            get
            {
                sr_scores = 0;
                foreach (ushort num in scores)
                {
                    sr_scores += num;
                }
                return sr_scores /= 3;
            }
        }
    }
}
