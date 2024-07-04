using System;
using System.Collections.Generic;

namespace CRUD.Entity
{
    public class Atleta
    {
        public int IdAtleta { get; set; }
        public string NomeCompleto { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public string Posicao { get; set; }
        public int NroCamisa { get; set; }
        public decimal Imc { get { return Peso/(Altura*2); } }
        public string ClassificacaoImc { get { return ImcImc(); } }

        private string ImcImc()
        {
            string result = "";
            var actions = new Dictionary<Predicate<decimal>, Action>
            {
                { x => x < 18.5m, () => result = "Abaixo do peso normal" },
                { x => x >= 18.5m && x <= 24.9m, () => result = "Peso Normal" },
                { x => x >= 25m && x <= 29.9m, () => result = "Excesso de peso" },
                { x => x >= 30m && x <= 34.9m, () => result = "Obesidade classe I" },
                { x => x >= 35m && x <= 39.9m, () => result = "Obesidade classe II" },
                { x => x >= 40m, () => result = "Obesidade classe III" },
            };

            foreach (var action in actions)
            {
                if (action.Key(Imc))
                {
                    action.Value();
                    break;
                }
            }

            return result;
        }
    }

}
