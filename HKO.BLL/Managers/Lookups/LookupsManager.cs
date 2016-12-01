using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using HKO.BLL.Handlers.Lookups;
using HKO.DAL;
using HKO.DAL.Repositories.Lookups;
using HKO.Models.DTOs.Lookups;
using HKO.Models.Lookups;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.BLL.Managers.Lookups
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class LookupsManager : BaseManager
    {

        public IEnumerable<Zupanija> GetZupanije()
        {
            ISqlGenerator<Zupanija> sqlGenerator = new SqlGenerator<Zupanija>();

            try
            {
                // Create repository instance
                ZupanijaRepository repository = new ZupanijaRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.S_ZUPANIJE");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Zupanija GetZupanijeByID(int zupanijaID)
        {
            ISqlGenerator<Zupanija> sqlGenerator = new SqlGenerator<Zupanija>();

            try
            {
                // Create repository instance
                ZupanijaRepository repository = new ZupanijaRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetFirst("HKO.S_ZUPANIJE",new { ID = zupanijaID });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<UgovorORadu> GetUgovorORadu()
        {
            ISqlGenerator<UgovorORadu> sqlGenerator = new SqlGenerator<UgovorORadu>();

            try
            {
                // Create repository instance
                UgovorORaduRepository repository = new UgovorORaduRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.S_UGOVOR_O_RADU");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public UgovorORadu GetUgovorORaduByID(int ugovorID)
        {
            ISqlGenerator<UgovorORadu> sqlGenerator = new SqlGenerator<UgovorORadu>();

            try
            {
                // Create repository instance
                UgovorORaduRepository repository = new UgovorORaduRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetFirst("HKO.S_UGOVOR_O_RADU", new { ID = ugovorID });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<StrucnoObrazovanje> GetStrucnoObrazovanje()
        {
            ISqlGenerator<StrucnoObrazovanje> sqlGenerator = new SqlGenerator<StrucnoObrazovanje>();

            try
            {
                // Create repository instance
                StrucnoObrazovanjeRepository repository = new StrucnoObrazovanjeRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.s_strucno_obrazovanje");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public StrucnoObrazovanje GetStrucnoObrazovanjeByID(int strucnoObrazovanjeID)
        {
            ISqlGenerator<StrucnoObrazovanje> sqlGenerator = new SqlGenerator<StrucnoObrazovanje>();

            try
            {
                // Create repository instance
                StrucnoObrazovanjeRepository repository = new StrucnoObrazovanjeRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetFirst("HKO.s_strucno_obrazovanje", new { ID = strucnoObrazovanjeID });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<Nkz98> GetNkz98()
        {
            ISqlGenerator<Nkz98> sqlGenerator = new SqlGenerator<Nkz98>();

            try
            {
                // Create repository instance
                Nkz98Repository repository = new Nkz98Repository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.s_nkz98");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Nkz98 GetNkz98ByID(string nkz98ID)
        {
            ISqlGenerator<Nkz98> sqlGenerator = new SqlGenerator<Nkz98>();

            try
            {
                // Create repository instance
                Nkz98Repository repository = new Nkz98Repository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetFirst("HKO.s_nkz98", new { NKZ98_ID = nkz98ID });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<Nkz7> GetNkz7()
        {
            ISqlGenerator<Nkz7> sqlGenerator = new SqlGenerator<Nkz7>();

            try
            {
                // Create repository instance
                Nkz7Repository repository = new Nkz7Repository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.s_nkz7");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Nkz7 GetNkz7ByID(string nkz7ID)
        {
            ISqlGenerator<Nkz7> sqlGenerator = new SqlGenerator<Nkz7>();

            try
            {
                // Create repository instance
                Nkz7Repository repository = new Nkz7Repository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetFirst("HKO.s_nkz7", new { NKZ7_ID = nkz7ID });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IList<HkoSifreDTO> GetHkoSifre()
        {
            ISqlGenerator<HkoSifre> sqlGenerator = new SqlGenerator<HkoSifre>();
            
            try
            {
                // Create repository instance
                HkoSifreRepository repository = new HkoSifreRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.s_hko_sifre");

                return HkoSifreHandler.MapHkoSifreToDtO(items);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public HkoSifreDTO GetHkoSifreByID(string hkoSifra)
        {
            ISqlGenerator<HkoSifre> sqlGenerator = new SqlGenerator<HkoSifre>();

            try
            {
                // Create repository instance
                HkoSifreRepository repository = new HkoSifreRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = HkoSifreHandler.MapHkoSifreToDtO(repository.GetAll("HKO.s_hko_sifre"));

                // Get sector if hkoSifra is for sector
                var response = items.FirstOrDefault(x => x.ID == hkoSifra);

                // Get sub-sector if hkoSifra is for sub-sector
                if (response == null)
                    response = items.SelectMany(x => x.Podsektori).First(y => y.ID == hkoSifra);

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<GradoviOpcine> GetGradoviOpcine()
        {
            ISqlGenerator<GradoviOpcine> sqlGenerator = new SqlGenerator<GradoviOpcine>();

            try
            {
                // Create repository instance
                GradoviOpcineRepository repository = new GradoviOpcineRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.s_gradovi_opcine");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public GradoviOpcine GetGradoviOpcineByID(int idGrad)
        {
            ISqlGenerator<GradoviOpcine> sqlGenerator = new SqlGenerator<GradoviOpcine>();

            try
            {
                // Create repository instance
                GradoviOpcineRepository repository = new GradoviOpcineRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetFirst("HKO.s_gradovi_opcine", new { ID = idGrad });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<GradoviOpcine> GetGradoviOpcineByZupanijaID(int idZupanija)
        {
            ISqlGenerator<GradoviOpcine> sqlGenerator = new SqlGenerator<GradoviOpcine>();

            try
            {
                // Create repository instance
                GradoviOpcineRepository repository = new GradoviOpcineRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetWhere("HKO.s_gradovi_opcine", new { ZUP_ID = idZupanija });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Rod> GetRodovi()
        {
            ISqlGenerator<Rod> sqlGenerator = new SqlGenerator<Rod>();

            try
            {
                // Create repository instance
                RodRepository repository = new RodRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.s_rod_hko_razina");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<KljucneDjelatnosti> GetKljucneDjelatnosti()
        {
            ISqlGenerator<KljucneDjelatnosti> sqlGenerator = new SqlGenerator<KljucneDjelatnosti>();

            try
            {
                // Create repository instance
                KljucneDjelatnostiRepository repository = new KljucneDjelatnostiRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetAll("HKO.S_NKD2007_ODJELJAK");

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DefaultTimeframe GetDefaultTimeframe()
        {
            ISqlGenerator<DefaultTimeframe> sqlGenerator = new SqlGenerator<DefaultTimeframe>();

            try
            {
                // Create repository instance
                DefaultTimeframeRepository repository = new DefaultTimeframeRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_podaci.get_max_month_year", param).FirstOrDefault();

                return items;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
