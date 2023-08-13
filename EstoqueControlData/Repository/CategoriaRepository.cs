using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;

namespace EstoqueControlData.Repository
{
    public class CategoriaRepository :  GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EstoqueControlDbContext context) : base(context) { }
    }
}