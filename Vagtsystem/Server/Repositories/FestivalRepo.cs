using System;
using Vagtsystem.Shared.Models;

namespace Vagtsystem.Server.Repositories
{
	public class FestivalRepo : IFestivalRepo
	{
        private readonly IDbRepo _dbService;

        //opretter forbindelse ved brug af dbservice
        public FestivalRepo(IDbRepo dbService)
        {
            _dbService = dbService;
        }

        //opretter frivillig i database
        public async Task<bool> CreateFrivillig(Frivillig frivillig)
        {
            var result = await _dbService.EditData("INSERT INTO public.frivillig (fornavn, efternavn, telefon, email, adresse, fødselsdag, hold_id, stilling_id) VALUES (@Fornavn, @Efternavn, @Telefon, @Email, @Adresse, @Fødselsdag, @Hold_id, @Stilling_id)", frivillig);
            return true;
        }

        //henter liste af frivillige fra frivillig tabellen
        public async Task<List<Frivillig>> GetFrivilligList()
        {

            var frivilligList = await _dbService.GetAll<Frivillig>("SELECT * FROM public.frivillig", new { });
            return frivilligList;

        }

        //henter liste af frivillig fra frivilligview view tabellen +
        public async Task<List<Frivillig>> GetFrivilligView()
        {
            var frivilligList = await _dbService.GetAll<Frivillig>("SELECT * FROM public.frivilligview", new { });
            return frivilligList;
        }

        //henter frivillig fra frivilligview tabellen
        public async Task<Frivillig> GetFrivilligViewId(int frivillig_id)
        {
            var frivilligList = await _dbService.GetAsync<Frivillig>("SELECT * FROM public.frivilligview WHERE frivillig_id=@frivillig_id", new { frivillig_id });
            return frivilligList;
        }

        //henter vagtliste fra vagt tabellen
        public async Task<List<Vagt>> GetFrivilligVagtList(int vagt_id)
        {
            var frivilligList = await _dbService.GetAll<Vagt>("SELECT * FROM public.vagtview WHERE vagt_id = @vagt_id", new { vagt_id });
            return frivilligList;
        }

        //henter frivillig fra frivillig tabellen
        public async Task<Frivillig> GetFrivillig(int frivillig_id)
        {
            var frivilligList = await _dbService.GetAsync<Frivillig>("SELECT * FROM public.frivillig where frivillig_id=@Frivillig_id", new { frivillig_id });
            return frivilligList;
        }

        //opdaterer frivillig
        public async Task<Frivillig> UpdateFrivillig(Frivillig frivillig)
        {
            var updateFrivillig = await _dbService.EditData("Update public.frivillig SET fornavn=@Fornavn, efternavn=@Efternavn, telefon=@Telefon, email=@Email, adresse=@Adresse, fødselsdag=@Fødselsdag, hold_id=@Hold_id, stilling_id=@Stilling_id WHERE frivillig_id=@Frivillig_id", frivillig);
            return frivillig;
        }

        //sletter frivillig
        public async Task<bool> DeleteFrivillig(int key)
        {
            var deleteFrivillig = await _dbService.EditData("DELETE FROM public.frivillig WHERE frivillig_id=@Frivillig_id", new { frivillig_id = key });
            return true;
        }

        //opretter ny vagt hvor frivillig er sat på
        public async Task<bool> CreateVagt(Vagt fvagt)
        {
            var result = await _dbService.EditData("INSERT INTO public.frivillig_vagt (frivillig_id, vagt_id) VALUES (@Frivillig_id, @Vagt_id)", fvagt);
            return true;
        }

        //opretter ny tom vagt
        public async Task<bool> CreateHoldVagt(Vagt vagt)
        {
            var result = await _dbService.EditData("INSERT INTO public.vagt (start, slut, hold_id, prioritet) VALUES (@Start, @Slut, @Hold_id, @Prioritet)", vagt);
            return true;
        }

        //henter vagtliste
        public async Task<List<Vagt>> GetVagtList()
        {

            var vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.vagt", new { });
            return vagtList;

        }

