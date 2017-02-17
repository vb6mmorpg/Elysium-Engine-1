using System;
using System.IO;
using System.Collections.Generic;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Resource {
    /// <summary>
    /// Experiencia.
    /// </summary>
    public class ExperienceManage {
        private List<long> Data { get; set; }

        public long this[int index] {
            set {
                Data[index] = (long)value;
            }
            get {
                return Data[index];
            }

        }

        public static ExperienceManage Experience { get; set; } = new ExperienceManage();

        /// <summary>
        /// Inicializa o arquivo de experiência.
        /// </summary>
        /// <param name="file"></param>
        public void Initialize(string file) {
            Data = new List<long>();

            StreamReader file_open = new StreamReader($"{Configuration.GamePath}\\Data\\{file}.txt");
            var line = string.Empty;
            const int EXP = 1;

            while ((line = file_open.ReadLine()) != null) {
                string[] experience = line.Split('=');
                Data.Add(Convert.ToInt64(experience[EXP]));               
            }
        }
    }
}
