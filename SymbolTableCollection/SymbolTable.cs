﻿using Static_Checker.LexemeTableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker.SymbolTableCollection
{
    internal class SymbolTable
    {
        private readonly List<SymbolEntry> entries;
        private int counter = 0;

        public SymbolTable(){
            entries = new List<SymbolEntry>();
            buildInitialAtoms();
        }

        public int getCode(string type)
        {
            switch(type)
            {
                case "cons-cadeia":
                    return 501;
                case "cons-caracter":
                    return 502;
                case "cons-inteiro":
                    return 503;
                case "cons-real":
                    return 504;
                case "nom-funcao":
                    return 511;
                case "nom-programa":
                    return 512;
                case "variavel":
                    return 513;
                default:
                    throw new Exception("Não há código para o lexeme");
            }
        }

        public int push(string lexeme, int lengthBeforeTruncate, int lengthAfterTruncate, string lexemeType, int line)
        {
            SymbolEntry? entry = this.checkIfExists(lexeme);
            if (entry != null)
            {
                entry.pushLine(line);
                return entry.EntryNumber;
            }
            else
            {
                int newEntryNumber = this.newEntryNumber();
                SymbolEntry newEntry = new SymbolEntry(newEntryNumber, this.getCode(lexemeType), lexeme, lengthBeforeTruncate, lengthAfterTruncate, lexemeType);
                entries.Add(newEntry);
                newEntry.pushLine(line);

                return newEntryNumber;
            }
        }

        public int push(int code, string lexeme, int lengthBeforeTruncate, int lengthAfterTruncate, string lexemeType, int line)
        {
            SymbolEntry? entry = this.checkIfExists(lexeme);
            if (entry != null)
            {
                entry.pushLine(line);
                return entry.EntryNumber;
            }
            else
            {
                int newEntryNumber = this.newEntryNumber();
                SymbolEntry newEntry = new SymbolEntry(newEntryNumber, this.getCode(lexemeType), lexeme, lengthBeforeTruncate, lengthAfterTruncate, lexemeType);
                entries.Add(newEntry);
                newEntry.pushLine(line);

                return newEntryNumber;
            }
        }

        public int push(int code, string lexeme, int lengthBeforeTruncate, int lengthAfterTruncate, string lexemeType)
        {
            SymbolEntry? entry = this.checkIfExists(lexeme);
            int newEntryNumber = this.newEntryNumber();
            entries.Add(new SymbolEntry(newEntryNumber, code, lexeme, lengthBeforeTruncate, lengthAfterTruncate, lexemeType));
            return newEntryNumber;
        }

        public SymbolEntry findByIndex(int index)
        {
            SymbolEntry entry = entries[index];
            if (entry == null)
            {
                throw new IndexOutOfRangeException();
            }
            else { return entry; }
        }

        public int numOfEntries() { return entries.Count; }

        private int newEntryNumber()
        {
            return this.counter += 1;
        }

        private SymbolEntry? checkIfExists(string lexeme)
        {
            return entries.Find(element => lexeme == element.Lexeme);
                
        }

        private void buildInitialAtoms()
        {
            this.push(101, "cadeia", 6, 6, "cadeia");
            this.push(102, "caracter", 8, 8, "caracter");
            this.push(103, "declaracoes", 11, 11, "declaracoes");
            this.push(104, "enquanto", 7, 7, "enquanto");
            this.push(201, "false", 5, 5, "false");
            this.push(202, "fim-declaracoes", 15, 15, "fim-declaracoes");
            this.push(203, "fim-enquanto", 12, 12, "fim-enquanto");
            this.push(204, "fim-func", 8, 8, "fim-func");
            this.push(205, "fim-funcoes", 11, 11, "fim-funcoes");
            this.push(206, "fim-programa", 13, 13, "fim-programa");
            this.push(105, "fim-se", 6, 6, "fim-se");
            this.push(106, "funcoes", 7, 7, "funcoes");
            this.push(107, "imprime", 7, 7, "imprime");
            this.push(108, "inteiro", 7, 7, "inteiro");
            this.push(109, "logico", 6, 6, "logico");
            this.push(110, "pausa", 5, 5, "pausa");
            this.push(111, "programa", 8, 8, "programa");
            this.push(112, "real", 4, 4, "real");
            this.push(113, "retorna", 7, 7, "retorna");
            this.push(114, "se", 2, 2, "se");
            this.push(115, "senao", 5, 5, "senao");
            this.push(116, "tipo-func", 9, 9, "tipo-func");
            this.push(117, "tipo-param", 10, 10, "tipo-param");
            this.push(118, "tipo-var", 8, 8, "tipo-var");
            this.push(119, "true", 4, 4, "true");
            this.push(120, "vazio", 5, 5, "vazio");
            this.push(301, "%", 1, 1, "%");
            this.push(302, "(", 1, 1, "(");
            this.push(303, ")", 1, 1, ")");
            this.push(304, ",", 1, 1, ",");
            this.push(305, ":", 1, 1, ":");
            this.push(306, ":=", 2, 2, ":=");
            this.push(307, ";", 1, 1, ";");
            this.push(308, "?", 1, 1, "?");
            this.push(309, "[", 1, 1, "[");
            this.push(310, "]", 1, 1, "]");
            this.push(311, "{", 1, 1, "{");
            this.push(312, "}", 1, 1, "}");
            this.push(401, "-", 1, 1, "-");
            this.push(402, "", 1, 1, "");
            this.push(403, "/", 1, 1, "/");
            this.push(404, "+", 1, 1, "+");
            this.push(411, "!=", 2, 2, "!=");
            this.push(411, "#", 1, 1, "#");
            this.push(412, "<", 1, 1, "<");
            this.push(413, "<=", 2, 2, "<=");
            this.push(414, "==", 2, 2, "==");
            this.push(415, ">", 1, 1, ">");
            this.push(416, ">=", 2, 2, ">=");
        }
    }
}
