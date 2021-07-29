using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.EntityFramework.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityLayer.EntityFramework.Concrete
{
    public class EfMusteriDal : IMusteriDal
    {

     
        public async Task Add(Musteri musteri)
        {
            using (var context = new BankaContext())
            {
                int rowsAffected;
                string sql = "EXEC dbo.MusteriEkle @Ad,@Soyad,@Unvan,@TCKN,@Durum,@GercekTuzel";
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                 
                    new SqlParameter{ ParameterName = "@Ad", Value = musteri.Ad},
                    new SqlParameter{ ParameterName = "@Soyad", Value = musteri.Soyad},
                    new SqlParameter{ ParameterName = "@Unvan", Value = musteri.Unvan},
                    new SqlParameter{ ParameterName = "@TCKN", Value = musteri.TCKN},
                    new SqlParameter{ ParameterName = "@Durum", Value = musteri.Durum},
                    new SqlParameter{ ParameterName = "@GercekTuzel", Value = musteri.GercekTuzel}
                };
                rowsAffected = context.Database.ExecuteSqlRaw(sql, parms.ToArray());
            }


        }

        public void Delete(Musteri musteri)
        {
            using (var context = new BankaContext())
            {
                var deletedEntity = context.Entry(musteri);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Musteri Get(Expression<Func<Musteri, bool>> filter)
        {
            using (var context = new BankaContext())
            {
                return context.Set<Musteri>().FirstOrDefault(filter);

            }
        }

        public async Task<List<Musteri>> GetAll()
        {

            using (var context = new BankaContext())
            {
                List<Musteri> list;
                string sql = "EXEC dbo.MusteriListe";
                list = context.Musteri.FromSqlRaw<Musteri>(sql).ToList();
                return list;
            }
        }

        public async Task Update(Musteri musteri)
        {
            using (var context = new BankaContext())
            {
                int rowsAffected;
                string sql = "EXEC dbo.MusteriGuncelle @MusteriNo,@Ad,@Soyad,@Unvan,@TCKN,@Durum,@GercekTuzel";
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter{ ParameterName = "@MusteriNo", Value = musteri.MusteriNo},
                    new SqlParameter{ ParameterName = "@Ad", Value = musteri.Ad},
                    new SqlParameter{ ParameterName = "@Soyad", Value = musteri.Soyad},
                    new SqlParameter{ ParameterName = "@Unvan", Value = musteri.Unvan},
                    new SqlParameter{ ParameterName = "@TCKN", Value = musteri.TCKN},
                    new SqlParameter{ ParameterName = "@Durum", Value = musteri.Durum},
                    new SqlParameter{ ParameterName = "@GercekTuzel", Value = musteri.GercekTuzel}
                };
                rowsAffected = context.Database.ExecuteSqlRaw(sql, parms.ToArray());
            }
        }



       
    }
}
