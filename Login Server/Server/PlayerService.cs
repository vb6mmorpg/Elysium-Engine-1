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
        public void Add(int id, DateTime dateTime) {
            service.Add(id, dateTime);
        }

        /// <summary>
        /// Remove um serviço de usuário.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id) {
            service.Remove(id);
        }

        /// <summary>
        /// Quantidade de serviços.
        /// </summary>
        /// <returns></returns>
        public int Count() {
            return service.Count;
        }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        public void Clear() {
            service.Clear();
        }

        /// <summary>
        /// Verifica se o serviço já expirou.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private bool IsServiceExpired(int id) {
            return DateTime.Now.CompareTo(Convert.ToDateTime(service[id])) == EXPIRED ? true : false;
        }

        /// <summary>
        /// Verifica cada serviço e atualiza na tabela.
        /// </summary>
        /// <param name="accountID"></param>
        public void VerifyServices(int accountID) {
            var id = 0;

            //se expirou, atualiza a db e remove da lista.
            foreach (DictionaryEntry pair in service) {
                id = Convert.ToInt32(pair.Key);

                if (IsServiceExpired(id)) {
                    Accounts_DB.UpdateService(accountID, id, EXPIRED);
                    service.Remove(id);
                }
            }
        }

        /// <summary>
        /// Lista todos os serviços do usuário.
        /// </summary>
        /// <returns></returns>
        public int[] GetServicesID() {
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
        public string GetServiceTime(int id) {
            var date = Convert.ToDateTime(service[id]);
            return $"{id}-{date.ToString()}";
        }
    }
}
