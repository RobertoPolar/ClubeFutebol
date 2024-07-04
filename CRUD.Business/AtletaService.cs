using CRUD.Data;
using CRUD.Entity;
using System;
using System.Collections.Generic;

namespace CRUD.Business
{
    public class AtletaService
    {
        AtletaDAO service = new AtletaDAO();

        public List<Atleta> Listar()
        {
            return service.Listar();
        }

        public Atleta ObterPorId(int id)
        {
            return service.ObterPorId(id);
        }

        public bool Criar(Atleta atleta)
        {
            return service.Criar(atleta);
        }

        public bool Editar(Atleta obj)
        {
            var atleta = service.ObterPorId(obj.IdAtleta);

            if(atleta.IdAtleta == 0)
                throw new OperationCanceledException("Nao existe esse atleta");

            return service.Editar(obj);
        }

        public bool Eliminar(int id)
        {
            var atleta = service.ObterPorId(id);

            if (atleta.IdAtleta == 0)
                throw new OperationCanceledException("Nao existe esse atleta");

            return service.Eliminar(id);
        }
    }
}
