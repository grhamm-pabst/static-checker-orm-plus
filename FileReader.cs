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
            if (path == null) throw new ArgumentNullException("path");

            if (!path.EndsWith(".231")) throw new Exception("O tipo do arquivo não é permitido");
            string fullPath;

            if (!Path.IsPathRooted(path))
            {

                string? projectDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                if (projectDirectory == null) throw new Exception("Erro inesperado na obtenção do arquivo");
                fullPath = Path.Combine(projectDirectory, path);
            }
            else
            {
                fullPath = path;
            }

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("O arquivo especificado não foi encontrado.", fullPath);
            }

            List<string> lines = new List<string>();

            try
            {
               return new StreamReader(fullPath);                
            }
            catch (Exception e)
            {
                throw new FileLoadException($"Ocorreu um erro ao ler o arquivo: {e.Message}");
            }
        }

        public String? nextLine() {

            return this.reader.ReadLine();
        }
    }
}