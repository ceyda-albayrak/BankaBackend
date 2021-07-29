using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.EntityFramework.Abstract;
using OperationLayer.Abstract;
using OperationLayer.Utilities.Results;

namespace OperationLayer.Concrete
{
    public class MusteriManager : IMusteriService
    {
        private IMusteriDal _musteriDal;

        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }
        public Result Add(Musteri musteri)
        {
            _musteriDal.Add(musteri);
            return new SuccesResult("Eklendi");
        }

        public Result Delete(Musteri musteri)
        {
            _musteriDal.Delete(musteri);
            return new SuccesResult("Silindi");
        }

        public DataResult<Musteri> Get(string tcno)
        {
            return new SuccesDataResult<Musteri>(_musteriDal.Get(p=>p.TCKN==tcno), "Filtrelendi");
        }

        public Task<List<Musteri>> GetAll()
        {
            return _musteriDal.GetAll();
        }

        public Result Update(Musteri musteri)
        {
            _musteriDal.Update(musteri);
            return new SuccesResult("Güncellendi");
        }
    }
}