        //henter en vagt med id
        public async Task<Vagt> GetVagt(int vagt_id)
        {
            var vagtList = await _dbService.GetAsync<Vagt>("SELECT * FROM public.koordinatorview WHERE vagt_id = @vagt_id", new { vagt_id });
            return vagtList;
        }

        //henter liste af vagter fra vagtview
        public async Task<List<Vagt>> GetBrugerVagter(int frivillig_id)
        {
            var vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.vagtview WHERE frivillig_id = @frivillig_id", new { frivillig_id });
            return vagtList;
        }

        //henter liste af vagter fra vagtview for specifik bruger
        public async Task<List<Vagt>> GetAlleBrugerVagter(int frivillig_id)
        {
            var vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.vagtview WHERE hold_id = frivillig_hold(@frivillig_id) AND (frivillig_id is null OR frivillig_id != @frivillig_id)", new { frivillig_id });
            return vagtList;
        }

        //henter er vagt fra vagtview
        public async Task<Vagt> GetBrugerVagt(int frivillig_vagt_id)
        {
            var vagtList = await _dbService.GetAsync<Vagt>("SELECT * FROM public.vagtview WHERE frivillig_vagt_id = @frivillig_vagt_id", new { frivillig_vagt_id });
            return vagtList;
        }

        //henter liste af vagter for specifikt hold
        public async Task<List<Vagt>> GetHoldVagt(int hold_id)
        {
            var vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.vagt WHERE hold_id=@hold_id", new { hold_id });
            return vagtList;
        }

        //henter vagtliste fra koordinatorview med sortering på
        public async Task<List<Vagt>> GetKoordVagt(int hold_id, int sort)
        {
            List<Vagt> vagtList = new();
            switch (sort)
            {
                case 1:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY antal", new { hold_id });
                    return vagtList;
                    break;
                case 2:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY antal DESC", new { hold_id });
                    return vagtList;
                    break;
                case 3:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY prioritet", new { hold_id });
                    return vagtList;
                    break;
                case 4:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY prioritet DESC", new { hold_id });
                    return vagtList;
                    break;
                case 5:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY start", new { hold_id });
                    return vagtList;
                    break;
                case 6:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY start DESC", new { hold_id });
                    return vagtList;
                    break;
                case 7:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY slut", new { hold_id });
                    return vagtList;
                    break;
                case 8:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY slut DESC", new { hold_id });
                    return vagtList;
                    break;
                default:
                    vagtList = await _dbService.GetAll<Vagt>("SELECT * FROM public.koordinatorview WHERE hold_id=@hold_id ORDER BY start", new { hold_id });
                    return vagtList;
                    break;
            }
            
        }

        //henter holdliste
        public async Task<List<Hold>> GetHold()
        {
            var holdList = await _dbService.GetAll<Hold>("SELECT * FROM public.hold", new { });
            return holdList;
        }

        //henter stillingliste
        public async Task<List<Stilling>> GetStilling()
        {
            var stillingList = await _dbService.GetAll<Stilling>("SELECT * FROM public.stilling", new { });
            return stillingList;
        }

        //opdaterer vagt
        public async Task<Vagt> UpdateVagt(Vagt vagt)
        {
            var updateVagt = await _dbService.EditData("Update public.vagt SET hold_id=@Hold_id, start=@Start, slut=@Slut, prioritet=@Prioritet WHERE vagt_id=@Vagt_id", vagt);
            return vagt;
        }

        //sletter vagt hvor frivillig er på
        public async Task<bool> DeleteVagt(int frivillig_vagt_id)
        {
            var deleteVagt = await _dbService.EditData("DELETE FROM public.frivillig_vagt WHERE frivillig_vagt.frivillig_vagt_id = @frivillig_vagt_id", new { frivillig_vagt_id });
            return true;
        }

        //sletter tom vagt
        public async Task<bool> DeleteHoldVagt(int vagt_id)
        {
            var deleteVagt = await _dbService.EditData("DELETE FROM public.vagt WHERE vagt.vagt_id = @vagt_id", new { vagt_id });
            return true;
        }
    }
}

