using System;
using System.Collections;
using LoginServer.MySQL;

namespace LoginServer.Server {
    public class PlayerService {
        Hashtable service = new Hashtable();
        const int EXPIRED = 1;
        /// <summary>
        /// Adiciona um novo serviço de usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateTime"></param>
        public void Add(int id, string dateTime) {
            var fulldate = dateTime.Split(' ');
            var date = fulldate[0].Split('/');
            var hour = fulldate[1].Split(':');
            service.Add(id, new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(hour[0]), int.Parse(hour[1]), 0));
        }

        /// <summary>
        /// Remove um serviço de usuário.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id) {
            service.Remove(id);
        }

        /// <summary>
        /// Pega a hora atual do sistema.
        /// </summary>
        /// <returns></returns>
        private static DateTime Now() {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
        }

        /// <summary>
        /// Verifica se o serviço já expirou.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private bool ServiceExpired(int id) {
            return Now().CompareTo(Convert.ToDateTime(service[id])) == EXPIRED ? true : false;
        }

        /// <summary>
        /// Verifica cada serviço e atualiza na tabela.
        /// </summary>
        /// <param name="accountID"></param>
        public void VerifyServices(int accountID) {
            //pega a lista de serviços
            var sID = ServicesID();

            //se expirou, atualiza a db e remove da lista.
            foreach(var id in sID) {
                if (ServiceExpired(id)) {
                    Accounts_DB.UpdateService(accountID, id, EXPIRED);
                    service.Remove(id);
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

            foreach (DictionaryEntry item in this.service) {
                service[index] = Convert.ToInt32(item.Key);
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
            return id + "-" + date.Day + "/" + date.Month + "/" + date.Year + " " + date.Hour + ":" + date.Minute;
        }

    }
}
