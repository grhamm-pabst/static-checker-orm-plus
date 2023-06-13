using System;
using System.Collections.Generic;
using System.IO;

namespace Static_Checker
{
    internal class FileReader
    {
        private StreamReader reader;

        public FileReader(string filePath, string nameFile)
        {
            this.reader = OpenFile(filePath, nameFile);
        }

        public StreamReader OpenFile(string filePath, string nameFile)
        {
            string fullPath;

            if (string.IsNullOrEmpty(filePath))
            {
                // Caso o filePath seja nulo ou vazio, considera-se que é para ler o arquivo do diretório do projeto
                if (string.IsNullOrEmpty(nameFile))
                {
                    throw new ArgumentException("O nome do arquivo não pode ser vazio ou nulo.");
                }

                string projectDirectory = Directory.GetCurrentDirectory();
                fullPath = Path.Combine(projectDirectory, nameFile);
            }
            else
            {
                fullPath = filePath;
            }

            // Verifica se o arquivo existe
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("O arquivo especificado não foi encontrado.", fullPath);
            }

            List<string> lines = new List<string>();

            try
            {
               return new StreamReader(filePath);                
            }
            catch (Exception e)
            {
                // Trate a exceção de leitura do arquivo conforme sua necessidade
                throw new FileLoadException($"Ocorreu um erro ao ler o arquivo: {e.Message}");
            }
        }

        public String? nextLine() {

            return this.reader.ReadLine();
        }
    }
}