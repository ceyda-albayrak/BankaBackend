using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using EntityLayer.EntityFramework.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityLayer.EntityFramework.Concrete
{
    //kalıtım
    public class EfHesapDal : IHesapDal
    {

        
        public async Task Add(Hesap hesap)
        {
            using (var context = new BankaContext())
            {
                int rowsAffected;
                string sql = "EXEC dbo.HesapEkle @SubeKodu,@MusteriNo,@EkNo,@DovizCinsi,@BakiyeTutar,@durum,@HesapKapanisTarihi";
                List<SqlParameter> parms = new List<SqlParameter>()
                {

                    new SqlParameter{ ParameterName = "@SubeKodu", Value = hesap.SubeKodu},
                    new SqlParameter{ ParameterName = "@MusteriNo", Value = hesap.MusteriNo},
                    new SqlParameter{ ParameterName = "@EkNo", Value = hesap.EkNo},
                    new SqlParameter{ ParameterName = "@DovizCinsi", Value = hesap.DovizCinsi},
                    new SqlParameter{ ParameterName = "@BakiyeTutar", Value = hesap.BakiyeTutar},
                    new SqlParameter{ ParameterName = "@durum", Value = hesap.Durum},
                    new SqlParameter{ ParameterName = "@HesapKapanisTarihi", Value = hesap.HesapKapanisTarihi}
                };
                rowsAffected = context.Database.ExecuteSqlRaw(sql, parms.ToArray());
            }
        }

        public void Delete(Hesap hesap)
        {
            using (var context = new BankaContext())
            {
                var deletedEntity = context.Entry(hesap);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Hesap Get(Expression<Func<Hesap, bool>> filter)
        {
            using (var context = new BankaContext())
            {
                return context.Set<Hesap>().SingleOrDefault(filter);

            }
        }

        public async Task<List<Hesap>> GetAll()
        {
            using (var context = new BankaContext())
            {
                List<Hesap> list;
                string sql = "EXEC dbo.HesapListe";
                list = context.Hesap.FromSqlRaw<Hesap>(sql).ToList();

                return list;
            }
            
        }

        public async Task<List<EkNoDto>> GetEkNo(string tckn)
        {
            using (BankaContext context=new BankaContext())
            {
                var result = from m in context.Musteri
                    join h in context.Hesap on m.MusteriNo equals h.MusteriNo
                    select new EkNoDto()
                    {
                        EkNo = h.EkNo,
                        TCKNO = m.TCKN
                    };
                return  result.Where(p => p.TCKNO == tckn).ToList();
            }
        }

        public HesapDetayDto GetHesapDetail(int ekno)
        {
            using (BankaContext context= new BankaContext())
            {
                var result = from m in context.Musteri
                    join h in context.Hesap on m.MusteriNo equals h.MusteriNo
                    select new HesapDetayDto()
                    {
                        Ad = m.Ad,
                        Bakiye = h.BakiyeTutar,
                        DovizCinsi = h.DovizCinsi,
                        Soyad = m.Soyad,
                        SubeNo = h.SubeKodu,
                        EkNo = h.EkNo,
                        HesapKapanisTarihi = h.HesapKapanisTarihi
                    };
                return result.SingleOrDefault(p => p.EkNo == ekno);
            }
        }

        public async Task Update(Hesap hesap)
        {
            using (var context = new BankaContext())
            {
                int rowsAffected;
                string sql = "EXEC dbo.HesapGuncelle @Id,@SubeKodu,@MusteriNo,@EkNo,@DovizCinsi,@BakiyeTutar,@durum,@HesapKapanisTarihi";
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter{ ParameterName = "@Id", Value = hesap.Id},
                    new SqlParameter{ ParameterName = "@SubeKodu", Value = hesap.SubeKodu},
                    new SqlParameter{ ParameterName = "@MusteriNo", Value = hesap.MusteriNo},
                    new SqlParameter{ ParameterName = "@EkNo", Value = hesap.EkNo},
                    new SqlParameter{ ParameterName = "@DovizCinsi", Value = hesap.DovizCinsi},
                    new SqlParameter{ ParameterName = "@BakiyeTutar", Value = hesap.BakiyeTutar},
                    new SqlParameter{ ParameterName = "@durum", Value = hesap.Durum},
                    new SqlParameter{ ParameterName = "@HesapKapanisTarihi", Value = hesap.HesapKapanisTarihi}
                };
                rowsAffected = context.Database.ExecuteSqlRaw(sql, parms.ToArray());
            }
        }
    }
}
