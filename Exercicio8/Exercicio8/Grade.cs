using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio8
{
    public class Grade : IEnumerable, IEnumerator
    {
        private Stack<Cerveja> _cheias;
        private Stack<Cerveja> _vazias;
        private int capacidade;
        private Capacidades tipoGarrafas;

        // gerado pelo interface IEnumerator 1/2
        private int index = 0;
        public object Current {
            get
            {
                return _cheias.Concat(_vazias).ToArray()[index];
            }
        }

        public Grade(Capacidades tipoGarrafas, int capacidade)
        {
            _cheias = new Stack<Cerveja>();
            _vazias = new Stack<Cerveja>();

            this.capacidade = capacidade;
            this.tipoGarrafas = tipoGarrafas;
        }

        public Cerveja RetiraCheia()
        {
            if(_cheias.Count == 0)
            {
                return null;
            }
            return _cheias.Pop(); 
        }

        public Cerveja RetiraVazia()
        {
            if (_vazias.Count == 0)
            {
                return null;
            }
            return _vazias.Pop();
        }

        public void Adiciona(Cerveja cerveja)
        {
            // grade está cheia?
            if((_cheias.Count + _vazias.Count) >= capacidade) {
                // alerta de grade cheia
                throw new ApplicationException("Grade cheia");
            }

            // garrafa adequada para esta grade?
            if(cerveja.Capacidade != tipoGarrafas)
                throw new ApplicationException("Garrafa inadequada à grade");

            // cheia ou vazia?
            if(cerveja.Cheia == true)
                _cheias.Push(cerveja);
            else
                _vazias.Push(cerveja);
        }

        // gerado pelo interface IEnumerable
        public IEnumerator GetEnumerator()
        {
            foreach(Cerveja cerveja in _cheias.Concat(_vazias)) // junta as listas
            {
                yield return cerveja;
            }
        }

        // gerado pelo interface IEnumerator 2/2
        public bool MoveNext()
        {
            index++;

            if (index > capacidade)
                return false;
            else
                return true;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
