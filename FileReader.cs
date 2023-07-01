using System;
using System.Collections.Generic;
using System.IO;

namespace Static_Checker
{
    internal class FileReader
    {
        private StreamReader reader;

        public FileReader(string? path)
        {
            this.reader = OpenFile(path);
        }

        public StreamReader OpenFile(string? path)
        {
            if (path == null || path == "") ErrorManager.throwError("O path está vazio");

            if (!path.EndsWith(".231")) ErrorManager.throwError("O tipo do arquivo não é permitido");
            string fullPath = "";

            if (!Path.IsPathRooted(path))
            {

                string? projectDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                if (projectDirectory == null) ErrorManager.throwError("Erro inesperado na obtenção do arquivo");
                else fullPath = Path.Combine(projectDirectory, path);
            }
            else
            {
                fullPath = path;
            }

            if (!File.Exists(fullPath))
            {
                ErrorManager.throwError($"{fullPath} não foi encontrado");
            }

            List<string> lines = new List<string>();

            try
            {
               return new StreamReader(fullPath);                
            }
            catch (Exception e)
            {
                ErrorManager.throwError($"Ocorreu um erro ao ler o arquivo: {e.Message}");
                throw new Exception();
            }
        }

        public String? nextLine() {

            return this.reader.ReadLine();
        }
    }
}