using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using OperationLayer.Utilities.Results;

namespace OperationLayer.Abstract
{
    public interface IHesapService:IService<Hesap>
    {
        HesapDetayDto GetHesapDetail(int ekno);
        Task<List<EkNoDto>> GetEkNo(string tckn);

    }
}
