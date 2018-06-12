
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using FileHelpers;

namespace TesteAutomate

{
    class Program
    {


        static ConcurrentDictionary<Guid, Arquivo>  Arquivos = new ConcurrentDictionary<Guid, Arquivo>();
     
        static void Main(string[] args)
        {
            var diretorioArquivos  = System.Configuration.ConfigurationManager.AppSettings["diretorioArquivos"];
            DirectoryInfo Dir = new DirectoryInfo(diretorioArquivos);

            FileInfo[] Files = Dir.GetFiles("*.txt", SearchOption.TopDirectoryOnly);

            Parallel.ForEach(Files, FileArquivo => {
                var novoArquivo = $" {FileArquivo.FullName.Replace(FileArquivo.Extension,"")}_{Guid.NewGuid()}{FileArquivo.Extension}";
                var linhas = File.ReadAllLines(FileArquivo.FullName).ToList();
                linhas.RemoveAt(0);
                linhas.RemoveAt(linhas.Count - 1);

                using (StreamWriter sr = new StreamWriter(novoArquivo)) {
                    foreach (var lin in linhas)
                        sr.WriteLine(lin);

                }
                var engine = new FixedFileEngine<Arquivo>();
                Arquivo[] result = engine.ReadFile(novoArquivo);
                foreach (var arq in result)
                    Arquivos.AddOrUpdate(Guid.NewGuid(), arq, (key, value) => arq);
                File.Delete(novoArquivo);
            });
            var arquivos =   Arquivos.Select(x=>x.Value).OrderBy(x => x.DataPregao).ToList();
            Console.ReadKey();

        }
    }
}
