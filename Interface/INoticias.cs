using System.Collections.Generic;
using E_Players_AspNETCore.Models;

namespace E_Players_AspNETCore.Interface
{
    public interface INoticias
    {
          void Create(Noticias n);
        List<Noticias> ReadAll();
        void Update(Noticias n);
        void Delete(int id);
    }
}