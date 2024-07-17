﻿using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util;
public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;

    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }
    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        VerificaCapacidade(_proximaPosicao + 1);
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }
    private void VerificaCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("Aumentando capacidade da lista!");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }
        _itens = novoArray;
    }
    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < _proximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual.Equals(conta))
            {
                indiceItem = i;
                break;
            }
        }
        for (int i = indiceItem; i < _proximaPosicao - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        _proximaPosicao--;
        _itens[_proximaPosicao] = null;
    }
    public void ExibeLista()
    {
        for (int i = 0; i < _proximaPosicao; i++)
        {
            if (_itens[i] != null) {
                ContaCorrente conta = _itens[i];
                Console.WriteLine($"Conta no índice {i}: {conta.Nome_Agencia} - {conta.Conta}");
            }

        }
    }
    public ContaCorrente RecuperarItemIndice(int indice)
    {
        if (indice < 0 || indice >= _proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return _itens[indice];
    }
    public int Tamanho
    {
        get
        {
           return _proximaPosicao;
        }
    }
    public ContaCorrente this [int indice]
    {
        get
        {
            return RecuperarItemIndice(indice);
        }
    }
}
