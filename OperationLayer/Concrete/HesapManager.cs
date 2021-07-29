using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using EntityLayer.EntityFramework.Abstract;
using OperationLayer.Abstract;
using OperationLayer.Utilities.Results;

namespace OperationLayer.Concrete
{
    public class HesapManager : IHesapService
    {
        private IHesapDal _hesapDal;

        public HesapManager(IHesapDal hesapDal)
        {
            _hesapDal = hesapDal;
        }

        public Result Add(Hesap hesap)
        {
            _hesapDal.Add(hesap);
            return new SuccesResult("Eklendi");
        }

        public Result Delete(Hesap hesap)
        {
            _hesapDal.Delete(hesap);
            return new SuccesResult("Silindi");
        }

        public DataResult<Hesap> Get(string musterino)
        {
            return new SuccesDataResult<Hesap>(_hesapDal.Get(p=>p.MusteriNo==Int64.Parse(musterino)), "Filtrelendi");
        }

      
        public Task<List<Hesap>> GetAll()
        {
            return _hesapDal.GetAll();
        }

        public Task<List<EkNoDto>> GetEkNo(string tckn)
        {
            return _hesapDal.GetEkNo(tckn);

        }

        public HesapDetayDto GetHesapDetail(int ekno)
        {
            return _hesapDal.GetHesapDetail(ekno);
        }

        public Result Update(Hesap hesap)
        {
            _hesapDal.Update(hesap);
            return new SuccesResult("Güncellendi");
        }

       
    }
}
