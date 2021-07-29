using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Dtos;
using EntityLayer.Entities;

namespace EntityLayer.EntityFramework.Abstract
{
    public interface IHesapDal : IEntityRepository<Hesap>
    {
       HesapDetayDto GetHesapDetail(int ekno);
        Task<List<EkNoDto>> GetEkNo(string tckn);

    }
}
