using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAppuntamenti
{
    internal class Appuntamento
    {
        private DateTime dataOrarioAppuntamento;
        private string nomeAppuntamento;
        private string localitaAppuntamento;

        public Appuntamento(string nomeAppuntamento, string localitaAppuntamento, DateTime dataOrarioAppuntamento)
        {
            this.nomeAppuntamento = nomeAppuntamento;
            this.localitaAppuntamento = localitaAppuntamento;
            
            if(dataOrarioAppuntamento < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }
            else
            {

                this.dataOrarioAppuntamento = dataOrarioAppuntamento;
            }
        }

        public void CambiaDataAppuntamento(DateTime nuovaData)
        {
            if (nuovaData < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }
            else
            {

                this.dataOrarioAppuntamento = nuovaData;
            }
        }



        //getter e setter
        public string GetNomeAppuntamento()
        {
            return nomeAppuntamento;
        }
        public string GetLocalitaAppuntamento()
        {
            return localitaAppuntamento;
        }

        public void SetNomeAppuntamento(string nuovoNome)
        {
            nomeAppuntamento = nuovoNome;
        }

        public void SetLocalitaAppuntamento(string nuovaLocalita)
        {
            localitaAppuntamento = nuovaLocalita;
        }

        //stampa Appuntamento
        public void ToString()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Appuntamento: " + nomeAppuntamento);
            Console.WriteLine("Presso: " + localitaAppuntamento);
            Console.WriteLine("Alle ore: " + dataOrarioAppuntamento);

        }
    }
}
