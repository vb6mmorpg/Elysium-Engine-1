using System;
using System.Collections;

namespace WorldServer.Server {
    public class PlayerService {
        Hashtable service = new Hashtable();

        //por problemas de 'formato de datas', mantenho esse padrão
        const int YEAR = 2;
        const int MONTH = 1;
        const int DAY = 0;

        const int HOUR = 0;
        const int MINUTE = 1;
        const int SECONDS = 0;

        /// <summary>
        /// Adiciona um novo serviço com data e ID (de serviço).
        /// </summary>
        /// <param name="fullDateTime"></param>
        public void Add(string fullDateTime) {
            var data = fullDateTime.Split('-');

            const int ID = 0;
            const int DATE = 1;

            Add(int.Parse(data[ID]), data[DATE]);
        }

        /// <summary>
        /// Adiciona um novo serviço de usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateTime"></param>
        public void Add(int id, string dateTime) {
            var fulldate = dateTime.Split(' ');
            var date = fulldate[0].Split('/'); //quebra para pegar a data
            var hour = fulldate[1].Split(':'); //quebra para pegar a hora e minuto

            service.Add(id, new DateTime(int.Parse(date[YEAR]), int.Parse(date[MONTH]), int.Parse(date[DAY]), int.Parse(hour[HOUR]), int.Parse(hour[MINUTE]), SECONDS));
        }

        /// <summary>
        /// Remove um serviço de usuário pelo ID.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id) {
            service.Remove(id);
        }

        /// <summary>
        /// Pega a hora atual do sistema.
        /// </summary>
        /// <returns></returns>
        public static DateTime Now() {
            var now = DateTime.Now;                                                 //segundos
            return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
        }

        /// <summary>
        /// Verifica se o serviço já expirou.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool ServiceExpired(int id) {
            return Now().CompareTo(Convert.ToDateTime(service[id])) == 1 ? true : false;
        }

        /// <summary>
        /// Verifica cada serviço e atualiza na tabela.
        /// </summary>
        /// <param name="accountID"></param>
        public void VerifyServices(int accountID) {
            //pega a lista de serviços
            var sID = ServicesID();

            //se expirou, atualiza a db e remove da lista.
            foreach (var id in sID) {
                if (ServiceExpired(id)) {
                    //implementar em breve
                }
            }
        }

        /// <summary>
        /// Lista todos os serviços do usuário.
        /// </summary>
        /// <returns></returns>
        public int[] ServicesID() { 
            int[] service = new int[this.service.Count];
            var index = 0;

            //pega cada serviço e adiciona no array
            foreach (DictionaryEntry item in this.service) {
                service[index] = Convert.ToInt32(item.Key); //item.Key = ID do serviço
                index++;
            }

            return service;
        }

        /// <summary>
        /// Retorna o ID com o tempo do serviço.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ServiceTime(int id) {
            var date = Convert.ToDateTime(service[id]);
            // DIA, MES, ANO, HORA, MINUTO
            return $"{id}-{date.Day}/{date.Month}/{date.Year} {date.Hour}:{date.Minute}";
        }
    }
}
