using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using HKO.BLL.Mocks.Sektori;
using HKO.DAL;
using HKO.DAL.Repositories.Sektori;
using HKO.Models.DTOs.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using HKO.BLL.Handlers.Sektori;

namespace HKO.BLL.Managers.Sektori
{
    public class SektoriManager : BaseManager
    {
        /// <summary>
        /// Broj sektorskih zanimanja prema rodovima i obrazovnih programa prema razinama HKO
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <returns></returns>
        public IEnumerable<SektorskaZanimanjaRodoviDTO> GetSektorskaZanimanjaPremaRodovima(string sifraSektora, string sifraPodsektora)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;

            ISqlGenerator<SektorskaZanimanjaRodovi> sqlGenerator = new SqlGenerator<SektorskaZanimanjaRodovi>();

            try
            {
                // Create repository instance
                SektorskaZanimanjaRodoviRepository repository = new SektorskaZanimanjaRodoviRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input,32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur_zanimanja_rodovi_grp",null, OracleDbType.RefCursor,ParameterDirection.Output);

                // Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.proc_zanimanja_prema_rod_grp", param);

                var response = SektorskaZanimanjaRodoviMocking.MockObrazovni(items.ToList());

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Udio sektora u ukupnoj radnoj snazi RH
        /// </summary>
        /// <param name="sifraSektora">Default value -1</param>
        /// <param name="sifraPodsektora">Default value -1</param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <returns></returns>
        public IEnumerable<SektorRadnaSnagaDTO> GetSektorRadnaSnaga(string sifraSektora, int mjesec, int godina, string sifraPodsektora = null)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;

            ISqlGenerator<SektorRadnaSnaga> sqlGenerator = new SqlGenerator<SektorRadnaSnaga>();

            try
            {
                // Create repository instance
                SektorRadnaSnagaRepository repository = new SektorRadnaSnagaRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur_udio_podsektora ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.udio_podsektora_u_sektoru ", param);
                List<SektorRadnaSnagaDTO> response = SektorRadnaSnagaHandler.MapSektorRadnaSnagaToDto(items);

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Udio podsektora u radnoj snazi sektora
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <returns></returns>
        public IEnumerable<PodsektoriUSektoru> GetPodsektoriUSektoru(string sifraSektora, int mjesec, int godina)
        {
            ISqlGenerator<PodsektoriUSektoru> sqlGenerator = new SqlGenerator<PodsektoriUSektoru>();

            try
            {
                // Create repository instance
                PodsektoriUSektoruRepository repository = new PodsektoriUSektoruRepository(SqlCon, sqlGenerator);

                // Call repository method
                var items = repository.GetWhere("hko.t_podsektori_u_sektoru", new { godina=godina,mjesec = mjesec, sifra_sektora=sifraSektora });

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public SektorskaZanimanjaDjelatnostiDTO GetSektorskaZanimanjaDjelatnosti(string sifraSektora, int mjesec, int godina, string zupanijaID)
        {
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;

           // if (zupanijaID == null) throw new ArgumentNullException(nameof(zupanijaID));

            var items = SektorskaZanimanjaDjelatnostiMocking.MockDjelatnosti();

            return items;
        }

        public SektorskaZanimanjaRH GetBrojSektorskihZanimanjaRH(string sifraSektora)
        {
            ISqlGenerator<SektorskaZanimanjaRH> sqlGenerator = new SqlGenerator<SektorskaZanimanjaRH>();

            try
            {
                // Create repository instance
                SektorskaZanimanjaRHRepository repository = new SektorskaZanimanjaRHRepository(SqlCon, sqlGenerator);

                var response = SektorskaZanimanjaRHMocking.MockSektorskaZanimanjaRH();

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public ZaposlenostBrojDTO GetZaposlenostBroj(string sifraSektora, int mjesec, int godina,string sifraPodsektora, string zupanijaID)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;

            ISqlGenerator<ZaposlenostBroj> sqlGenerator = new SqlGenerator<ZaposlenostBroj>();

            try
            {
                // Create repository instance
                ZaposlenostBrojRepository repository = new ZaposlenostBrojRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", zupanijaID, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.nezaposleni", param);
                ZaposlenostBrojDTO response = ZaposlenostBrojHandler.MapZaposlenostBrojToDto(items);

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ZaposlenostStopa GetZaposlenostStopa(string sifraSektora, int mjesec, int godina, string sifraPodsektora, string zupanijaID)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;

            ISqlGenerator<ZaposlenostStopa> sqlGenerator = new SqlGenerator<ZaposlenostStopa>();

            try
            {
                // Create repository instance
                ZaposlenostStopaRepository repository = new ZaposlenostStopaRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", zupanijaID, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.nezaposleni_stopa", param).First();
                //ZaposlenostStopa response = ZaposlenostStopa.MapZaposlenostBrojToDto(items);

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<ZaposlenostUdjelDTO> GetZaposlenostUdjeliRodovi(string sifraSektora, int mjesec, int godina, string sifraPodsektora, string zupanijaID)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;

            ISqlGenerator<ZaposlenostUdjel> sqlGenerator = new SqlGenerator<ZaposlenostUdjel>();

            try
            {
                // Create repository instance
                ZaposlenostUdjelRepository repository = new ZaposlenostUdjelRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", zupanijaID, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.nezaposleni_udjel", param);
                var response = ZaposelnostUdjelHandler.MapZaposlenostUdjelToDto(items);

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<ZaposlenostUdjelDTO> GetNezaposlenostUdjeliRodovi(string sifraSektora, int mjesec, int godina, string sifraPodsektora, string zupanijaID)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;

            ISqlGenerator<ZaposlenostUdjel> sqlGenerator = new SqlGenerator<ZaposlenostUdjel>();

            try
            {
                // Create repository instance
                ZaposlenostUdjelRepository repository = new ZaposlenostUdjelRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", zupanijaID, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.nezaposleni_udjel", param);
                var response = ZaposelnostUdjelHandler.MapNezaposlenostUdjelToDto(items);

                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<ObuhvatSektora> GetObuhvatSektora(string sifraSektora, int mjesec, int godina, string sifraPodsektora)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;

            ISqlGenerator<ObuhvatSektora> sqlGenerator = new SqlGenerator<ObuhvatSektora>();

            try
            {
                // Create repository instance
                ObuhvatSektoraRepository repository = new ObuhvatSektoraRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", null, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_grp", "zup", OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_obuhvat.sektor", param);

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<KljucneDjelatnosti> GetKljucneDjelatnosti(string sifraSektora, int mjesec, int godina, string sifraPodsektora, string zupanijaID)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;

            ISqlGenerator<KljucneDjelatnosti> sqlGenerator = new SqlGenerator<KljucneDjelatnosti>();

            try
            {
                // Create repository instance
                KljucneDjelatnostiRepository repository = new KljucneDjelatnostiRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", zupanijaID, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_grp", "djel", OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_obuhvat.kljdjel", param);

                return items;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<DobSektor> GetSektorDob(string sifraSektora, int mjesec, int godina, string sifraPodsektora,
            string zupanijaID, string rod)
        {
            if (sifraPodsektora == "-1")
                sifraPodsektora = null;
            if (sifraSektora == "-1")
                sifraSektora = null;
            if (zupanijaID == "-1")
                zupanijaID = null;
            if (rod == "-1")
                rod = null;


            ISqlGenerator<DobSektor> sqlGenerator = new SqlGenerator<DobSektor>();

            try
            {
                // Create repository instance
                DobRepository repository = new DobRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("p_godina", godina, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_mjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("p_sifra_sektora", sifraSektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_sifra_podsektora", sifraPodsektora, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_zup", zupanijaID, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("p_rod", rod, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_obuhvat.dob", param);

                return items;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IEnumerable<ZaposljavanjeKljucDjel> GetZaposljavanjeKljucDjelatnosti(string godinaOd, string godinaDo, string mjesec, string odjeljak)
        {

            ISqlGenerator<ZaposljavanjeKljucDjel> sqlGenerator = new SqlGenerator<ZaposljavanjeKljucDjel>();

            try
            {
                // Create repository instance
                ZaposljavanjeKljucDjelRepository repository = new ZaposljavanjeKljucDjelRepository(SqlCon, sqlGenerator);

                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("pgodinaod", godinaOd, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("pmjesec", mjesec, OracleDbType.Decimal, ParameterDirection.Input);
                param.Add("pgodinado", godinaDo, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("podjeljak", odjeljak, OracleDbType.Varchar2, ParameterDirection.Input, 32000);
                param.Add("outcur ", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //Call repository method
                var items = repository.OracleFunctionCursor("hko.pck_sektori.dzs_nezaposleni_nkd", param);

                return items;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
